using CRUD.Formularios;
using CRUDC_.Classes;
using CRUDC_.Persistencia;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDC_.Grids
{
    public partial class gridClientes : Form
    {
        public gridClientes()
        {
            InitializeComponent();
        }

        private void gridClientes_Load(object sender, EventArgs e)
        {
            AtualizarDataGrid();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            frmClientes formCliente = new frmClientes();
            formCliente.ShowDialog();
            AtualizarDataGrid();
        }

        private void FormCliente_FormClosed(object sender, FormClosedEventArgs e)
        {
            AtualizarDataGrid();
        }

        private void AtualizarDataGrid()
        {
            Cliente objCliente = new Cliente();
            DataTable tblRetorno = objCliente.ListarClientes();
            dtgClientes.DataSource = tblRetorno;
        }

        private void dtgClientes_CellClick(object sender, DataGridViewCellEventArgs e)
        {
           

        }

        private void dtgClientes_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = dtgClientes.Rows[e.RowIndex];
                if (row.Cells["idCliente"].Value == null || string.IsNullOrWhiteSpace(row.Cells["idCliente"].Value.ToString()))
                {
                    MessageBox.Show("Selecione um cliente válido!");
                    return;
                }

                Cliente objCliente = new Cliente
                {
                    IdCliente = Convert.ToInt32(row.Cells["idCliente"].Value),
                    NomeCliente = row.Cells["nomeCliente"].Value.ToString(),
                    EnderecoCliente = row.Cells["EnderecoCliente"].Value.ToString(),
                    BairroCliente = row.Cells["bairroCliente"].Value.ToString(),
                    CepCliente = row.Cells["cepCliente"].Value.ToString(),
                    CpfCliente = row.Cells["cpfCliente"].Value.ToString(),
                    DtNascimentoCliente = Convert.ToDateTime(row.Cells["dtNascimentoCliente"].Value),
                    SalarioCliente = Convert.ToDecimal(row.Cells["salarioCliente"].Value),
                    SexoCliente = row.Cells["sexoCliente"].Value.ToString()
                };

                frmClientes formCliente = new frmClientes(objCliente);
                formCliente.FormClosed += FormCliente_FormClosed;
                formCliente.ShowDialog();
            }
        }
    }
}
