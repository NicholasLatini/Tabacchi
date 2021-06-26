using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabacchiFinale.ProdottoMacchina;
using TabacchiFinale.Visitors;

namespace TabacchiFinale.Carrello
{
    public partial class Carrello : Form
    {
        private Prodotto prod;                          //prodotto cliccato
        private int quantitaTotaleDisponibile;
        private bool statoOperazione;
        private Visitors.IVisitor prezzoTotale = new Visitors.ProdottoPrezzoTotale();

        public Carrello(Prodotto prodotto)
        {
            InitializeComponent();
            this.quantitaTotaleDisponibile = prodotto.quantita;
            this.prod = new Prodotto(prodotto.idProdotto, prodotto.nome, prodotto.prezzo, prodotto.quantita, prodotto.pathImmagine);
            this.prod.quantita = 1;

        }

        private void Carrello_Load(object sender, EventArgs e)
        {
            picProdotto.ImageLocation = prod.pathImmagine;
            picProdotto.SizeMode = PictureBoxSizeMode.StretchImage;

            btnMeno.Text = "-";
            btnPiu.Text = "+";

            btnOk.Text = "OK";
            btnX.Text = "X";
            prezzoProd.Text = prod.prezzo.ToString();
            prezzoTot.Text = prod.prezzo.ToString();
            quantitaProd.Text = this.prod.quantita.ToString();
            nomeProd.Text = prod.nome;
        }

        //funzione che restituisce il prodotto comprato
        public Prodotto getProdottoVenduto() 
        {
            if (this.statoOperazione == true) return prod;
            else return null;
        }

        //funzione che aggiorna il dato del prezzo totale
        private void aggiornaPrezzoTot()
        {
            prezzoTotale.Visit(prod);
            prezzoTot.Text = prezzoTotale.Result.ToString();
            prezzoTotale.Reset();

        }

        private void btnPiu_Click(object sender, EventArgs e)
        {
            if (this.prod.quantita < quantitaTotaleDisponibile)
            {
                this.prod.quantita += 1;
                this.quantitaProd.Text = this.prod.quantita.ToString();
                aggiornaPrezzoTot();
            }
        }

        private void btnMeno_Click(object sender, EventArgs e)
        {
            if (this.prod.quantita > 1)
            {
                this.prod.quantita -= 1;
                this.quantitaProd.Text = this.prod.quantita.ToString();
                aggiornaPrezzoTot();

            }
        }

        private void btnOk_Click(object sender, EventArgs e)
        {
            Pagamento.Pagamento p = new Pagamento.Pagamento(Double.Parse(this.prezzoTot.Text),prod);
            p.ShowDialog();
            this.statoOperazione = p.statoOperazione; 
            this.Close();


        }

        private void btnX_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
