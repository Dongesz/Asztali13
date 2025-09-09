using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Asztali1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "valami.txt";

            //File letezesenek ellenorzese
            if (File.Exists("valami.txt")) Console.WriteLine("Letezik!");
            else Console.WriteLine("Nem letezik!");

            //File irasa - Egysoros
            File.WriteAllText("valami.txt", "Hello World!");

            //File irasa - Tobbsoros
            string[] Sarray = { "alma", "korte", "szilva" };
            File.WriteAllLines("valami.txt", Sarray);

            //Filehoz fuzes
            string content = "dio\n";
            if (File.Exists(path)) File.AppendAllText(path, content);
            else File.WriteAllText(path, content);

            //File torlese
            if (File.Exists(path)) File.Delete(path);
           
        }
    }
}
