using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;

namespace NFE.DAL
{
    class TransacaoBancoDAL
    {
        public bool VerificaArquivo(string nomeArquivo, DateTime dataArquivo)
        {
            Entidades.Autenticacao entidade = new Entidades.Autenticacao();
            MySqlConnection conectar = ParametrosConexao.DadosConexao();
            MySqlCommand cmd;
            conectar.Open();
            cmd = conectar.CreateCommand();
            string query = $"SELECT nomearquivo,dataarquivo FROM nfeentrada WHERE nomearquivo = '{nomeArquivo}'";
            cmd.CommandText = query;
            cmd.ExecuteNonQuery();
            cmd.Parameters.AddWithValue("@nomearquivo", nomeArquivo);
            MySqlDataReader leitor = cmd.ExecuteReader();
            if (leitor.HasRows)
            {
                leitor.Read();
                Console.WriteLine("Arquivo já Cadastrado !");
                return true;
            }
            return false;
        }
        public bool InsereArquivo(string nomeArquivo, DateTime dataArquivo, DateTime dataCriacao)
        {
            try
            {
                var entidade = new NFE.Entidades.Arquivo();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "INSERT INTO NFEENTRADA(nomearquivo,dataarquivo,datacriacao)VALUES(@nomearquivo,@dataarquivo,@datacriacao)";
                cmd.Parameters.AddWithValue("@nomearquivo", nomeArquivo);
                cmd.Parameters.AddWithValue("@dataarquivo", dataArquivo);
                cmd.Parameters.AddWithValue("@datacriacao", dataCriacao);
                cmd.ExecuteNonQuery();
                Console.Clear();
                Console.WriteLine("Arquivo Inserido com Sucesso !\nNome do Arquivo: {0} Data do Arquivo: {1} Data Criação: {2}", nomeArquivo, dataArquivo, dataCriacao);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
        public bool AtualizaArquivo(string usuario, string senha)
        {
            try
            {
                NFE.Entidades.Autenticacao entidade = new NFE.Entidades.Autenticacao();
                MySqlConnection conectar = ParametrosConexao.DadosConexao();
                MySqlCommand cmd;

                conectar.Open();
                cmd = conectar.CreateCommand();
                cmd.CommandText = "INSERT INTO USUARIO(login,senha, dataModificacao)VALUES(@login,@senha,@dataModificacao)";
                cmd.Parameters.AddWithValue("@login", entidade.Usuario);
                cmd.Parameters.AddWithValue("@senha", entidade.Senha);
                //cmd.Parameters.AddWithValue("@dataModificacao", entidade.DataModificacao);
                return true;
            }
            catch (System.Exception)
            {
                return false;
                throw;
            }
        }
        public bool ExcluiArquivo(string login, string senha, string dataCriacao, string dataModificao, string ultimoAcesso, int ativo)
        {
            try
            {
                NFE.Entidades.Autenticacao entidade = new NFE.Entidades.Autenticacao();
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

        public void ImportarXML()
        {

        }
    }
}
