using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing;
namespace Diagram_NET
{
    public class NodeInfoShape
    {

        public string Content { get; set; }
        public Color FontColor { get; set; } = Color.Red;
        public float Width { get; set; } = 18;
        public float Height { get; set; } = 20;
        public float CenterX { get; set; }
        public float CenterY { get; set; }
        public float X { get; set; }
        public float Y { get; set; }
    }
}
