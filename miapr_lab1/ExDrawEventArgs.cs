using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using System.Windows.Forms;

namespace miapr_lab1
{
    class ExDrawEventArgs: PaintEventArgs
    {
        private readonly List<ImageClass> classes;

        public ExDrawEventArgs(Graphics graphics, Rectangle clipRect, List<ImageClass> classes) : base(graphics, clipRect)
        {
            this.classes = classes;
        }
        
        public List<ImageClass> Classes { get { return classes; } }
    }
}
