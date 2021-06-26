using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabacchiFinale.Database
{
    public interface IDatabase
    {
       IList<ProdottoMacchina.Prodotto> GetData();
       void SaveData(IList<ProdottoMacchina.Prodotto> items);
    }
}
