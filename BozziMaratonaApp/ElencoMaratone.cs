using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace BozziMaratonaApp
{
    class ElencoMaratone
    {
        public List<Maratona> Elenco { get; set; }

        public ElencoMaratone()
        {
            Elenco = new List<Maratona>();
        }

        public void Aggiungi(Maratona unaMaratona)
        {
            Elenco.Add(unaMaratona);
        }

        public int TrasformaTempo(string oreMinuti)
        {
            int ore = int.Parse(oreMinuti.Substring(0, 2));
            int minuti = int.Parse(oreMinuti.Substring(3, 2));
            return ore * 60 + minuti;
        }

        public void LeggiDaFile()
        {
            FileStream flussoDati = new FileStream("maratona.txt", FileMode.Open, FileAccess.Read);
            StreamReader readerDati = new StreamReader(flussoDati);

            while(!readerDati.EndOfStream)
            {
                string riga = readerDati.ReadLine();
                // Rossi Fabio%Fiamme Blu%02h18m%
                string[] campi = riga.Split('%');

                Maratona unaMaratona = new Maratona();
                unaMaratona.Nome = campi[0];
                unaMaratona.Società = campi[1];
                unaMaratona.TempoInMinuti = TrasformaTempo(campi[2]);
                unaMaratona.Città = campi[3];

                Aggiungi(unaMaratona);
            }
        }
    }
}
