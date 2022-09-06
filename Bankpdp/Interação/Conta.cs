using Bankpdp.Contratos;
using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Interação
{
    public abstract class Conta : Banco, Iconta
    {
        public Conta()
        {
            this.NumeroAgencia = "1997";
            Conta.NumeroDaContaSequencial++;
            this.Movimentacoes = new List<Extrato>();
        }

        public double Saldo { get; protected set; }

        public string NumeroAgencia { get; private set; }

        public string NumeroConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }

        private List<Extrato> Movimentacoes;
        


        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "deposito", valor));
            this.Saldo += valor;
        }

        
        public bool saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;

            DateTime dataAtual = DateTime.Now;
            this.Movimentacoes.Add(new Extrato(dataAtual, "Saque", - valor));

            this.Saldo -= valor;
            return true;
        }

        public string GetCodigoDoBanco()
        {
            return this.CodigoDoBanco;
        }

        public string GetNumeroAgencia()
        {
            return this.NumeroAgencia;
        }

        public string GetNumeroConta()
        {
            return this.NumeroConta;
        }

        public List<Extrato> Extratos()
        {
            return this.Movimentacoes;
        }
    }
}
