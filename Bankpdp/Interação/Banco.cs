using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Interação
{
    public abstract class Banco
    {
        public Banco()
        {
            this.NomeDoBanco = "Bank PDP";

            this.CodigoDoBanco = "1901";
        }

        public string NomeDoBanco { get; private set; }
        public string CodigoDoBanco { get; private set; }
    }
}
