using System;
using System.Collections.Generic;
using System.Collections.Concurrent;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace miapr_lab1
{
    class Manager
    {
        public event EventHandler<ExDrawEventArgs> Draw;

        protected virtual void OnDraw(ExDrawEventArgs e)
        {
            e.Raise(this, ref Draw);
        }

        public void SimulateDraw(Graphics graphics, Rectangle rect, List<ImageClass> classes)
        {
            ExDrawEventArgs e = new ExDrawEventArgs(graphics,rect, classes);
            OnDraw(e);
        }
        
    }
}
