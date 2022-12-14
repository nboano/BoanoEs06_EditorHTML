//                                                                  💀
using System.Windows.Forms;
using System.Drawing;
using System.Drawing.Printing;
using System;

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

            dlgSetup.EnableMetric = true;

            #endregion
            #region VARIE

            prn.PrinterSettings.Copies = 1;

            #endregion

            dlgSetup.Document = prn;
            dlgPrintPreview.Document = prn;
            dlgPrint.Document = prn;

            prn.PrintPage += Prn_PrintPage;
        }
        #endregion
        #region METODI PRIVATI
        private void Prn_PrintPage(object sender, PrintPageEventArgs e)
        {
            // QUESTO METODO VIENE RICHIAMATO ALL'ESECUZIONE DI PRN.PRINT() e ALL'OK SULL'ANTEPRIMA DI STAMPA

            // Oggetto pennello
            SolidBrush b = new SolidBrush(Color.Black);

            // Coordinate di partenza del testo
            int x = prn.DefaultPageSettings.Margins.Left;
            int y = prn.DefaultPageSettings.Margins.Top;
            int w = prn.DefaultPageSettings.PaperSize.Width;
            int h = prn.DefaultPageSettings.PaperSize.Height;

            //ESEMPIO disegno un rettangolo
            Rectangle rec = new Rectangle(x, y, w, h);

            // METODO CHE ESEGUE FISICAMENTE LA STAMPA
            // Non disegna il rettangolo, ma lo usa come contanitore per il testo.
            e.Graphics.DrawString(userText, userFont, b, rec);

            //Pen penna = new Pen(Color.Red, 2);
            //e.Graphics.DrawRectangle(penna, rec);

            //e.Graphics.Dispose();
        }
        #endregion
        #region METODI PUBBLICI
        public void ImpostaPagina()
        {
            dlgSetup.ShowDialog();
            // IN CORRISPONDENZA DELL'OK I VALORI IMPOSTATI SARANNO COPIATI IN prn
        }
        public void EseguiStampa(string testo, Font carattere)
        {
            userText = testo;
            userFont = carattere;

            // L'utente può decidere se stampare o annullare 😁

            if (dlgPrintPreview.ShowDialog() == DialogResult.OK)
                prn.Print();
        }
        public void Anteprima(string testo, Font carattere)
        {
            userText = testo;
            userFont = carattere;
            dlgPrintPreview.ShowDialog();
        }
        #endregion
    }
}
