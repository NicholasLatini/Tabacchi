using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabacchiFinale.ProdottoMacchina;

namespace TabacchiFinale.Database
{
    class FileDB : IDatabase
    {
        private readonly string DBPath;

        private static FileDB instance;

        //Singleton pattern
        public static FileDB GetInstance(string databaseFilePath)
        {

            if (instance == null)
            {
                instance = new FileDB(databaseFilePath);
            }

            return instance;

        }

        //costruttore
        private FileDB(string datafile)
        {
            DBPath = datafile;
        }

        //metodo per prelevare i dati dal file database dei prodotti
        public IList<Prodotto> GetData() 
        {
            IList<Prodotto> prodotti = new List<Prodotto>();
            Prodotto prod;
            String[] infoProd;
            try
            {
                // Create an instance of StreamReader to read from a file.
                // The using statement also closes the StreamReader.
                StreamReader sr = new StreamReader(DBPath);
                
                string line;
                // Read and display lines from the file until the end of
                // the file is reached.
                while ((line = sr.ReadLine()) != null)
                {
                    infoProd = line.Split(';');
                    prod = new Prodotto(Int32.Parse(infoProd[0]),infoProd[1],Double.Parse(infoProd[2]),Int32.Parse(infoProd[3]),infoProd[4]);
                    prodotti.Add(prod);
                }
                sr.Close();

                
            }
            catch (Exception e)
            {
                Console.WriteLine("Il file non può essere letto:");
                Console.WriteLine(e.Message);
            }

            return prodotti;
        }
        
        //metodo per salvare i dati nel file database dei prodotti
        public void SaveData(IList<Prodotto> prodotti) 
        {
            StreamWriter wr = new StreamWriter(DBPath);

            string str = "";
            for(int i = 0; i<prodotti.Count(); i++)
            {
                str = prodotti[i].idProdotto.ToString() + ";" + prodotti[i].nome + ";" + prodotti[i].prezzo + ";" + prodotti[i].quantita + ";" + prodotti[i].pathImmagine;
                wr.WriteLine(str);
            }

            wr.Close();

        }

    }
}
