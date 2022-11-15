using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace BoanoEs06_EditorHTML
{
    public partial class frmTabella : Form
    {
        public frmTabella()
        {
            InitializeComponent();
        }
        public int Righe {
            get => int.Parse(nudRighe.Value.ToString());
        }
        public int Colonne
        {
            get => int.Parse(nudColonne.Value.ToString());
        }
        private void btnEsci_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
