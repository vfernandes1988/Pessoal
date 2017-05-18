using System;
using MySql.Data.MySqlClient;

namespace NFE
{
    class Program
    {
        static void Main(string[] args)
        {
            var entidades = new Entidades.Autenticacao();
            var conexaoBanco = new DAL.VerificacaoAcessoDAL();
            var transacaoBanco = new DAL.TransacaoBancoDAL();
            var acessoUsuario = new DAL.AcessoUsuario();
            var listarArquivo = new DAL.ArquivoDAL();
            MySqlConnection conectar = DAL.ParametrosConexao.DadosConexao();
            bool verificarConexaoBanco = conexaoBanco.VerificaAcessoBanco();

            if (verificarConexaoBanco)
            {
                Console.Write("\nDigite seu Usuário: ");
                entidades.Usuario = Console.ReadLine();
                Console.Write("\nDigite sua Senha: ");
                entidades.Senha = Console.ReadLine();

                bool verificarUsuario = acessoUsuario.VerificaAcesso(entidades.Usuario, entidades.Senha);
                if (verificarUsuario)
                {
                    Console.Clear();
                    Console.Write("\nO que deseja fazer ? ");
                    Console.Write("\nO Digite o numero: 1 - Importar NFE Entrada ou 2 - Exportar NFE Entrada\n");
                    string opcao = Console.ReadLine();
                    if (opcao == "1")
                        listarArquivo.ListarArquivo();
                    else
                    Console.Read();
                }
                else
                {
                    Console.WriteLine("Acesso Negado !");
                }
            }
            conectar.Close();
            Console.WriteLine("CONEXAO ENCERRADA");
        }
    }
}
