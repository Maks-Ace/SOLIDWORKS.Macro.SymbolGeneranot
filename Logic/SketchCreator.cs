using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SymbolCodeGenerator
{
    public class SketchCreator
    {
        public SketchCreator(SldWorks swApp)
        {
            this.swApp = swApp;
        }

        public void CreateSketchForSymbol()
        {

            // variables predefenition
            ModelDoc2 swDoc;
            bool boolStatus = false;
            string swTemplateName;
            SketchSegment skSegment = null;

            swTemplateName = swApp.GetUserPreferenceStringValue((int)(swUserPreferenceStringValue_e.swDefaultTemplatePart));

            // create new document
            swDoc = (ModelDoc2)swApp.NewDocument(swTemplateName, 0, 0, 0);

            // Set preferences
            swApp.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swSketchSnapsGrid)), true);
            swApp.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed)), true);
            swApp.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swSketchSnapToGridIfDisplayed)), true);
            boolStatus = swDoc.Extension.SetUserPreferenceToggle(((int)(swUserPreferenceToggle_e.swGridDisplay)), 0, true);
            boolStatus = swDoc.Extension.SetUserPreferenceDouble(((int)(swUserPreferenceDoubleValue_e.swGridMajorSpacing)), 0, 0.0010000000000);


            // Create sketch and prepare drawing field
            // select front plane
            swDoc.SketchManager.AddToDB = true;
            swDoc.SketchManager.InsertSketch(true);
            swDoc.ClearSelection2(true);

            //Isnert lines
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCenterLine(0.000000, 0.000000, 0.000000, 0.00100, 0.00000, 0.000000)));
            swDoc.SketchAddConstraints("sgFIXED");
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCenterLine(0.000000, 0.000000, 0.000000, 0.0000, 0.00100, 0.000000)));
            swDoc.SketchAddConstraints("sgFIXED");
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCenterLine(0.00100, 0.000000, 0.000000, 0.00100, 0.00100, 0.000000)));
            swDoc.SketchAddConstraints("sgFIXED");
            skSegment = ((SketchSegment)(swDoc.SketchManager.CreateCenterLine(0.0, 0.00100, 0.000000, 0.00100, 0.00100, 0.000000)));
            swDoc.SketchAddConstraints("sgFIXED");

            // Show in front, zoom to fit, clear selection
            swDoc.ShowNamedView2("*Front", 1);
            swDoc.ViewZoomtofit2();
            swDoc.ClearSelection2(true);

            swDoc.SketchManager.AddToDB = false;
        }

        SldWorks swApp;
    }
}
