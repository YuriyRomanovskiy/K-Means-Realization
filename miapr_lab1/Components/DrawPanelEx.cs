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
        private bool isPainted = false;
        public bool IsPainted { get { return isPainted; } }

        public void OnPaint(object sender, ExDrawEventArgs e)
        {
            isPainted = false;
            this.Refresh();
            Drawer.DrawClasses(e.Classes, e.Graphics);
            Drawer.DrawCenters(e.Classes, e.Graphics);
            isPainted = true;
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
