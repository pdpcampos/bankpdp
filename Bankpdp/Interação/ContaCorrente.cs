using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Interação
{
    public class ContaCorrente : Conta
    {
        public ContaCorrente()
        {
            this.NumeroConta = "00" + Conta.NumeroDaContaSequencial;
        }
    }
}
