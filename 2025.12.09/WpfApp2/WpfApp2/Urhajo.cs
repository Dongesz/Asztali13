using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WpfApp2
{
    public class Urhajo
    {
        public string Nev {  get; set; }
        public int Legenyseg {  get; set; }
        public int MaxHatotav {  get; set; }
        public int UzemanyagSzint {  get; set; }    
        public string Gyarto {  get; set; }  
        public string KuldetesStatus {  get; set; }  
        public int InditasEve {  get; set; }

        public Urhajo(string nev, int legenyseg, int maxHatotav, int uzemanyagSzint, string gyarto, string kuldetesStatus, int inditasEve)
        {
            Nev = nev;
            Legenyseg = legenyseg;
            MaxHatotav = maxHatotav;
            UzemanyagSzint = uzemanyagSzint;
            Gyarto = gyarto;
            KuldetesStatus = kuldetesStatus;
            InditasEve = inditasEve;
        }
    }
}
