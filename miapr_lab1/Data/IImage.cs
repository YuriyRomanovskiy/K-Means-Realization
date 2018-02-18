using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapr_lab1
{
    interface IImage
    {
        int X { get; }
        int Y { get; }
        int Side { get; }
        ImageClass ImgClass { get; set; }
        bool IsCenter { get; }
        void SetCenter();
        void RemoveCenter();
    }
}
