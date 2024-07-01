using DevExpress.Utils.Serializing;
using DevExpress.Utils;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram_NET
{
    public class ShapeImage : DiagramImage, IShape
    {
        public ShapeImage()
        {
            Image = Properties.Resource.node;

            #region 设置连接点
            List<PointFloat> points = new List<PointFloat>();
            points.Add(new PointFloat(0f, 0.5f));
            points.Add(new PointFloat(1f, 0.5f));
            points.Add(new PointFloat(0.5f, 0f));
            points.Add(new PointFloat(0.5f, 1f));
            ConnectionPoints = new PointCollection(points);
            #endregion
        }
        [XtraSerializableProperty, Category("自定义"), DisplayName("节点ID")]

        public int Id { get; set; }

        static ShapeImage()
        {
            DiagramControl.ItemTypeRegistrator.Register(typeof(ShapeImage));
        }
    }
}
