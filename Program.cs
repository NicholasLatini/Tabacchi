using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TabacchiFinale
{
    static class Program
    {
        /// <summary>
        /// Punto di ingresso principale dell'applicazione.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Database.IDatabase db = Database.FileDB.GetInstance(@"..\..\Database\Files\Prodotti.txt");
            Database.FileDBResto dbRest = Database.FileDBResto.GetInstance(@"..\..\Database\Files\RestoDisponibileMacchina.txt");

            //inizializzo il resto della macchina con un numero scelto a mio piacimento
            dbRest.SaveData(50);

            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Macchina(db));
        }
    }
}
