using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TabacchiFinale.Database
{
    class FileDBResto
    {
        private readonly string DBPath;

        private static FileDBResto instance;

        //Singleton pattern
        public static FileDBResto GetInstance(string databaseFilePath)
        {

            if (instance == null)
            {
                instance = new FileDBResto(databaseFilePath);
            }

            return instance;

        }

        //costruttore
        private FileDBResto(string datafile)
        {
            DBPath = datafile;
        }

        //metodo per prelevare il resto disponibile dalla macchina 
        public Double GetData()
        {
            Double restoDisponibile = 0;

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
                    restoDisponibile = Double.Parse(line);
                }
                sr.Close();


            }
            catch (Exception e)
            {
                Console.WriteLine("Il file non può essere letto:");
                Console.WriteLine(e.Message);
            }

            return restoDisponibile;
        }

        //metodo che aggiorna il resto disponibile nella macchina dopo aver comprato un prodotto
        public void SaveData(Double restoDisponibile)
        {
            StreamWriter wr = new StreamWriter(DBPath);

            wr.WriteLine(restoDisponibile.ToString());

            wr.Close();

        }
    }
}
