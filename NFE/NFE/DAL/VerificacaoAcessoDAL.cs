using MySql.Data.MySqlClient;
using System;

namespace NFE.DAL
{
    class VerificacaoAcessoDAL
    {
        public bool VerificaAcessoBanco()
        {
            try
            {
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                Console.WriteLine("Conectando...");
                conectar.Open();
                Console.WriteLine("Conexão feita com sucesso ao Banco de Dados!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Conexão com o Banco de Dados com algum problema!");
                return false;
            }
        }
    }
}
