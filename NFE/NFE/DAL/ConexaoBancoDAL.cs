using MySql.Data.MySqlClient;
using System;

namespace NFE.DAL
{
    class InformacoesConexao
    {

        public static MySqlConnection GetDBConnection(string host, int port, string database, string username, string password)
        {
            // Connection String.
            String connectionstring = "Server=" + host + ";Database=" + database
                + ";port=" + port + ";User Id=" + username + ";password=" + password;

            MySqlConnection conexao = new MySqlConnection(connectionstring);
            return conexao;
        }
    }
}