namespace Diagram_NET
{
    partial class Form1
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            diagramControl1 = new DevExpress.XtraDiagram.DiagramControl();
            diagramPropertyGridDockPanel1 = new DevExpress.XtraDiagram.Docking.DiagramPropertyGridDockPanel();
            diagramToolboxDockPanel1 = new DevExpress.XtraDiagram.Docking.DiagramToolboxDockPanel();
            dockManager1 = new DevExpress.XtraBars.Docking.DockManager(components);
            hideContainerRight = new DevExpress.XtraBars.Docking.AutoHideContainer();
            barManager1 = new DevExpress.XtraBars.BarManager(components);
            bar1 = new DevExpress.XtraBars.Bar();
            barButtonItem1 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem2 = new DevExpress.XtraBars.BarButtonItem();
            barButtonItem3 = new DevExpress.XtraBars.BarButtonItem();
            bar3 = new DevExpress.XtraBars.Bar();
            barDockControlTop = new DevExpress.XtraBars.BarDockControl();
            barDockControlBottom = new DevExpress.XtraBars.BarDockControl();
            barDockControlLeft = new DevExpress.XtraBars.BarDockControl();
            barDockControlRight = new DevExpress.XtraBars.BarDockControl();
            ((System.ComponentModel.ISupportInitialize)diagramControl1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)diagramPropertyGridDockPanel1.PropertyGrid).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dockManager1).BeginInit();
            hideContainerRight.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)barManager1).BeginInit();
            SuspendLayout();
            // 
            // diagramControl1
            // 
            diagramControl1.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            diagramControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            diagramControl1.Location = new System.Drawing.Point(300, 22);
            diagramControl1.Name = "diagramControl1";
            diagramControl1.OptionsBehavior.SelectedStencils = new DevExpress.Diagram.Core.StencilCollection(new string[] { "BasicShapes", "BasicFlowchartShapes" });
            diagramControl1.OptionsView.PaperKind = System.Drawing.Printing.PaperKind.Letter;
            diagramControl1.OptionsView.Theme = DevExpress.Diagram.Core.DiagramThemes.Office;
            diagramControl1.PropertyGrid = diagramPropertyGridDockPanel1;
            diagramControl1.Size = new System.Drawing.Size(1173, 746);
            diagramControl1.TabIndex = 0;
            diagramControl1.Text = "diagramControl1";
            diagramControl1.Toolbox = diagramToolboxDockPanel1;
            diagramControl1.SelectionChanged += diagramControl1_SelectionChanged;
            diagramControl1.CustomGetEditableItemProperties += diagramControl1_CustomGetEditableItemProperties;
            diagramControl1.KeyDown += diagramControl_KeyDown;
            // 
            // diagramPropertyGridDockPanel1
            // 
            diagramPropertyGridDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            diagramPropertyGridDockPanel1.ID = new System.Guid("65d89199-999e-4d84-82b4-0798235eecce");
            diagramPropertyGridDockPanel1.Location = new System.Drawing.Point(0, 0);
            diagramPropertyGridDockPanel1.Name = "diagramPropertyGridDockPanel1";
            diagramPropertyGridDockPanel1.Options.AllowFloating = false;
            diagramPropertyGridDockPanel1.OriginalSize = new System.Drawing.Size(300, 200);
            // 
            // 
            // 
            diagramPropertyGridDockPanel1.PropertyGrid.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            diagramPropertyGridDockPanel1.PropertyGrid.Dock = System.Windows.Forms.DockStyle.Fill;
            diagramPropertyGridDockPanel1.PropertyGrid.Location = new System.Drawing.Point(0, 0);
            diagramPropertyGridDockPanel1.PropertyGrid.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            diagramPropertyGridDockPanel1.PropertyGrid.Name = "propertyGrid";
            diagramPropertyGridDockPanel1.PropertyGrid.OptionsView.AllowReadOnlyRowAppearance = DevExpress.Utils.DefaultBoolean.True;
            diagramPropertyGridDockPanel1.PropertyGrid.OptionsView.MinRowAutoHeight = 11;
            diagramPropertyGridDockPanel1.PropertyGrid.Size = new System.Drawing.Size(200, 100);
            diagramPropertyGridDockPanel1.PropertyGrid.TabIndex = 6;
            diagramPropertyGridDockPanel1.SavedDock = DevExpress.XtraBars.Docking.DockingStyle.Right;
            diagramPropertyGridDockPanel1.SavedIndex = 1;
            diagramPropertyGridDockPanel1.Size = new System.Drawing.Size(300, 788);
            diagramPropertyGridDockPanel1.Visibility = DevExpress.XtraBars.Docking.DockVisibility.AutoHide;
            // 
            // diagramToolboxDockPanel1
            // 
            diagramToolboxDockPanel1.Dock = DevExpress.XtraBars.Docking.DockingStyle.Left;
            diagramToolboxDockPanel1.FloatSize = new System.Drawing.Size(200, 500);
            diagramToolboxDockPanel1.ID = new System.Guid("b417aba3-773e-4b40-a735-f9dbde089ebc");
            diagramToolboxDockPanel1.Location = new System.Drawing.Point(0, 22);
            diagramToolboxDockPanel1.Name = "diagramToolboxDockPanel1";
            diagramToolboxDockPanel1.Options.AllowFloating = false;
            diagramToolboxDockPanel1.OriginalSize = new System.Drawing.Size(300, 200);
            diagramToolboxDockPanel1.Size = new System.Drawing.Size(300, 746);
            // 
            // 
            // 
            diagramToolboxDockPanel1.Toolbox.BorderStyle = DevExpress.XtraEditors.Controls.BorderStyles.NoBorder;
            diagramToolboxDockPanel1.Toolbox.Dock = System.Windows.Forms.DockStyle.Fill;
            diagramToolboxDockPanel1.Toolbox.Location = new System.Drawing.Point(0, 0);
            diagramToolboxDockPanel1.Toolbox.Name = "";
            diagramToolboxDockPanel1.Toolbox.OptionsBehavior.ItemSelectMode = DevExpress.XtraToolbox.ToolboxItemSelectMode.Single;
            diagramToolboxDockPanel1.Toolbox.OptionsView.ItemImageSize = new System.Drawing.Size(32, 32);
            diagramToolboxDockPanel1.Toolbox.OptionsView.ShowToolboxCaption = true;
            diagramToolboxDockPanel1.Toolbox.SelectedGroupIndex = 1;
            diagramToolboxDockPanel1.Toolbox.Size = new System.Drawing.Size(299, 723);
            diagramToolboxDockPanel1.Toolbox.TabIndex = 0;
            // 
            // dockManager1
            // 
            dockManager1.AutoHideContainers.AddRange(new DevExpress.XtraBars.Docking.AutoHideContainer[] { hideContainerRight });
            dockManager1.Form = this;
            dockManager1.MenuManager = barManager1;
            dockManager1.RootPanels.AddRange(new DevExpress.XtraBars.Docking.DockPanel[] { diagramToolboxDockPanel1 });
            dockManager1.Style = DevExpress.XtraBars.Docking2010.Views.DockingViewStyle.Light;
            dockManager1.TopZIndexControls.AddRange(new string[] { "DevExpress.XtraBars.BarDockControl", "DevExpress.XtraBars.StandaloneBarDockControl", "System.Windows.Forms.MenuStrip", "System.Windows.Forms.StatusStrip", "System.Windows.Forms.StatusBar", "DevExpress.XtraBars.Ribbon.RibbonStatusBar", "DevExpress.XtraBars.Ribbon.RibbonControl", "DevExpress.XtraBars.Navigation.OfficeNavigationBar", "DevExpress.XtraBars.Navigation.TileNavPane", "DevExpress.XtraBars.TabFormControl", "DevExpress.XtraBars.FluentDesignSystem.FluentDesignFormControl", "DevExpress.XtraBars.ToolbarForm.ToolbarFormControl" });
            // 
            // hideContainerRight
            // 
            hideContainerRight.BackColor = System.Drawing.Color.FromArgb(240, 240, 240);
            hideContainerRight.Controls.Add(diagramPropertyGridDockPanel1);
            hideContainerRight.Dock = System.Windows.Forms.DockStyle.Right;
            hideContainerRight.Location = new System.Drawing.Point(1473, 22);
            hideContainerRight.Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            hideContainerRight.Name = "hideContainerRight";
            hideContainerRight.Size = new System.Drawing.Size(23, 746);
            // 
            // barManager1
            // 
            barManager1.Bars.AddRange(new DevExpress.XtraBars.Bar[] { bar1, bar3 });
            barManager1.DockControls.Add(barDockControlTop);
            barManager1.DockControls.Add(barDockControlBottom);
            barManager1.DockControls.Add(barDockControlLeft);
            barManager1.DockControls.Add(barDockControlRight);
            barManager1.DockManager = dockManager1;
            barManager1.Form = this;
            barManager1.Items.AddRange(new DevExpress.XtraBars.BarItem[] { barButtonItem1, barButtonItem2, barButtonItem3 });
            barManager1.MaxItemId = 3;
            barManager1.StatusBar = bar3;
            // 
            // bar1
            // 
            bar1.BarName = "Tools";
            bar1.DockCol = 0;
            bar1.DockRow = 0;
            bar1.DockStyle = DevExpress.XtraBars.BarDockStyle.Top;
            bar1.LinksPersistInfo.AddRange(new DevExpress.XtraBars.LinkPersistInfo[] { new DevExpress.XtraBars.LinkPersistInfo(barButtonItem1), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem2), new DevExpress.XtraBars.LinkPersistInfo(barButtonItem3) });
            bar1.Text = "Tools";
            // 
            // barButtonItem1
            // 
            barButtonItem1.Caption = "直线";
            barButtonItem1.Id = 0;
            barButtonItem1.Name = "barButtonItem1";
            barButtonItem1.ItemClick += barButtonItem1_ItemClick;
            // 
            // barButtonItem2
            // 
            barButtonItem2.Caption = "选择";
            barButtonItem2.Id = 1;
            barButtonItem2.Name = "barButtonItem2";
            barButtonItem2.ItemClick += barButtonItem2_ItemClick;
            // 
            // barButtonItem3
            // 
            barButtonItem3.Caption = "显示信息";
            barButtonItem3.Id = 2;
            barButtonItem3.Name = "barButtonItem3";
            barButtonItem3.ItemClick += barButtonItem3_ItemClick;
            // 
            // bar3
            // 
            bar3.BarName = "Status bar";
            bar3.CanDockStyle = DevExpress.XtraBars.BarCanDockStyle.Bottom;
            bar3.DockCol = 0;
            bar3.DockRow = 0;
            bar3.DockStyle = DevExpress.XtraBars.BarDockStyle.Bottom;
            bar3.OptionsBar.AllowQuickCustomization = false;
            bar3.OptionsBar.DrawDragBorder = false;
            bar3.OptionsBar.UseWholeRow = true;
            bar3.Text = "Status bar";
            // 
            // barDockControlTop
            // 
            barDockControlTop.CausesValidation = false;
            barDockControlTop.Dock = System.Windows.Forms.DockStyle.Top;
            barDockControlTop.Location = new System.Drawing.Point(0, 0);
            barDockControlTop.Manager = barManager1;
            barDockControlTop.Size = new System.Drawing.Size(1496, 22);
            // 
            // barDockControlBottom
            // 
            barDockControlBottom.CausesValidation = false;
            barDockControlBottom.Dock = System.Windows.Forms.DockStyle.Bottom;
            barDockControlBottom.Location = new System.Drawing.Point(0, 768);
            barDockControlBottom.Manager = barManager1;
            barDockControlBottom.Size = new System.Drawing.Size(1496, 20);
            // 
            // barDockControlLeft
            // 
            barDockControlLeft.CausesValidation = false;
            barDockControlLeft.Dock = System.Windows.Forms.DockStyle.Left;
            barDockControlLeft.Location = new System.Drawing.Point(0, 22);
            barDockControlLeft.Manager = barManager1;
            barDockControlLeft.Size = new System.Drawing.Size(0, 746);
            // 
            // barDockControlRight
            // 
            barDockControlRight.CausesValidation = false;
            barDockControlRight.Dock = System.Windows.Forms.DockStyle.Right;
            barDockControlRight.Location = new System.Drawing.Point(1496, 22);
            barDockControlRight.Manager = barManager1;
            barDockControlRight.Size = new System.Drawing.Size(0, 746);
            // 
            // Form1
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 14F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(1496, 788);
            Controls.Add(diagramControl1);
            Controls.Add(diagramToolboxDockPanel1);
            Controls.Add(hideContainerRight);
            Controls.Add(barDockControlLeft);
            Controls.Add(barDockControlRight);
            Controls.Add(barDockControlBottom);
            Controls.Add(barDockControlTop);
            Margin = new System.Windows.Forms.Padding(4, 3, 4, 3);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)diagramControl1).EndInit();
            ((System.ComponentModel.ISupportInitialize)diagramPropertyGridDockPanel1.PropertyGrid).EndInit();
            ((System.ComponentModel.ISupportInitialize)dockManager1).EndInit();
            hideContainerRight.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)barManager1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DevExpress.XtraDiagram.DiagramControl diagramControl1;
        private DevExpress.XtraDiagram.Docking.DiagramPropertyGridDockPanel diagramPropertyGridDockPanel1;
        private DevExpress.XtraDiagram.Docking.DiagramToolboxDockPanel diagramToolboxDockPanel1;
        private DevExpress.XtraBars.Docking.DockManager dockManager1;
        private DevExpress.XtraBars.Docking.AutoHideContainer hideContainerRight;
        private DevExpress.XtraBars.BarDockControl barDockControlLeft;
        private DevExpress.XtraBars.BarManager barManager1;
        private DevExpress.XtraBars.Bar bar1;
        private DevExpress.XtraBars.Bar bar3;
        private DevExpress.XtraBars.BarDockControl barDockControlTop;
        private DevExpress.XtraBars.BarDockControl barDockControlBottom;
        private DevExpress.XtraBars.BarDockControl barDockControlRight;
        private DevExpress.XtraBars.BarButtonItem barButtonItem1;
        private DevExpress.XtraBars.BarButtonItem barButtonItem2;
        private DevExpress.XtraBars.BarButtonItem barButtonItem3;
    }
}

