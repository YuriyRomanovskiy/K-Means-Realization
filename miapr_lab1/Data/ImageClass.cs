using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapr_lab1
{

    class ImageClass
    {
        public int Identificator { get; private set; }
        public Pen PaintComponent { get; private set; }
        public Pen CenterPaintComponent { get; private set; }
        public Image Center { get; set; }
        public List<Image> Images { get; set; }

        public ImageClass(int r, int g, int b)
        {
            CenterPaintComponent = new Pen(Color.FromArgb(255,0,0,0));
            PaintComponent = new Pen(Color.FromArgb(255, r, g, b));
            this.Identificator++;
        }
        public ImageClass(int color)
        {
            CenterPaintComponent = new Pen(Color.FromArgb(255, 0, 0, 0));
            PaintComponent = new Pen(Color.FromArgb(color));
            this.Identificator++;
        }
        public ImageClass(Color color)
        {
            CenterPaintComponent = new Pen(Color.FromArgb(255, 0, 0, 0));
            PaintComponent = new Pen((color));
            this.Identificator++;
        }

        public Image GetBestClassCenter(bool isTrackingCenters= false)
        {
            var bestCenter = new Image(Convert.ToInt32(this.Images.Average(x => x.X)), Convert.ToInt32(this.Images.Average(x => x.Y)));
            double minDifferent = Double.MaxValue;
            var minDifferentPoint = new Image(0, 0);
            foreach (Image centerCandidate in this.Images)
            {
                if (centerCandidate.IsCenter && !isTrackingCenters)
                {
                    centerCandidate.RemoveCenter();
                }
                double differen = getVectorLength(bestCenter, centerCandidate);
                if (differen < minDifferent)
                {
                    minDifferent = differen;
                    minDifferentPoint = centerCandidate;
                }
            }
            //this.Center = minDifferentPoint;
            minDifferentPoint.SetCenter();
            return minDifferentPoint;
        }
        private int getVectorLength(Image center, Image image)
        {
            return Convert.ToInt32(Math.Sqrt(((center.X - image.X) * (center.X - image.X)) + ((center.Y - image.Y) * (center.Y - image.Y))));
        }

    }
}
