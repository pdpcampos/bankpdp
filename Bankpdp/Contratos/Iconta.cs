using System;
using System.Collections.Generic;
using System.Text;

namespace Bankpdp.Contratos
{
    public interface Iconta
    {
        void Deposita(double valor);

        bool saca(double valor);

        double ConsultaSaldo();
        string GetCodigoDoBanco();

        string GetNumeroAgencia();

        string GetNumeroConta();
    }
}
