using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolCodeGenerator.Logic
{
   public static class ArcCalculator
    {


        public double GetPointAngle()
        {
            // Check if 90 degree values
            if (PointX == CX)
            {
                if (PointY > CY)
                {
                    return 90;
                }
                else
                {
                    return 270;
                }
            }
            else if (PointY == CY)
            {
                if (PointX > CX)
                {
                    return 0;
                }
                else
                {
                    return 180;
                }
            }
            // calculate angle value
            else
            {

                var x = PointX - CX;
                var y = PointY - CY;
                var radians = Math.Atan2(x, y);
                return Math.Abs(radians * (180 / Math.PI)) + AngleToAdd();
            }
        }

        double AngleToAdd()
        {
            double angle = 0;

            if (PointX > CX && PointY > CY)
            {
                angle = 0;
            }
            else if (PointX < CX && PointY > CY)
            {
                angle = 90;
            }

            else if (PointX < CX && PointY < CY)
            {
                return 90;
            }
            else
            {
                angle = 180;
            }
            return angle;

        }
    }
}

