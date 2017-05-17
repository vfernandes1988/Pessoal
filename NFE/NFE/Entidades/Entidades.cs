using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AcessoBanco
{
    class Entidades
    {
        private string login;
        public string Login
        {
            get { return login; }
            set { login = value; }
        }

        private string senha;
        public string Senha
        {
            get { return senha; }
            set { senha = value; }
        }

        private string dataCriacao;
        public string DataCriacao
        {
            get { return dataCriacao; }
            set { dataCriacao = DateTime.Now.ToLongDateString(); }
        }

        private string dataModificacao;
        public string DataModificacao
        {
            get { return dataModificacao; }
            set { dataModificacao = DateTime.Now.ToLongDateString(); }
        }

        private string ultimoAcesso;
        public string UltimoAcesso
        {
            get { return ultimoAcesso; }
            set { ultimoAcesso = DateTime.Now.ToLongDateString(); }
        }

        private string ativo;
        public string Ativo
        {
            get { return ativo; }
            set { ativo = value; }
        }

    }
}
