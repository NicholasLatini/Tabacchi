using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabacchiFinale.Visitors
{
    public interface IVisitor
    {
        double Result { get; }
        void Visit(ProdottoMacchina.Prodotto prod);
        void Reset();

    }
}
