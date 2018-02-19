using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapr_lab1
{
    interface IImageClass
    {
        int Identificator { get; }
        Pen PaintComponent { get; }
        Pen CenterPaintComponent { get;}
        Image Center { get; set; }
        List<Image> Images { get; set; }
        Image GetBestClassCenter(bool isTrackingCenters = false);
    }
}
