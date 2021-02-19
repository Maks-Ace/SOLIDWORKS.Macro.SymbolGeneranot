using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Forms;

using SolidWorks.Interop.sldworks;
using SolidWorks.Interop.swconst;


namespace SymbolCodeGenerator
{
    public partial class SymbolGeneratorApp
    {
        public void Main()
        {
            Application.Run(new SymbolGenFrm(swApp));

            return;
        }

        // The SldWorks swApp variable is pre-assigned for you.
        public SldWorks swApp;

    }
}

