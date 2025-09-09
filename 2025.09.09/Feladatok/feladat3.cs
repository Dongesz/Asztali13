using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace feladat3
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "szamok2.txt";

            //tartalmaz 2-t
            Console.WriteLine("ELSOFELADAT");
            string[] szamok = File.ReadAllLines(path);
            for (int i = 0; i < szamok.Length; i++)
            {
                if (szamok[i].Contains('2')) Console.WriteLine(szamok[i]);
            }

            //csak egyforma karakterekbol allo szamokat irjunk ki
            Console.WriteLine("MASODIKFELADAT");
            for (int i = 0;i < szamok.Length; i++)
            {
                bool egyformak = true;
                for (int j = 0; j < szamok[i].Length; j++)
                {
                    if (szamok[i][j] != szamok[i][0])
                    {
                        egyformak =false;
                    }
                }
                if (egyformak)
                {
                    Console.WriteLine(szamok[i]);
                }
                
            }
        }
    }
}
