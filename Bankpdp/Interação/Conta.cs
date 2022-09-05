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
        }

        public double Saldo { get; protected set; }

        public string NumeroAgencia { get; private set; }

        public string NumeroConta { get; protected set; }
        public static int NumeroDaContaSequencial { get; private set; }

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            this.Saldo += valor;
        }

        
        public bool saca(double valor)
        {
            if (valor > this.ConsultaSaldo())
                return false;
            
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

    }
}
