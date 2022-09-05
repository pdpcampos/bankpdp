using Bankpdp.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Interação
{
    class Pessoa
    {
        public string  Nome { get; private set; }

        public string CPF { get; private set; }

        public string Senha { get; private set; }

        public Iconta Conta { get; set; }

        public void  SetNome(string nome)
        {
            this.Nome = nome;
        }

        public void setCPF (string cpf)
        {
            this.CPF = cpf;
        }

        public void setSenha (string senha)
        {
            this.Senha = senha;
        }


    }
}
