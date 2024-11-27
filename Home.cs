using CRUDC_.Grids;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDC_
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void clientesToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            gridClientes grdClientes = new gridClientes();
            grdClientes.ShowDialog();
        }
    }
}
