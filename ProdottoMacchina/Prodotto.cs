using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using TabacchiFinale.Visitors;

namespace TabacchiFinale.ProdottoMacchina
{
    public class Prodotto : IVisitorHost
    {
        public int idProdotto { get; set; }
        public String nome { get; set; }
        public Double prezzo { get; set; }
        public int quantita { get; set; }
        public String pathImmagine { get; set; }


        public Prodotto(int idProdotto, String nome,Double prezzo,int quantita, String pathImmagine)
        {
            this.idProdotto = idProdotto;
            this.nome = nome;
            this.prezzo = prezzo;
            this.quantita = quantita;
            this.pathImmagine = pathImmagine;
        }

       


        //funzione che stampa le informazioni del prodotto
        public String toString()
        {
            return $"Nome prodotto: {nome} Prezzo: {prezzo} Quantita: {quantita} PathImmagine {pathImmagine}";
        }

        //metodo che accetta i visitor
        public void Accept(IVisitor visitor) { visitor.Visit(this); }



    }
}
