using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Konyvtar
{
    public class Konyv
    {
        public int Konyv_id {  get; private set; }
        public string Cim { get; private set; }
        public string Szerzo { get; private set; }
        public int Kiadas_ev { get; private set; }
        public int Ar {  get; private set; }
        public string Kategoria { get; private set; }

        public Konyv(int konyv_id, string cim, string szerzo, int kiadas_ev, int ar, string kategoria)
        {
            Konyv_id = konyv_id;
            Cim = cim;
            Szerzo = szerzo;
            Kiadas_ev = kiadas_ev;
            Ar = ar;
            Kategoria = kategoria;
        }
    }
}
