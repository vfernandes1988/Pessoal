using MySql.Data.MySqlClient;

namespace AcessoBanco
{
    class ParametrosConexao
    {
        public static MySqlConnection DadosConexao()
        {
            string host = "127.0.0.1";
            int port = 3306;
            string database = "dados";
            string username = "root";
            string password = "root";

            return InformacoesConexao.GetDBConnection(host, port, database, username, password);
        }

    }
}