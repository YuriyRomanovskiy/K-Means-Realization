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
    class Drawer
    {

        public static void DrawList(List<Image> images, Graphics g)
        {
            
            foreach (Image item in images)
            {
                if (item.ImgClass != null)
                {
                    if (!item.IsCenter)
                        g.DrawRectangle(item.ImgClass.PaintComponent, new Rectangle(item.X, item.Y, item.Side, item.Side));
                    else g.DrawRectangle(item.ImgClass.CenterPaintComponent, new Rectangle(item.X, item.Y, item.Side, item.Side));

                }
            }
        }
        public static void DrawClasses(List<ImageClass> classes, Graphics g)
        {
            foreach (ImageClass imageClass in classes)
            {
                foreach(Image image in imageClass.Images)
                {
                    if (!image.IsCenter)
                        g.DrawRectangle(image.ImgClass.PaintComponent, new Rectangle(image.X, image.Y, image.Side, image.Side));
                    else g.DrawRectangle(image.ImgClass.CenterPaintComponent, new Rectangle(image.X, image.Y, image.Side, image.Side));

                }
            }
        }

        public static void DrawCenters(List<ImageClass> classes, Graphics g)
        {
            foreach (ImageClass item in classes)
            {
                g.DrawRectangle(item.CenterPaintComponent, new Rectangle(item.Center.X, item.Center.Y,3, 3));
            }
        }
    }
}
