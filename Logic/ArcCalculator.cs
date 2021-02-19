using SolidWorks.Interop.sldworks;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolCodeGenerator.Logic
{
    public static class ArcCalculator
    {
        /// <summary>
        /// Данные для генерации символа
        /// </summary>
        /// <param name="arc"></param>
        /// <returns>строка с данными</returns>
        public static string GetDataForSymbol(this SketchArc arc)
        {
            // input values
            SketchPoint CenterPoint = (SketchPoint)arc.GetCenterPoint2();
            SketchPoint StartPoint = (SketchPoint)arc.GetStartPoint2();
            SketchPoint EndPoint = (SketchPoint)arc.GetEndPoint2();


            // Output values    
            var arcCX = (Math.Round((CenterPoint.X * 1000), 2)).ToString().Replace(',','.');
            var arcCY = (Math.Round((CenterPoint.Y * 1000), 2)).ToString().Replace(',', '.');
            var arcRadius = (Math.Round((arc.GetRadius() * 1000), 2)).ToString().Replace(',', '.');
            var startAngle = (Math.Round(GetPointAngle(CenterPoint.X, CenterPoint.Y, StartPoint.X, StartPoint.Y), 2)).ToString().Replace(',', '.');
            var endAngle = (Math.Round(GetPointAngle(CenterPoint.X, CenterPoint.Y, EndPoint.X, EndPoint.Y), 2)).ToString().Replace(',', '.');

            if (arc.GetRotationDir() == 1)
            {
                return $"A,Arc, {arcCX},{arcCY},{arcRadius},{startAngle},{endAngle}";
            }
            else
            {
                return $"A,Arc, {arcCX},{arcCY},{arcRadius},{endAngle},{startAngle}";
            }
        }

        private static double GetPointAngle(double CX, double CY, double PointX, double PointY)
        {

            CX = Math.Round(CX * 1000, 2);
            CY = Math.Round(CY * 1000, 2);
            PointX = Math.Round(PointX * 1000, 2);
            PointY = Math.Round(PointY * 1000, 2);

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
                return Math.Abs(radians * (180 / Math.PI)) + AngleToAdd(CX, CY, PointX, PointY);
            }
        }

        private static double AngleToAdd(double CX, double CY, double PointX, double PointY)
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

