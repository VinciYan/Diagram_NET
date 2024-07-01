using DevExpress.Utils.Serializing;
using DevExpress.XtraDiagram;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Diagram_NET
{
    public class DiagramShapeEx : DiagramShape
    {
        [XtraSerializableProperty, Category("自定义"), DisplayName("数据库对象ID")]
        public int DatabaseObjectID { get; set; }
        static DiagramShapeEx()
        {
            DiagramControl.ItemTypeRegistrator.Register(typeof(DiagramShapeEx));
        }
    }
}
