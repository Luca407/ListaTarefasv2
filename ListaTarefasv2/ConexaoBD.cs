using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ListaTarefasv2
{
    internal class ConexaoBD
    {
        private string conexaoBanco = "Server=localhost; Database=teste; Uid=root; Pwd=;";

        public MySqlConnection Conectar()
        {
            MySqlConnection conexao = new MySqlConnection(conexaoBanco);

            conexao.Open();
            return conexao;
        }
    }
}
