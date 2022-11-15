using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FileUtils;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Runtime.CompilerServices;
using System.Diagnostics;

namespace BoanoEs06_EditorHTML
{
    public partial class frmMain : Form
    {
        FileUT f = new FileUT();
        const string DEF_TXT = "<html>\n\t<head>\n\t\t<title>Nuova pagina</title>\n\t</head>\n\t<body>\n\t\t<!-- Inserisci il tuo codice -->\n\t</body>\n</html>";
        public frmMain()
        {
            InitializeComponent();
        }
        private void frmMain_Load(object sender, EventArgs e)
        {
            Text = $"{f.RelativeFileName} - Editor HTML";
            f.Modified = false;
            txt.Text = DEF_TXT;
        }
        #region METODI GEST HTML
        private void nuovo()
        {
            bool annulla = false;
            if (f.Modified)
            {
                // CHIEDO SE SI VUOLE SALVARE IL DOCUMENTO
                DialogResult r = MessageBox.Show($"Salvare le modifiche a {f.FileName}?", "Editor HTML", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Question);
                if (r == DialogResult.Yes) f.Save(txt.Text);
                else if (r == DialogResult.Cancel) annulla = true;
            }
            if (!annulla)
            {
                f.FileName = null;
                // PULISCO TEXTBOX
                txt.Text = DEF_TXT;
                Text = $"{f.RelativeFileName} - Editor HTML";
                f.Modified = false;
            }
        }
        private void apri()
        {
            nuovoToolStripMenuItem.PerformClick();
            txt.Text = f.OpenAndRead();
            Text = $"{f.RelativeFileName} - Editor HTML";
            f.Modified = false;
        }
        private void salva()
        {
            f.Save(txt.Text);
            f.Modified = false;
            Text = $"{f.RelativeFileName} - Editor HTML";
        }
        private void salvaconnome()
        {
            f.SaveAs(txt.Text);
            f.Modified = false;
            Text = $"{f.RelativeFileName} - Editor HTML";
        }
        #endregion
        private void nuovoToolStripMenuItem_Click(object sender, EventArgs e) => nuovo();
        private void nuovoToolStripButton_Click(object sender, EventArgs e) => nuovo();
        private void apriToolStripMenuItem_Click(object sender, EventArgs e) => apri();
        private void apriToolStripButton_Click(object sender, EventArgs e) => apri();
        private void salvaToolStripMenuItem_Click(object sender, EventArgs e) => salva();
        private void salvaToolStripButton_Click(object sender, EventArgs e) => salva();
        private void salvaconnomeToolStripMenuItem_Click(object sender, EventArgs e) => salvaconnome();
        private void frmMain_FormClosing(object sender, FormClosingEventArgs e) => nuovo();
        private void esciToolStripMenuItem_Click(object sender, EventArgs e) => Close();
        private void incollaToolStripButton_Click(object sender, EventArgs e) => txt.Paste();
        private void copiaToolStripMenuItem_Click(object sender, EventArgs e) => txt.Copy();
        private void tagliaToolStripMenuItem_Click(object sender, EventArgs e) => txt.Cut();
        private void incollaToolStripMenuItem_Click(object sender, EventArgs e) => txt.Paste();
        private void annullaToolStripMenuItem_Click(object sender, EventArgs e) => txt.Undo();
        private void ripristinaToolStripMenuItem_Click(object sender, EventArgs e) => txt.Redo();
        private void copiaToolStripButton_Click(object sender, EventArgs e) => txt.Copy();
        private void tagliaToolStripButton_Click(object sender, EventArgs e) => txt.Cut();
        private void informazionisuToolStripMenuItem_Click(object sender, EventArgs e) => new AboutBoxEditor().ShowDialog();
        private void ToolStripButton_Click(object sender, EventArgs e) => new AboutBoxEditor().ShowDialog();
        private void annullaToolStripButton_Click(object sender, EventArgs e) => txt.Undo();
        private void redoToolStripButton_Click(object sender, EventArgs e) => txt.Redo();
        private void txt_TextChanged(object sender, FastColoredTextBoxNS.TextChangedEventArgs e)
        {
            f.Modified = true;
            if (Text[0] != '*') Text = "* - " + Text;
            anteprima.DocumentText = txt.Text;
        }

        private void toolStripButtonInserisciTAG_Click(object sender, EventArgs e) => inseriscitag("p");
        private void inseriscitag(string tagname)
        {
            string tagstart = $"<{tagname}>";
            string tagend = $"</{tagname}>";
            int sel = txt.SelectionStart;
            int l;
            switch (tagname)
            {
                case "img":
                case "audio":
                case "video":
                case "embed":
                    string flt = "Tutti i file|*.*";
                    switch (tagname)
                    {
                        case "img":
                            flt = "File immagine|*.jpg;*.jpeg;*.png;*.gif;*.heic";
                            break;
                        case "audio":
                            flt = "File audio|*.mp3;*.m4a;*.wav;*.flac;*.ogg;*.weba";
                            break;
                        case "video":
                            flt = "File video|*.mpg;*.avi;*.mov;*.mp2;*.mp4;*.webm";
                            break;
                    }
                    var ofd = new OpenFileDialog()
                    {
                        Filter = flt,
                        Title = "Seleziona file...",
                        Multiselect = false,
                    };
                    string fpath = "";
                    if (ofd.ShowDialog() == DialogResult.OK) fpath = ofd.FileName;
                    tagstart = $"<{tagname} src=\"{fpath}\"/>";
                    tagend = "";
                    l = tagname.Length + 7;
                    break;
                case "a":
                    tagstart = $"<{tagname} href=\"\"/>";
                    l = tagname.Length + 8;
                    break;
                case "table":
                    var frmTabella = new frmTabella();
                    frmTabella.ShowDialog();
                    tagstart = "<table border=\"1\">\n";
                    for (int i = 0; i < frmTabella.Righe; i++)
                    {
                        tagstart += "\t\t\t<tr>\n";
                        for (int j = 0; j < frmTabella.Colonne; j++)
                        {
                            tagstart += "\t\t\t\t<td></td>\n";
                        }
                        tagstart += "\t\t\t</tr>\n";
                    }
                    tagstart += "\t\t</table>";
                    tagend = "";
                    l = 18;
                    break;
                case "form":
                    tagstart = "<form action=\"\" method=\"GET\">\n\t\t\t<button type=\"submit\"></button>\n";
                    tagend = "\t\t</form>";
                    l = 14;
                    break;
                case "br":
                case "hr":
                    tagstart = $"<{tagname} />";
                    l = tagstart.Length;
                    break;
                default:
                    tagstart = $"<{tagname}>";
                    tagend = $"</{tagname}>";
                    l = tagstart.Length;
                    break;
            }
            txt.Text = txt.Text.Insert(sel, tagstart + tagend);
            txt.SelectionStart = sel + l;
        }

        private void txt_PreviewKeyDown(object sender, PreviewKeyDownEventArgs e)
        {
            if (e.KeyData == Keys.Tab)
            {
                string s = "";
                int i = txt.SelectionStart - 1;
                while (txt.Text[i] != ' ' && txt.Text[i] != '\r' && txt.Text[i] != '\n' && txt.Text[i] != '\t' && txt.Text[i] != '<' && txt.Text[i] != '>')
                {
                    s = txt.Text[i] + s;
                    SendKeys.SendWait("{BACKSPACE}");
                    i--;
                }
                if (s != "" && s.IndexOf(' ') == -1)
                {
                    inseriscitag(s);
                };
            }
        }

        private void h1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if ((sender as ToolStripMenuItem).Text != null)
                inseriscitag((sender as ToolStripMenuItem).Text);
        }

        private void btnAnteprimaBrowser_Click(object sender, EventArgs e)
        {
            salva();
            Process.Start(f.FileName);
        }

        private void anteprimadistampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anteprima.ShowPrintPreviewDialog();
        }

        private void stampaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            anteprima.ShowPrintDialog();
        }

        private void stampaToolStripButton_Click(object sender, EventArgs e)
        {
            anteprima.ShowPrintDialog();
        }
        private void selezionatuttoToolStripMenuItem_Click(object sender, EventArgs e) => txt.SelectAll();
    }
}
