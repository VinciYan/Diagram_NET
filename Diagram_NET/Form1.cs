using DevExpress.Diagram.Core;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using QuikGraph;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace Diagram_NET
{
    public partial class Form1 : DevExpress.XtraEditors.XtraForm
    {
        private bool _ctrlShiftDownUp = false;
        private bool _showInfoFlag = false;
        List<DiagramItem> selectedItems = new List<DiagramItem>();
        private const float NODE_NAME_Y_OFFSET = 6;
        const string diagramName = "diagram.xml";
        List<DataObject> DataObjects = new List<DataObject>();
        public Form1()
        {
            InitializeComponent();
            RegisterStencil();
            DataObjects.Add(new DataObject { ID = 0, Content = "Start" });
            DataObjects.Add(new DataObject { ID = 1, ParentID = 0, Content = "Node 1" });
            DataObjects.Add(new DataObject { ID = 2, ParentID = 1, Content = "Node 1_1" });
            DataObjects.Add(new DataObject { ID = 3, ParentID = 0, Content = "Node 2" });
            DataObjects.Add(new DataObject { ID = 4, ParentID = 3, Content = "Node 2_1" });
        }
        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            if (!File.Exists(diagramName))
                CreateDiagram();
            else
                LoadDiagram();
        }
        protected override void OnClosing(CancelEventArgs e)
        {
            base.OnClosing(e);
            diagramControl1.SaveDocument(diagramName);
        }
        void RegisterStencil()
        {
            var stencil = new DevExpress.Diagram.Core.DiagramStencil("CustomStencil", "Custom Shapes");

            //注册DiagramShapeEx
            var itemTool = new FactoryItemTool("CustomShape", () => "Custom Shape", diagram => { DiagramShapeEx customShape = new DiagramShapeEx() { Width = 100, Height = 50 }; return customShape; }, new System.Windows.Size(100, 50), false);
            stencil.RegisterTool(itemTool);

            // 注册ShapeImage
            stencil.RegisterTool(new FactoryItemTool("节点", () => "节点", diagram =>
            {
                return new ShapeImage();
            }, new System.Windows.Size(18, 18)));

            DevExpress.Diagram.Core.DiagramToolboxRegistrator.RegisterStencil(stencil);
            DiagramControl.ItemTypeRegistrator.Register(typeof(DiagramShapeEx), typeof(ShapeImage), typeof(CustomConnector));

        }
        private void LoadDiagram()
        {
            try
            {
                diagramControl1.LoadDocument(diagramName);
                foreach (var item in diagramControl1.Items)
                {
                    var shape = item as DiagramShapeEx;
                    DataObject dataObject;
                    if (shape != null)
                        shape.Content = (dataObject = DataObjects.FirstOrDefault(x => x.ID == shape.DatabaseObjectID)) == null ? null : dataObject.Content;
                }
            }
            catch (Exception e)
            {
                CreateDiagram();
            }
        }
        private void CreateDiagram()
        {
            foreach (var dataObject in DataObjects)
            {
                var shape = new DiagramShapeEx
                {
                    Shape = BasicShapes.Rectangle,
                    Size = new Size(150, 100),
                    DatabaseObjectID = dataObject.ID,
                    Content = dataObject.Content
                };
                diagramControl1.Items.Add(shape);
                if (dataObject.ParentID != dataObject.ID)
                    diagramControl1.Items.Add(new DiagramConnector
                    {
                        BeginItem = diagramControl1.Items.First(x => x is DiagramShapeEx && ((DiagramShapeEx)x).DatabaseObjectID == dataObject.ParentID),
                        EndItem = shape
                    });
            }
            diagramControl1.ApplyTreeLayout(Direction.Right);
        }
        private void OnShowingEditor(object sender, DiagramShowingEditorEventArgs e)
        {
            e.Cancel = true;
        }

        private void diagramControl1_CustomGetEditableItemProperties(object sender, DiagramCustomGetEditableItemPropertiesEventArgs e)
        {
            if (e.Item is DiagramShapeEx)
            {
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(DiagramShapeEx))["DatabaseObjectID"]);
            }
            if (e.Item is ShapeImage)
            {
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(ShapeImage))["Id"]);
            }
            if (e.Item is CustomConnector)
            {
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(CustomConnector))["WeightVal"]);
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(CustomConnector))["Id"]);
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(CustomConnector))["BeginNodeNo"]);
                e.Properties.Add(TypeDescriptor.GetProperties(typeof(CustomConnector))["EndNodeNo"]);
            }
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            diagramControl1.OptionsBehavior.ActiveTool = new DevExpress.Diagram.Core.FactoryConnectorTool(
                "CurvedConnector",
                () => "CurvedConnector",
                x => new CustomConnector() { Type = DevExpress.Diagram.Core.ConnectorType.Straight });
        }

        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            diagramControl1.OptionsBehavior.ActiveTool = diagramControl1.OptionsBehavior.PointerTool;
        }

        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (_showInfoFlag == true)
            {
                List<DiagramItem> delDiagramItems = new List<DiagramItem>();
                DiagramItemCollection diagramItemCollection = diagramControl1.Items;
                foreach (var item in diagramItemCollection)
                {
                    if (item is CustomConnector) continue;
                    if (item.Tag != null && item.Tag.ToString().StartsWith("info"))
                    {
                        delDiagramItems.Add(item);
                    }
                }

                foreach (var del in delDiagramItems)
                {
                    diagramControl1.Items.Remove(del);
                }
                _showInfoFlag = !_showInfoFlag;
                return;
            }

            if (_showInfoFlag == false)//显示节点信息
            {
                List<NodeInfoShape> nodeInfoShapes = new List<NodeInfoShape>();
                DiagramItemCollection diagramItemCollection = diagramControl1.Items;
                foreach (var item in diagramItemCollection)
                {
                    if (item is null) continue;
                    if (item is CustomConnector)
                    {
                        var con = (item) as CustomConnector;
                        var beginRec = con.ActualBeginPoint;
                        var endRec = con.ActualEndPoint;
                        var delX = endRec.X - beginRec.X;
                        var delY = endRec.Y - beginRec.Y;

                       // nodeInfoShapes.Add(
                       //    new NodeInfoShape()
                       //    {
                       //        Content = con.BeginNodeNo.ToString(),
                       //        FontColor = Color.Red,
                       //        Width = 15,
                       //        Height = 10,
                       //        CenterX = (float)(beginRec.X),
                       //        CenterY = (float)(beginRec.Y),
                       //        X = (float)(beginRec.X - 15 + delX * 0.2),
                       //        Y = (float)(beginRec.Y - 10 + delY * 0.2),
                       //    }
                       //);
                       // nodeInfoShapes.Add(
                       //    new NodeInfoShape()
                       //    {
                       //        Content = con.EndNodeNo.ToString(),
                       //        FontColor = Color.Red,
                       //        Width = 15,
                       //        Height = 10,
                       //        CenterX = (float)(endRec.X),
                       //        CenterY = (float)(endRec.Y),
                       //        X = (float)(endRec.X - 15 - delX * 0.2),
                       //        Y = (float)(endRec.Y - 10 - delY * 0.2),
                       //    }
                       //);
                        nodeInfoShapes.Add(
                           new NodeInfoShape()
                           {
                               Content = con.WeightVal.ToString(),
                               FontColor = Color.Green,
                               Width = 15,
                               Height = 10,
                               CenterX = (float)(endRec.X),
                               CenterY = (float)(endRec.Y),
                               X = (float)((beginRec.X + endRec.X) * 0.5),
                               Y = (float)((beginRec.Y + endRec.Y) * 0.5),
                           }
                       );
                        continue;
                    }
                    var shape = (item) as IShape;
                    if (shape != null)
                    {
                        var rect = item.Bounds;
                        nodeInfoShapes.Add(
                            new NodeInfoShape()
                            {
                                Content = shape.Id.ToString(),
                                FontColor = Color.Black,
                                Width = 60,
                                Height = 20,
                                CenterX = (float)(rect.X + rect.Width * 0.5),
                                CenterY = (float)(rect.Y - NODE_NAME_Y_OFFSET),
                                X = (float)(rect.X + rect.Width * 0.5 - 60.0 * 0.5),
                                Y = (float)(rect.Y - NODE_NAME_Y_OFFSET - 20.0 * 0.5),
                            }
                        );
                    }
                }
                foreach (var item in nodeInfoShapes)
                {
                    DiagramShape diagramShape = new DiagramShape()
                    {
                        Content = item.Content,
                        Width = item.Width,
                        Height = item.Height,
                        CanSelect = false,
                        CanEdit = false,
                        CanResize = false,
                        Position = new PointFloat(item.X, item.Y),
                        Appearance =
                        {
                            BackColor = Color.Transparent, FontSizeDelta = -1, ForeColor = item.FontColor,
                            BorderSize = 0
                        },
                        CanSnapToThisItem = false,
                        CanAttachConnectorBeginPoint = false,
                        CanAttachConnectorEndPoint = false,
                        CanCopy = false,
                        CanMove = false,
                        CanDelete = false,
                        CanRotate = false,
                        Tag = "info"
                    };
                    diagramControl1.Items.Add(diagramShape);
                }
                _showInfoFlag = !_showInfoFlag;
            }
        }
        private void diagramControl_KeyDown(object sender, KeyEventArgs e)
        {
            if ((e.Modifiers & Keys.Control) == Keys.Control && (e.Modifiers & Keys.Shift) == Keys.Shift)
            {
                _ctrlShiftDownUp = true;
            }
        }

        private void diagramControl1_SelectionChanged(object sender, DiagramSelectionChangedEventArgs e)
        {
            if (diagramControl1.SelectedItems.Count == 2 && _ctrlShiftDownUp == true)
            {
                selectedItems.Clear();
                var items = diagramControl1.SelectedItems;

                var graph = new AdjacencyGraph<string, SEquatableTaggedEdge<string, double>>();

                foreach (var each in diagramControl1.Items)
                {
                    if (!(each is IShape))
                        continue;
                    graph.AddVertex((each as IShape).Id.ToString());//添加顶点
                }
                foreach (var each in diagramControl1.Items)
                {
                    if (each is CustomConnector)
                    {
                        string beg = string.Empty;
                        string end = string.Empty;
                        if ((each as CustomConnector).BeginItem != null)
                        {
                            beg = (((each as CustomConnector).BeginItem) as IShape).Id.ToString();
                        }
                        if ((each as CustomConnector).EndItem != null)
                        {
                            end = (((each as CustomConnector).EndItem) as IShape).Id.ToString();
                        }
                        if (!string.IsNullOrEmpty(beg) && !string.IsNullOrEmpty(end))
                        {
                            graph.AddEdge(new SEquatableTaggedEdge<string, double>(beg, end, (each as CustomConnector).WeightVal));//添加线路,管道的起始元件编号作为                            
                        }
                    };
                }

                var path = GraphUtil.GetShortestPath(graph, (items[0] as IShape).Id.ToString(), (items[1] as IShape).Id.ToString());
                if (path == null) return;
                if (path.Count == 1)
                {
                    foreach (var ver in path[0].PathList)//selectedItems中添加元件
                    {
                        foreach (var each in diagramControl1.Items)
                        {
                            if ((each as IShape).Id.ToString() == ver)
                            {
                                selectedItems.Add(each);
                                break;
                            }
                        }
                    }
                    foreach (var edge in path[0].PathEdges)//selectedItems中添加管道
                    {
                        foreach (var each in diagramControl1.Items)
                        {
                            if (each is CustomConnector && (((each as CustomConnector).BeginItem) as IShape).Id.ToString() == edge.Source
                                && (((each as CustomConnector).EndItem) as IShape).Id.ToString() == edge.Target)
                            {
                                selectedItems.Add(each);
                                break;
                            }
                        }
                    }
                }
                diagramControl1.SelectItems(selectedItems);
            }
        }
    }
    public class DataObject
    {
        public int ID { get; set; }
        public int ParentID { get; set; }
        public string Content { get; set; }
    }
}
