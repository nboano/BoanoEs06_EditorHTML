using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace FileUtils
{
    public class FileUT
    {
        #region CAMPI
        private string filename = null;
        private bool modified;
        #endregion
        #region PROPERTY
        public string FileName {
            set { 
                filename = value; 
            }
            get {
                if (filename == null) filename = $"Nuovo_{DateTime.Now.ToString("s")}.html";
                return filename;
            }
        }
        public string RelativeFileName
        {
            get {
                string s = null;
                if (!string.IsNullOrEmpty(FileName))
                {
                    // s = Path.GetFileName(filename);
                    // OPPURE
                    s = FileName.Substring(FileName.LastIndexOf('\\') + 1);
                }
                return s;
            }
        }
        public bool Modified
        {
            set
            {
                modified = value;
            }
            get
            {
                return modified;
            }
        }
        #endregion
        #region COSTRUTTORE
        public FileUT()
        {

        }
        #endregion
        #region METODI PRIVATI
        private string read()
        {
            if (File.Exists(filename))
            {
                string txt = "";
                using (var sr = new StreamReader(filename))
                {
                    txt = sr.ReadToEnd();
                    sr.Close();
                    Modified = false;
                }
                return txt;
            }
            else throw new Exception("File non esistente / Nome file non valido");
        }
        private void write(string txt)
        {
            if (!string.IsNullOrEmpty(filename))
                using (var sw = new StreamWriter(filename, false))
                {
                    sw.Write(txt);
                    sw.Close();
                    Modified = false;
                }
            else throw new Exception("Nome file non valido");
        }
        #endregion
        #region METODI PUBBLICI
        public string OpenAndRead()
        {
            string txt = null;
            OpenFileDialog dlg = new OpenFileDialog()
            {
                Filter = "Pagina HTML|*.html;*.htm|Tutti i file|*.*",
                Title = "EDITOR HTML - Apri",
                Multiselect = false,
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            DialogResult r = dlg.ShowDialog();
            if(r == DialogResult.OK)
            {
                FileName = dlg.FileName;
                txt = read();
            }
            return txt;
        }
        public void Save(string txt)
        {
            if(FileName.IndexOf('\\') == -1)
                SaveAs(txt);
            else
                write(txt);
        }
        public void SaveAs(string txt)
        {
            SaveFileDialog dlg = new SaveFileDialog()
            {
                Title = "EDITOR HTML - Salva con nome",
                Filter = "Pagina HTML|*.html;*.htm|Tutti i file|*.*",
                InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop),
            };
            DialogResult r = dlg.ShowDialog();
            if(r == DialogResult.OK)
            {
                FileName = dlg.FileName;
                Save(txt);
            }
        }
        #endregion
    }
}
