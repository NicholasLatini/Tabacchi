using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabacchiFinale.ProdottoMacchina;

namespace TabacchiFinale.Visitors
{
    public class ProdottoPrezzoTotale : IVisitor
    {
        private double value = 0;

        public double Result => value;

        public void Reset() => value = 0;

        public void Visit(Prodotto prod) => value += prod.prezzo * prod.quantita;
    }
}
