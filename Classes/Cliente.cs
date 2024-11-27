using CRUDC_.Persistencia;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CRUDC_.Classes
{
    public class Cliente
    {
        private int idCliente;
        private string nomeCliente;
        private string cpfCliente;
        private string cepCliente;
        private string enderecoCliente;
        private string bairroCliente;
        private DateTime dtNascimentoCliente;
        private decimal salarioCliente;
        private string sexoCliente;

        public int IdCliente { get => idCliente; set => idCliente = value; }
        public string NomeCliente { get => nomeCliente; set => nomeCliente = value; }
        public string CpfCliente { get => cpfCliente; set => cpfCliente = value; }
        public string CepCliente { get => cepCliente; set => cepCliente = value; }
        public string EnderecoCliente { get => enderecoCliente; set => enderecoCliente = value; }
        public string BairroCliente { get => bairroCliente; set => bairroCliente = value; }
        public DateTime DtNascimentoCliente { get => dtNascimentoCliente; set => dtNascimentoCliente = value; }
        public decimal SalarioCliente { get => salarioCliente; set => salarioCliente = value; }
        public string SexoCliente { get => sexoCliente; set => sexoCliente = value; }

        public DataTable ListarClientes()
        {
            string cmdGet = "SELECT * FROM clientes";

            ConexaoDB conn = new ConexaoDB();

            DataTable tblRetorno = new DataTable();

            tblRetorno = conn.BuscarDados(cmdGet);

            return tblRetorno;
        }

        public string CadastrarCliente()
        {
            string cmdInsert;

            cmdInsert = "INSERT INTO clientes(" +
                        "nomeCliente, enderecoCliente, bairroCliente, cepCliente, cpfCliente, dtNascimentoCliente, salarioCliente, sexoCliente)" +
                        "VALUES('" + NomeCliente + "','" + EnderecoCliente + "','" + BairroCliente + "','" + CepCliente + "','" +
                        CpfCliente + "','" + DtNascimentoCliente.ToString("yyyy/MM/dd") + "','" + SalarioCliente.ToString().Replace(",", ".") + "','" + 
                        SexoCliente + "');";

            ConexaoDB conn = new ConexaoDB();
            var res = conn.ExecutarComando(cmdInsert);

            if (res == "")
            {
                return "";
            }
            else
            {
                return res;
            }
        }

        public string EditarCliente()
        {
            string cmdUpdate;

            cmdUpdate = $"UPDATE clientes " +
                        $"SET " +
                        $"nomeCliente = '{NomeCliente}', " +
                        $"enderecoCliente = '{EnderecoCliente}', " +
                        $"bairroCliente = '{BairroCliente}', " +
                        $"cepCliente = '{CepCliente}', " +
                        $"cpfCliente = '{CpfCliente}', " +
                        $"dtNascimentoCliente = '{DtNascimentoCliente.ToString("yyyy/MM/dd")}', " +
                        $"salarioCliente = '{SalarioCliente.ToString().Replace(",", ".")}', " +
                        $"sexoCliente = '{SexoCliente}' " +
                        $"WHERE idCliente = {IdCliente};";

            ConexaoDB conn = new ConexaoDB();
            var res = conn.ExecutarComando(cmdUpdate);

            if (res == "")
            {
                return "";
            }
            else
            {
                return res;
            }
        }

        public string DeletarCliente(int id)
        {
            string cmdDelete;

            cmdDelete = $"DELETE FROM clientes " +
                        $"WHERE idCliente = {id};";

            ConexaoDB conn = new ConexaoDB();
            var res = conn.ExecutarComando(cmdDelete);

            if (res == "")
            {
                return "";
            }
            else
            {
                return res;
            }
        }
    }
}
