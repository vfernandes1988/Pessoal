using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using AcessoBanco;
using AcessoBanco.Conexao;

namespace NFE
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                AcessoBanco.Conexao.Conexao conexao = new AcessoBanco.Conexao.Conexao();
                bool verificarAcessoBanco = conexao.VerificaAcessoBanco();

                string login = "vfernandes";
                string senha = "1234";
                string dataCriacao = DateTime.Now.ToLongDateString();
                string dataModificao = DateTime.Now.ToLongDateString();
                string ultimoAcesso = DateTime.Now.ToLongDateString();
                int ativo = 1;
                bool verificaAcesso = conexao.VerificaAcesso(login, senha);
                if (verificaAcesso)
                    conexao.Excluir(login, senha, dataCriacao, dataModificao, ultimoAcesso, ativo);
            }
            catch (Exception e)
            {
                Console.WriteLine("Erro: " + e.Message);
            }
            Console.Read();
        }
    }
}
