using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AcessoBanco;
using AcessoBanco.Conexao;
namespace AcessoBanco.Conexao
{
    class Conexao
    {
        public bool VerificaAcessoBanco()
        {
            try
            {
                AcessoBanco.Entidades entidade = new AcessoBanco.Entidades();
                AcessoBanco.Conexao.Conexao conexao = new AcessoBanco.Conexao.Conexao();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();

                Console.WriteLine("Conectando...");
                conectar.Open();
                Console.WriteLine("Conexão feita com sucesso!");
                return true;
            }
            catch (Exception)
            {
                Console.WriteLine("Conexão com algum problema!");
                return false;
            }
        }
        public bool VerificaAcesso(string login, string senha)
        {
            try
            {
                AcessoBanco.Entidades entidade = new AcessoBanco.Entidades();
                entidade.Login = login;
                entidade.Senha = senha;
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;                

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "SELECT (login,senha,dataCriacao,dataModificacao,ultimoAcesso, ativo) FROM USUARIO(@login,@senha,@dataCriacao,@dataModificacao,@ultimoAcesso,@ativo)";
                cmd.ExecuteNonQuery();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool Inserir(string login, string senha, string dataCriacao, string dataModificao, string ultimoAcesso, int ativo)
        {
            try
            {
                AcessoBanco.Entidades entidade = new AcessoBanco.Entidades();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "INSERT INTO USUARIO(login,senha,dataCriacao,dataModificacao,ultimoAcesso,)VALUES(@login,@senha,@dataCriacao,@dataModificacao,@ultimoAcesso,@ativo)";
                cmd.Parameters.AddWithValue("@login", entidade.Login);
                cmd.Parameters.AddWithValue("@senha", entidade.Senha);
                cmd.Parameters.AddWithValue("@dataCriacao", entidade.DataCriacao);
                cmd.Parameters.AddWithValue("@dataModificacao", entidade.DataModificacao);
                cmd.Parameters.AddWithValue("@ultimoAcesso", entidade.UltimoAcesso);
                cmd.Parameters.AddWithValue("@ativo", entidade.Ativo);
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool Atualizar(string login, string senha, string dataModificacao)
        {
            try
            {
                AcessoBanco.Entidades entidade = new AcessoBanco.Entidades();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "INSERT INTO USUARIO(login,senha, dataModificacao)VALUES(@login,@senha,@dataModificacao)";
                cmd.Parameters.AddWithValue("@login", entidade.Login);
                cmd.Parameters.AddWithValue("@senha", entidade.Senha);
                cmd.Parameters.AddWithValue("@dataModificacao", entidade.DataModificacao);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }

        public bool Excluir(string login, string senha, string dataCriacao, string dataModificao, string ultimoAcesso, int ativo)
        {
            try
            {
                AcessoBanco.Entidades entidade = new AcessoBanco.Entidades();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "DELETE INTO USUARIO(login,senha,dataCriacao,dataModificacao,ultimoAcesso,ativo)VALUES(@login,@senha,@dataCriacao,@dataModificacao,@ultimoAcesso,@ativo)";
                cmd.Parameters.Remove("@login");
                cmd.Parameters.Remove("@senha");
                cmd.Parameters.Remove("@dataCriacao");
                cmd.Parameters.Remove("@dataModificacao");
                cmd.Parameters.Remove("@ultimoAcesso");
                cmd.Parameters.Remove("@ativo");
                cmd.ExecuteNonQuery();
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
    }
}
