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

        }

        public double Saldo { get; protected set; }

        public string NumeroAgencia { get; private set; }

        public string NumeroConta { get; protected set; }

        public double ConsultaSaldo()
        {
            return this.Saldo;
        }

        public void Deposita(double valor)
        {
            throw new NotImplementedException();
        }

        public string GetCodigoDoBanco()
        {
            throw new NotImplementedException();
        }

        public string GetNumeroAgencia()
        {
            throw new NotImplementedException();
        }

        public string GetNumeroConta()
        {
            throw new NotImplementedException();
        }

        public bool saca(double valor)
        {
            throw new NotImplementedException();
        }
    }
}
