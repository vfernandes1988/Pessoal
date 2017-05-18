using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NFE.Entidades
{
    class ArquivoXML
    {
        public int Id { get; set; }
        public string NomeArquivo { get; set; }
        public DateTime DataCriacao { get; set; }
        public DateTime DataArquivo { get; set; }
        public string Caminho { get; set; }
        public string Extensao { get; set; }
    }
}
