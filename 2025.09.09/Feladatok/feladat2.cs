using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace feladat2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //feladat1
            string path = "szamok2.txt";

            try
            {
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                using (File.Create(path)) { } 

                for (int i = 1; i <= 1000; i++) 
                {
                    File.AppendAllText(path, i + "\n");
                }
                Console.WriteLine("Fájl létrehozva, számok (1-10) kiírva.");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Hiba történt: {ex.Message}");
            }

            //Osszegzes
            string[] sorok = File.ReadAllLines(path);
            int osszeg = 0;
            for (int i = 0; i < sorok.Length; i++)
            {
                osszeg += Convert.ToInt32(sorok[i]);
            }
            Console.WriteLine(osszeg);

            //Atlag
            int atlag = osszeg/sorok.Length;
            Console.WriteLine(atlag);

            //legnagyobb 3 jegyu szam
            sorok = File.ReadAllLines(path);
            bool van = false;
            int kezdo = 0;
            foreach (var sor in sorok)
            {
                if (sor.Length == 3)
                {
                    van = true;
                    kezdo = Convert.ToInt32(sor);
                    break;
                }
            }
            if (!van)
                {
                    Console.WriteLine("nincs haromjegyu szam");
                }
            else
            {
                int max = kezdo;
                for (int i = 0;i < sorok.Length;i++)
                {
                    if (Convert.ToInt32(sorok[i]) > max && sorok[i].Length ==3) max = int.Parse(sorok[i]);
                }
                Console.WriteLine($"legnagyobb 3jegyu szam: {max}");
            }
            
        }
    }
}
