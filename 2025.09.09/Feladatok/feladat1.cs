using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Feladat1
            string path = "szamok.txt";
            if (File.Exists(path)) File.Delete(path);

            for (int i = 0; i <= 1000; i += 2)
            {
                if (File.Exists(path))
                {
                    File.AppendAllText(path, i.ToString());
                    File.AppendAllText(path, ",");

                }
                else
                {
                    File.WriteAllText(path, i.ToString());
                    File.AppendAllText(path, ",");
                }
            }

            string[] szamok = File.ReadAllLines(path);

            for (int i = 0; i < szamok.Length; i++)
            {
                Console.WriteLine($"{szamok[i]}".TrimEnd(','));
            }
        }
    }
}
