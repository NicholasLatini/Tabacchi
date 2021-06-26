using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabacchiFinale.ProdottoMacchina;

namespace TabacchiFinale.Pagamento
{
    public partial class Pagamento : Form
    {
        private Prodotto prodotto;
        private Double prezzoTotale;
        private const Double resto_max = 3;
        private Database.FileDBResto restoDisponibile = Database.FileDBResto.GetInstance("RestoDisponibileMacchina.txt");
        private Scontrino.Scontrino scontrino;
        private bool statoErogazione;
        private Double countDenaroInserito = 0;
        public bool statoOperazione { get; set; }

        //costruttore
        public Pagamento(Double prezzoTot,Prodotto prod)
        {
            InitializeComponent();
            prodotto = prod;
            this.prezzoTotale = prezzoTot;
            inizializzaProgressBarPagamento();
            inizializzaProgressBarTimer();

        }

        private void Pagamento_Load(object sender, EventArgs e)
        {
            picProd.ImageLocation = this.prodotto.pathImmagine;
            picProd.SizeMode = PictureBoxSizeMode.StretchImage;

            cent10.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\cent10.jpg");
            cent10.SizeMode = PictureBoxSizeMode.StretchImage;

            cent20.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\cent20.jpg");
            cent20.SizeMode = PictureBoxSizeMode.StretchImage;

            cent50.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\cent50.jpg");
            cent50.SizeMode = PictureBoxSizeMode.StretchImage;

            eur1.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur1.jpg");
            eur1.SizeMode = PictureBoxSizeMode.StretchImage;

            eur2.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur2.jpg");
            eur2.SizeMode = PictureBoxSizeMode.StretchImage;

            eur5.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur5.jpg");
            eur5.SizeMode = PictureBoxSizeMode.StretchImage;

            eur10.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur10.jpg");
            eur10.SizeMode = PictureBoxSizeMode.StretchImage;

            eur20.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur20.jpg");
            eur20.SizeMode = PictureBoxSizeMode.StretchImage;

            eur50.ImageLocation = Path.GetFullPath(@"..\..\Images\Soldi\eur50.jpg");
            eur50.SizeMode = PictureBoxSizeMode.StretchImage;

            lblPrezTot.Text = this.prezzoTotale.ToString();
            lblPagamentoTot.Text = this.progressBar1.Minimum.ToString();

            btnAnnulla.Text = "ANNULLA";
        }


        
        //funzione che inizializza la progressbar
        private void inizializzaProgressBarPagamento()
        {
            this.progressBar1.Minimum = 0;
            this.progressBar1.Maximum = (int)(this.prezzoTotale*100);
            this.progressBar1.Value = 0;
        }

        //funzione che inizializza la progressBarTimer
        private void inizializzaProgressBarTimer()
        {
            this.progressTempo.Minimum = 0;
            this.progressTempo.Maximum = 30;
            ResetTimer();
            lblTempo.Text = this.progressTempo.Value.ToString();
            timerPagamento.Enabled = true;
            timerPagamento.Start();

        }

        //funzione che controlla se ho inserito tutti i soldi
        private void ControllaInserimentoDenaro()
        {
            Double restoCliente;
            lblPagamentoTot.Text = (progressBar1.Value * 100 / progressBar1.Maximum).ToString() + "%";
            if (progressBar1.Value >= progressBar1.Maximum)
            {
                restoCliente = countDenaroInserito - prezzoTotale; //questo valore può essere 0 o >0
                scontrino = new Scontrino.Scontrino(ControlloErogazioneResto(restoCliente), this.statoErogazione,prodotto,this.prezzoTotale);
                if(scontrino.stampaOrdine() == true) MessageBox.Show("Scontrino stampato"); ;
                this.statoOperazione = true;
                timerPagamento.Enabled = false;
                timerPagamento.Stop();
                this.Close();
            }
            

        }

        //funzione che resetta il timer ogni volta che viene inserito un soldo
        private void ResetTimer()
        {
            this.progressTempo.Value = this.progressTempo.Maximum;
            ControllaInserimentoDenaro();
            
        }

        //funzioni per il pagamento del prezzo totale e aumento della progressbar
        private void cent10_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 0.10;
            progressBar1.Step = (int)(0.10 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void cent20_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 0.20;
            progressBar1.Step = (int)(0.20 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void cent50_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 0.50;
            progressBar1.Step = (int)(0.50 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur1_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 1;
            progressBar1.Step = (int)(1 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur2_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 2;
            progressBar1.Step = (int)(2 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur5_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 5;
            progressBar1.Step = (int)(5 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur10_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 10;
            progressBar1.Step = (int)(10 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur20_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 20;
            progressBar1.Step = (int)(20 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void eur50_Click(object sender, EventArgs e)
        {
            this.countDenaroInserito += 50;
            progressBar1.Step = (int)(50 * 100);
            progressBar1.PerformStep();
            ResetTimer();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            if (progressTempo.Value > progressTempo.Minimum)
            {
                progressTempo.Step = -1;
                progressTempo.PerformStep();
                lblTempo.Text = this.progressTempo.Value.ToString();
            }
            else
            {
                this.timerPagamento.Enabled = false;
                this.timerPagamento.Stop();
                this.statoOperazione = false;
                btnAnnulla_Click(sender,e);
            }
        }

        //funzione che calcola il resto da erogare
        private Double ControlloErogazioneResto(Double restoCliente)
        {
            Double restoDisponibileMacchina = restoDisponibile.GetData();
            Double restoErogato = 0;

            //se il resto della macchina è maggiore di 3, allora può erogare un eventuale resto altrimenti bisogna scrivere nello scontrino che devi ricevere il resto mancante direttamente dal tabaccaio
            if(restoDisponibileMacchina > 0 && restoCliente > 0 && restoCliente < resto_max)
            {
                //erogo il resto se il denaro inserito dal cliente è maggiore del prezzo totale
                //la variabile restoCliente fa la differenza tra il valore della progressbar di pagamento e il prezzo totale.
                //questa differenza può dare solamente valori = o > 0.
                
                restoErogato = restoCliente;
                this.statoErogazione = true;
                aggiornaRestoDisponibileMacchina(restoDisponibileMacchina-restoCliente);     
         
            }
            else if(restoDisponibileMacchina >= 0 && restoCliente > resto_max)
            {
                restoErogato = restoCliente;
                this.statoErogazione = false;
            }
            return restoErogato;
        }


        //funzione che aggiorna il file del restoDisponibile nella macchina

        private void aggiornaRestoDisponibileMacchina(Double restoCliente)
        {
            restoDisponibile.SaveData(restoCliente);
        }

        //funzione che viene usata quando il tempo limite scade o quando il cliente annulla l'operazione
        //e se sono stati inseriti dei soldi dobbiamo restituirli

        private void RestituzioneSoldi()
        {
            if (countDenaroInserito > 0) MessageBox.Show("Ritorno alla schermata principale...\n" +
                       "Denaro restituito: " + countDenaroInserito.ToString());
            else MessageBox.Show("Ritorno alla schermata principale...");
            
        }

        private void btnAnnulla_Click(object sender, EventArgs e)
        {
            RestituzioneSoldi();
            this.statoOperazione = false;
            this.Close();
        }
    }
}
