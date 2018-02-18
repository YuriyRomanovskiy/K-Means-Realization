using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace miapr_lab1
{
    public static class InputCheck
    {
        public static int CheckInputField(string input)
        {
            Int32 result = 0;
            if (Int32.TryParse(input, out result))
            {
                return result;
            }
            return 0;
        }

        public static bool CompareCountOfVariables(Int32 images, Int32 classes)
        {
            if ((images <1000)||(classes < 2))
            {
                return false;
            }
            if (images <= classes)
            {
                return false;
            }
            else
            {
                return true;
            }
        } 

    }
}
