using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace CRUDC_.Persistencia
{
    internal class ConexaoDB
    {
        private MySqlConnection conn;
        private MySqlCommand comando;

        public ConexaoDB()
        {
            MySqlConnection conn = new MySqlConnection("server=localhost;port=3306;database=db_aulas;uid=root;pwd=fte3009");
            conn.Open();
            comando = conn.CreateCommand();
        }

        public string ExecutarComando(string pComando)
        {
            comando.CommandText = pComando;

            comando.ExecuteNonQuery();

            return "";
        }

        public DataTable BuscarDados(string pComando)
        {
            comando.CommandText = pComando;

            DataTable tblRetorno = new DataTable();

            tblRetorno.Load(comando.ExecuteReader());

            return tblRetorno;
        }
    }
}
