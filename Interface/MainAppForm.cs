using SolidWorks.Interop.sldworks;
using SymbolCodeGenerator.Logic;
using System;
using System.Diagnostics;
using System.Windows.Forms;
using SolidWorks.Interop.swconst;

namespace SymbolCodeGenerator
{
    public partial class SymbolGenFrm : Form
    {
        // -- Fields and properties

        private SldWorks swApp;

        public SymbolGenFrm(SldWorks swApp)
        {
            InitializeComponent();
            this.swApp = (SldWorks)swApp;
        }

        private void SymbolGenFrm_Load(object sender, EventArgs e)
        {

        }

        private void BeginCreationCmd_Click(object sender, EventArgs e)
        {
            SketchCreator SymbolSketch = new SketchCreator(swApp);
            SymbolSketch.CreateSketchForSymbol();

            Application.Exit();
        }

        private void GeneraCodeCmd_Click(object sender, EventArgs e)
        {
            SymbolCodeText.Text = "";
            SketchReader SymbolCode = new SketchReader(swApp);
            SymbolCodeText.Text = SymbolCode.GenerateCodeForSymbol();
        }



        private void ExitCmd_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void openSymFileCmd_Click(object sender, EventArgs e)
        {
            // Get directory of custom symbols files from settings and open it with 
            // temp file adress 
            var adress = swApp.GetUserPreferenceStringValue((int)swUserPreferenceStringValue_e.swFileLocationsSymbolLibraryFolder) + "\\gtol.sym";
            var fileOpener = new Process();
            fileOpener.StartInfo.FileName = "notepad.exe";
            fileOpener.StartInfo.Arguments = "\"" + adress + "\"";
            fileOpener.Start();
        }

    }

}
