using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TabacchiFinale.Database;
using TabacchiFinale.ProdottoMacchina;
using TabacchiFinale.Carrello;

namespace TabacchiFinale
{
    public partial class Macchina : Form
    {
        private IList<Prodotto> prodotti = new List<Prodotto>();            //lista  dei prodotti che conterrà i prodotti della macchina
        private IDatabase db;                                               //oggetto database per utilizzare i metodi della classe database
        private Carrello.Carrello carrello;                                  //oggetto carrello 
        
        
        //costruttore
        public Macchina(IDatabase database)
        {
            InitializeComponent();

            db = database;

            CaricaProdotti();
            if(resettaProdottiFiniti() == true)
            {
                SalvaProdotti();
                CaricaProdotti();
            }
        }

        private void Macchina_Load(object sender, EventArgs e)
        {
            AssegnaPathImmagine();

        }

        //funzione che assegna il path dell'immagine
        private void AssegnaPathImmagine()
        {
            int id;
            if (prodotti.Count() > 0)
            {
                for(int i = 0; i < prodotti.Count(); i++)
                {
                    id = prodotti[i].idProdotto;
                     
                    if (prodotti[i].quantita > 0)
                    {
                        switch (id)
                        {
                            case 0:
                                prodotti[0].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\MarlboroGold.jpg");
                                MarlboroGold.ImageLocation = prodotti[0].pathImmagine;
                                MarlboroGold.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 1:
                                prodotti[1].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\MarlboroRosse.jpg");
                                MarlboroRosse.ImageLocation = prodotti[1].pathImmagine;
                                MarlboroRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 2:
                                prodotti[2].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\MarlboroTouch.jpg");
                                MarlboroTouch.ImageLocation = prodotti[2].pathImmagine;
                                MarlboroTouch.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 3:
                                prodotti[3].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\CamelBlue.jpg");
                                CamelBlue.ImageLocation = prodotti[3].pathImmagine;
                                CamelBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 4:
                                prodotti[4].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\ChiaravalleVerdi.jpg");
                                ChiaravalleVerdi.ImageLocation = prodotti[4].pathImmagine;
                                ChiaravalleVerdi.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 5:
                                prodotti[5].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\ChiaravalleBlue.jpg");
                                ChiaravalleBlue.ImageLocation = prodotti[5].pathImmagine;
                                ChiaravalleBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 6:
                                prodotti[6].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\ChiaravalleGialle.jpg");
                                ChiaravalleGialle.ImageLocation = prodotti[6].pathImmagine;
                                ChiaravalleGialle.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 7:
                                prodotti[7].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\MSRosse.jpg");
                                MSRosse.ImageLocation = prodotti[7].pathImmagine;
                                MSRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 8:
                                prodotti[8].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\MSGialle.jpg");
                                MSGialle.ImageLocation = prodotti[8].pathImmagine;
                                MSGialle.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 9:
                                prodotti[9].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\Chesterfield.jpg");
                                Chesterfield.ImageLocation = prodotti[9].pathImmagine;
                                Chesterfield.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 10:
                                prodotti[10].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\Diana.jpg");
                                Diana.ImageLocation = prodotti[10].pathImmagine;
                                Diana.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 11:
                                prodotti[11].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\LuckyRosse.jpg");
                                LuckyRosse.ImageLocation = prodotti[11].pathImmagine;
                                LuckyRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 12:
                                prodotti[12].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\LuckyBlue.jpg");
                                LuckyBlue.ImageLocation = prodotti[12].pathImmagine;
                                LuckyBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 13:
                                prodotti[13].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\PallMall.jpg");
                                PallMall.ImageLocation = prodotti[13].pathImmagine;
                                PallMall.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 14:
                                prodotti[14].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\PhilipMorris.jpg");
                                PhilippeMorris.ImageLocation = prodotti[14].pathImmagine;
                                PhilippeMorris.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 15:
                                prodotti[15].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\WinstonBlue.jpg");
                                WinstonBlue.ImageLocation = prodotti[15].pathImmagine;
                                WinstonBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 16:
                                prodotti[16].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\WinstonBlue100.jpg");
                                WinstonBlue100.ImageLocation = prodotti[16].pathImmagine;
                                WinstonBlue100.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 17:
                                prodotti[17].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\WinstonRosse.jpg");
                                WinstonRosse.ImageLocation = prodotti[17].pathImmagine;
                                WinstonRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 18:
                                prodotti[18].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\SmokKit.jpg");
                                SmokeKit.ImageLocation = prodotti[18].pathImmagine;
                                SmokeKit.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                            case 19:
                                prodotti[19].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiDisponibili\Accendino.jpg");
                                Accendino.ImageLocation = prodotti[19].pathImmagine;
                                Accendino.SizeMode = PictureBoxSizeMode.StretchImage;
                                break;
                        }

                    }
                    else
                    {
                        switch (id)
                        {
                            case 0:
                                prodotti[0].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\MarlboroGold_es.jpg");
                                MarlboroGold.ImageLocation = prodotti[0].pathImmagine;
                                MarlboroGold.SizeMode = PictureBoxSizeMode.StretchImage;
                                MarlboroGold.Enabled = false;
                                break;
                            case 1:
                                prodotti[1].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\MarlboroRosse_es.jpg");
                                MarlboroRosse.ImageLocation = prodotti[1].pathImmagine;
                                MarlboroRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                MarlboroRosse.Enabled = false;
                                break;
                            case 2:
                                prodotti[2].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\MarlboroTouch_es.jpg");
                                MarlboroTouch.ImageLocation = prodotti[2].pathImmagine;
                                MarlboroTouch.SizeMode = PictureBoxSizeMode.StretchImage;
                                MarlboroTouch.Enabled = false;
                                break;
                            case 3:
                                prodotti[3].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\CamelBlue_es.jpg");
                                CamelBlue.ImageLocation = prodotti[3].pathImmagine;
                                CamelBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                CamelBlue.Enabled = false;
                                break;
                            case 4:
                                prodotti[4].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\ChiaravalleVerdi_es.jpg");
                                ChiaravalleVerdi.ImageLocation = prodotti[4].pathImmagine;
                                ChiaravalleVerdi.SizeMode = PictureBoxSizeMode.StretchImage;
                                ChiaravalleVerdi.Enabled = false;
                                break;
                            case 5:
                                prodotti[5].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\ChiaravalleBlue_es.jpg");
                                ChiaravalleBlue.ImageLocation = prodotti[5].pathImmagine;
                                ChiaravalleBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                ChiaravalleBlue.Enabled = false;
                                break;
                            case 6:
                                prodotti[6].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\ChiaravalleGialle_es.jpg");
                                ChiaravalleGialle.ImageLocation = prodotti[6].pathImmagine;
                                ChiaravalleGialle.SizeMode = PictureBoxSizeMode.StretchImage;
                                ChiaravalleGialle.Enabled = false;
                                break;
                            case 7:
                                prodotti[7].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\MSRosse_es.jpg");
                                MSRosse.ImageLocation = prodotti[7].pathImmagine;
                                MSRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                MSRosse.Enabled = false;
                                break;
                            case 8:
                                prodotti[8].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\MSGialle_es.jpg");
                                MSGialle.ImageLocation = prodotti[8].pathImmagine;
                                MSGialle.SizeMode = PictureBoxSizeMode.StretchImage;
                                MSGialle.Enabled = false;
                                break;
                            case 9:
                                prodotti[9].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\Chesterfield_es.jpg");
                                Chesterfield.ImageLocation = prodotti[9].pathImmagine;
                                Chesterfield.SizeMode = PictureBoxSizeMode.StretchImage;
                                Chesterfield.Enabled = false;
                                break;
                            case 10:
                                prodotti[10].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\Diana_es.jpg");
                                Diana.ImageLocation = prodotti[10].pathImmagine;
                                Diana.SizeMode = PictureBoxSizeMode.StretchImage;
                                Diana.Enabled = false;
                                break;
                            case 11:
                                prodotti[11].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\LuckyRosse_es.jpg");
                                LuckyRosse.ImageLocation = prodotti[11].pathImmagine;
                                LuckyRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                LuckyRosse.Enabled = false;
                                break;
                            case 12:
                                prodotti[12].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\LuckyBlue_es.jpg");
                                LuckyBlue.ImageLocation = prodotti[12].pathImmagine;
                                LuckyBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                LuckyBlue.Enabled = false;
                                break;
                            case 13:
                                prodotti[13].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\PallMall_es.jpg");
                                PallMall.ImageLocation = prodotti[13].pathImmagine;
                                PallMall.SizeMode = PictureBoxSizeMode.StretchImage;
                                PallMall.Enabled = false;
                                break;
                            case 14:
                                prodotti[14].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\PhilipMorris_es.jpg");
                                PhilippeMorris.ImageLocation = prodotti[14].pathImmagine;
                                PhilippeMorris.SizeMode = PictureBoxSizeMode.StretchImage;
                                PhilippeMorris.Enabled = false;
                                break;
                            case 15:
                                prodotti[15].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\WinstonBlue_es.jpg");
                                WinstonBlue.ImageLocation = prodotti[15].pathImmagine;
                                WinstonBlue.SizeMode = PictureBoxSizeMode.StretchImage;
                                WinstonBlue.Enabled = false;
                                break;
                            case 16:
                                prodotti[16].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\WinstonBlue100_es.jpg");
                                WinstonBlue100.ImageLocation = prodotti[16].pathImmagine;
                                WinstonBlue100.SizeMode = PictureBoxSizeMode.StretchImage;
                                WinstonBlue100.Enabled = false;
                                break;
                            case 17:
                                prodotti[17].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\WinstonRosse_es.jpg");
                                WinstonRosse.ImageLocation = prodotti[17].pathImmagine;
                                WinstonRosse.SizeMode = PictureBoxSizeMode.StretchImage;
                                WinstonRosse.Enabled = false;
                                break;
                            case 18:
                                prodotti[18].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\SmokKit_es.jpg");
                                SmokeKit.ImageLocation = prodotti[18].pathImmagine;
                                SmokeKit.SizeMode = PictureBoxSizeMode.StretchImage;
                                SmokeKit.Enabled = false;
                                break;
                            case 19:
                                prodotti[19].pathImmagine = Path.GetFullPath(@"..\..\Images\ProdottiEsauriti\Accendino_es.jpg");
                                Accendino.ImageLocation = prodotti[19].pathImmagine;
                                Accendino.SizeMode = PictureBoxSizeMode.StretchImage;
                                Accendino.Enabled = false;
                                break;
                        }
                    }
                }
            }
        }

        //funzione che resetta la quantita dei prodotti esauriti
        private bool resettaProdottiFiniti()
        {
            bool b = false;
            for (int i=0; i<prodotti.Count();i++)
            {
                if (prodotti[i].quantita == 0)
                {
                    b = true;
                    prodotti[i].quantita = 10;
                }
            }
            return b;
        }

        //funzione che carica i prodotti nella lista, prelevandoli dal database

        private void CaricaProdotti()
        {
            try
            {
                prodotti =  db.GetData();

            }
            catch (Exception ex)
            {
                Console.Error.WriteLine("Can't connect " + ex.Message);
                Console.Error.WriteLine(ex.StackTrace);
                return;
            }

            
        }

        //funzione che salva i prodotti nel database
        private void SalvaProdotti()
        {
              db.SaveData(prodotti);
        }


        //funzione che inserisce il prodotto comprato aggiornando la quantità rimasta del prodotto
        private void SalvaQuantitaProdottoDB()
        {
            Prodotto prod = carrello.getProdottoVenduto(); ;
            if (prod != null)
            {
                int index = prod.idProdotto;

                if (prodotti[index].idProdotto == index)
                {
                    aggiornaQuantitaProdotto(prodotti[index], prod);
                }
                SalvaProdotti();
                CaricaProdotti();
                AssegnaPathImmagine();
            }
        }

        //funzione che aggiorna la quantità del prodotto dopo essere stato venduto
        private void aggiornaQuantitaProdotto(Prodotto prodFile, Prodotto prodVenduto)
        {
            prodFile.quantita -= prodVenduto.quantita;
        }


      

        //funzioni per la scelta delle sigarette
        private void MarlboroGold_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[0]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void MarlboroRosse_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[1]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void MarlboroTouch_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[2]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void CamelBlue_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[3]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void ChiaravalleVerdi_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[4]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void ChiaravalleBlue_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[5]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void ChiaravalleGialle_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[6]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void MSRosse_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[7]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void MSGialle_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[8]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void Chesterfield_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[9]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void Diana_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[10]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void LuckyRosse_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[11]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void LuckyBlue_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[12]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void PallMall_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[13]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void PhilippeMorris_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[14]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void WinstonBlue_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[15]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void WinstonBlue100_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[16]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void WinstonRosse_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[17]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void SmokeKit_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[18]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }

        private void Accendino_Click(object sender, EventArgs e)
        {
            carrello = new Carrello.Carrello(prodotti[19]);
            carrello.ShowDialog();
            SalvaQuantitaProdottoDB();
        }



        


    }
}
