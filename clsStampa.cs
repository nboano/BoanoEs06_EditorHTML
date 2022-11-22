using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;

namespace BoanoEs06_EditorHTML
{
    public class Stampa
    {
        #region CAMPI
        private PrintDocument prn = new PrintDocument();
        private PageSetupDialog dlgSetup = new PageSetupDialog();
        private PrintDialog dlgPrint = new PrintDialog();
        private PrintPreviewDialog dlgPrintPreview = new PrintPreviewDialog();
        private string userText;
        private Font userFont;
        #endregion
        #region COSTRUTTORE
        public Stampa()
        {
            // IMPOSTO PARAMETRI DI DEFAULT

            #region MARGINI

            prn.DefaultPageSettings.Margins.Left = 79; // 79 * 0.254mm
            prn.DefaultPageSettings.Margins.Right = 79;

            prn.DefaultPageSettings.Margins.Top = 100;
            prn.DefaultPageSettings.Margins.Bottom = 100;

            #endregion
            #region VARIE

            prn.PrinterSettings.Copies = 1;

            #endregion

            dlgSetup.Document = prn;
            dlgPrintPreview.Document = prn;
            dlgPrint.Document = prn;
        }
        #endregion
    }
}
