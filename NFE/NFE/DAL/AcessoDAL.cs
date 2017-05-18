using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NFE.DAL
{
    class AcessoUsuario
    {
        public bool VerificaAcesso(string usuario, string senha)
        {
            Entidades.Autenticacao entidade = new Entidades.Autenticacao();
            MySqlConnection conectar = ParametrosConexao.DadosConexao();
            MySqlCommand cmd;
            try
            {
                conectar.Open();
                cmd = conectar.CreateCommand();
                string query = $"SELECT usuario,senha FROM administrador WHERE usuario = '{usuario}' and senha = '{senha}'";
                cmd.CommandText = query;
                cmd.ExecuteNonQuery();
                cmd.Parameters.AddWithValue("@usuario", usuario);
                cmd.Parameters.AddWithValue("@senha", senha);
                MySqlDataReader leitor = cmd.ExecuteReader();
                if (leitor.HasRows)
                {
                    leitor.Read();
                    Console.WriteLine("USUARIO VALIDO");
                    return true;
                }
                Console.WriteLine("USUÁRIO INVALIDO");
                return false;
            }
            catch
            {
                return false;
            }
        }
    }
}
