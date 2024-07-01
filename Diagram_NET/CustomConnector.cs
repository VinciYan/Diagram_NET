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
    public class CustomConnector : DiagramConnector, IShape
    {
        public CustomConnector()
        {

        }
        [XtraSerializableProperty, Category("边信息"), DisplayName("边编号")]
        public int Id { get; set; }
        [XtraSerializableProperty, Category("边信息"), DisplayName("权值")]
        public int WeightVal { get; set; }

        [XtraSerializableProperty, Category("边信息"), DisplayName("头部节点编号")]
        public int BeginNodeNo { get; set; }


        [XtraSerializableProperty, Category("边信息"), DisplayName("尾部节点编号")]
        public int EndNodeNo { get; set; }
        static CustomConnector()
        {
            DiagramControl.ItemTypeRegistrator.Register(typeof(CustomConnector));
        }
    }
}
