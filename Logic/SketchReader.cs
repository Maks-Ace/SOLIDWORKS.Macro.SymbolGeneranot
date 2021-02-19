using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace SymbolCodeGenerator.Logic
{
    public class SketchReader
    {

        public SketchReader(SldWorks swApp)
        {
            this.swApp = swApp;
        }


        public string GenerateCodeForSymbol()
        {
            ModelDoc2 swModel;
            Sketch swSketch;
            nfi.NumberDecimalSeparator = ".";
            List<string> elementsOfSketch = new List<string>();

            swModel = (ModelDoc2)swApp.ActiveDoc;
            swSketch = (Sketch)swModel.GetActiveSketch2();
            swModel.ClearSelection2(true);


            // Gel all segments
            object[] segments = (object[])swSketch.GetSketchSegments();


            foreach (SketchSegment segment in segments)
            {
                switch (segment.GetType())
                {
                    case (int)swSketchSegments_e.swSketchARC:
                        SketchArc arc = (SketchArc)segment;
                        if (arc.IsCircle() == 1)
                        {
                            SketchPoint centerPoint = (SketchPoint)arc.GetCenterPoint2();
                            string cx = (centerPoint.X * 1000).ToString(nfi);
                            string cy = (centerPoint.Y * 1000).ToString(nfi);

                            var radius = (Math.Round(arc.GetRadius() * 1000, 2)).ToString(nfi);

                            string circleString = $"A,CIRCLE {cx}, {cy}, {radius}";
                            elementsOfSketch.Add(circleString);
                        }
                        else
                        {
                            string arcString = arc.GetDataForSymbol();

                            // output parametrs A,ARC XC,YC,radius,starsAngle,endEngle
                            elementsOfSketch.Add(arcString);
                        }
                        break;

                    case (int)swSketchSegments_e.swSketchLINE:
                        if (!segment.ConstructionGeometry)
                        {
                        SketchLine line = (SketchLine) segment;
                        SketchPoint startPoint = (SketchPoint) line.GetStartPoint2();
                        SketchPoint endPoint = (SketchPoint)line.GetEndPoint2();

                        string x1 = (Math.Round((startPoint.X * 1000),2)).ToString(nfi);
                        string y1 = (Math.Round((startPoint.Y * 1000),2)).ToString(nfi);
                        string x2 = (Math.Round((endPoint.X * 1000),2)).ToString(nfi);
                        string y2 = (Math.Round((endPoint.Y * 1000),2).ToString(nfi));

                        string lineString = $"A,LINE {x1},{y1},{x2},{y2}";
                        elementsOfSketch.Add(lineString);
                        }

                        break;

                }
                
            }
            string allElementsCode = "";
            foreach (var line in elementsOfSketch)
            {
                allElementsCode += line + "\r\n";
            }

            return allElementsCode;

        }

        // -- Properties and fields
        NumberFormatInfo nfi = new CultureInfo("en-US", false).NumberFormat;
        SldWorks swApp;

    }
}
