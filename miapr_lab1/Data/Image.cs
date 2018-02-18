using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

namespace miapr_lab1
{
    class Image
    {

        public int X { get; private set; }
        public int Y { get; private set; }
        public int Side { get; private set; }
        public ImageClass ImgClass { get; set; }
        public bool IsCenter { get; private set; }

        public Image(int x, int y, bool isCenter = false)
        {
            X = x;
            Y = y;
            IsCenter = isCenter;
            if (isCenter)
            {
                Side = 3;
            }
            else
            {
                Side = 1;
            }
            //AttrClass = attributeClass;
        }

        public void SetCenter()
        {
            IsCenter = true;
            Side = 3;
        }

        public void RemoveCenter()
        {
            IsCenter = false;
            Side = 1;
        }
        
    }
}
