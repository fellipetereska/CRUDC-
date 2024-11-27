using CRUDC_.Classes;
using CRUDC_.Persistencia;
using MySqlX.XDevAPI;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUD.Formularios
{
    public partial class frmClientes : Form
    {

        private Cliente objCliente;

        public frmClientes()
        {
            InitializeComponent();
        }

        public frmClientes(Cliente cliente) : this()
        {
            objCliente = cliente;

            if (objCliente != null && objCliente.IdCliente != 0)
            {
                numIdCliente.Value = objCliente.IdCliente;
                txtNome.Text = objCliente.NomeCliente;
                txtEndereco.Text = objCliente.EnderecoCliente;
                txtBairro.Text = objCliente.BairroCliente;
                txtCpf.Text = objCliente.CpfCliente;
                txtCep.Text = objCliente.CepCliente;
                dtNascimento.Value = objCliente.DtNascimentoCliente;
                numSalario.Value = objCliente.SalarioCliente;

                if (objCliente.SexoCliente == "M")
                    rbMasculino.Checked = true;
                else
                    rbFeminino.Checked = true;

                btnCadastrar.Text = "Alterar";
            }
        }

        private void btnCadastrar_Click_1(object sender, EventArgs e)
        {
            if (objCliente == null)
            {
                objCliente = new Cliente();
            }
            objCliente.IdCliente = Convert.ToInt32(numIdCliente.Value);
            objCliente.NomeCliente = txtNome.Text;
            objCliente.CpfCliente = txtCpf.Text;
            objCliente.CepCliente = txtCep.Text;
            objCliente.EnderecoCliente = txtEndereco.Text;
            objCliente.BairroCliente = txtBairro.Text;
            objCliente.DtNascimentoCliente = dtNascimento.Value;
            objCliente.SalarioCliente = Convert.ToDecimal(numSalario.Value);
            objCliente.SexoCliente = rbMasculino.Checked ? "M" : "F";

            string res;

            if (objCliente.IdCliente != 0)
            {
                res = objCliente.EditarCliente();
                if (string.IsNullOrEmpty(res))
                {
                    MessageBox.Show("Cliente atualizado com sucesso!");
                    Close();
                    return;
                }
            }
            else
            {
                res = objCliente.CadastrarCliente();
                if (string.IsNullOrEmpty(res))
                {
                    MessageBox.Show("Cliente cadastrado com sucesso!");
                    Close();
                    return;
                }
            }

            MessageBox.Show(res);
        }

        private void btnExcluir_Click(object sender, EventArgs e)
        {
            if(numIdCliente.Value == 0)
            {
                MessageBox.Show("Nenhum cliente selecionado!");
                return;
            }

            Cliente objCliente = new Cliente();

            string res = objCliente.DeletarCliente(Convert.ToInt32(numIdCliente.Value));

            if (res == "")
            {
                MessageBox.Show("Cliente deletado com sucesso!");
                Close();
                return;
            }

            MessageBox.Show(res);
            Close();
            return;

        }
    }
}
