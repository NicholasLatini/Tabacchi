using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabacchiFinale.ProdottoMacchina;

namespace TabacchiFinale.Scontrino
{
    class Scontrino
    {
        private String nomeProd;
        private String prezzoProd;
        private String quantitaProd;
        private String prezzoTotale;
        private String restoCliente;
        private bool statoErogazione;
        

        public Scontrino(Double restoCliente, bool statoErogazione, Prodotto prod, Double prezzoTotale)
        {
            this.nomeProd = prod.nome;
            this.prezzoProd = prod.prezzo.ToString();
            this.quantitaProd = prod.quantita.ToString();
            this.prezzoTotale = prezzoTotale.ToString();
            this.restoCliente = restoCliente.ToString();
            this.statoErogazione = statoErogazione;
        }

        //funzione che scrive su file quello che è stato comprato finora
        public bool stampaOrdine()
        {
            bool b = false;
            string path = Path.GetFullPath(@"..\..\Ordine.txt");
            StreamWriter sw;
            //controlla che esista il file
            if (!File.Exists(path))
            {
                //crea file in cui scrivere
                sw = File.CreateText(path);

                sw.WriteLine("Nome prodotto acquistato: " + this.nomeProd +
                        "\nPrezzo: " + this.prezzoProd +
                        "\nQuantita: x" + this.quantitaProd +
                        "\nPrezzo Totale Pagato: " + prezzoTotale.ToString() + ElaboraResto());
                        
                b = true;

            }
            else
            {
                //se il file esiste aggiunge altro testo al file
                sw = File.AppendText(path);
                
                sw.WriteLine("Nome prodotto acquistato: " + this.nomeProd +
                    "\nPrezzo: " + this.prezzoProd +
                    "\nQuantita: x" + this.quantitaProd +
                    "\nPrezzo Totale Pagato: " + prezzoTotale.ToString() + ElaboraResto());              
                
                b = true;

            }
            sw.Close();
            return b;
        }

        //funzione che controlla se il cliente deve ricevere il resto o no, oppure deve ritirarlo dal tabaccaio
        private String ElaboraResto()
        {
            Double resto = Math.Round(Double.Parse(this.restoCliente),1);
            String str = "\n\n------------------------------------------------------------";

            if(resto > 0 && this.statoErogazione == true)
            {
                
                str = "\n RESTO EROGATO:" + resto.ToString() + "\n\n------------------------------------------------------------";
            }
            else if(resto > 0 && this.statoErogazione == false)
            {
                str = "\n\n...RESTO NON DISPONIBILE NELLA MACCHINETTA, PORTARE LO SCONTRINO AL TABACCAIO..." +
                      "\n RESTO DA RITIRARE:" + resto.ToString() + "\n\n--------------------------------------------------------------";
            }
            return str;
        }

    }
}
