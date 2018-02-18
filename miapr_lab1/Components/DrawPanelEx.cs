using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Drawing;

namespace miapr_lab1
{
    class DrawPanelEx: Panel
    {

        public void PaintObjects()
        {
            
        }
        public void OnPaint(object sender, ExDrawEventArgs e)
        {
            this.Refresh();
            Drawer.DrawClasses(e.Classes, e.Graphics);
            Drawer.DrawCenters(e.Classes, e.Graphics);
        }

        public void Register(Manager m)
        {
            m.Draw += OnPaint;
        }
        public void Unregister(Manager m)
        {
            m.Draw -= OnPaint;
        }
    }
}
