using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;
using NFE.Entidades;

namespace NFE.DAL
{
    class ArquivoDAL
    {
        public void ListarArquivo()
        {
            try
            {
                var arquivo = new Entidades.Arquivo();
                var transcaoBanco = new TransacaoBancoDAL();
                DirectoryInfo Dir = new DirectoryInfo(@"C:\XML");
                FileInfo[] Files = Dir.GetFiles("*.xml", SearchOption.AllDirectories);
                foreach (FileInfo file in Files)
                {
                    arquivo.NomeArquivo = file.Name;
                    arquivo.DataArquivo = file.LastAccessTime;
                    arquivo.DataCriacao = DateTime.Now.ToLocalTime();
                    var verificaArquivo = transcaoBanco.VerificaArquivo(arquivo.NomeArquivo, arquivo.DataArquivo);
                    if (!verificaArquivo)
                        transcaoBanco.InsereArquivo(arquivo.NomeArquivo, arquivo.DataArquivo, arquivo.DataCriacao);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
