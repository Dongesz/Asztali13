namespace feladat4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "magyar-szavak.txt";
            //feladat1 - hany szot tartalmaz
            Console.WriteLine("---------------------");
            string[] sorok = File.ReadAllLines(path);
            int sorokszama = 0;
            foreach (var item in sorok)
            {
                sorokszama++;
            }
            Console.WriteLine($"szavak szama: {sorokszama}");

            //feladat2 - hany olyan szo van ami harom betus
            Console.WriteLine("---------------------");
            int harombetusszavak = 0;
            foreach (var item in sorok)
            {
                if (item.Length == 3)
                {
                    harombetusszavak++;
                    Console.WriteLine(item);

                }
            }
            Console.WriteLine($"Osszesen {harombetusszavak} harom betus szo van a fileban!");

            //feladat3 - melyik a leghosszabb szo
            Console.WriteLine("---------------------");
            string leghosszabb = sorok[0];
            foreach (var item in sorok)
            { 
                if(item.Length > leghosszabb.Length) leghosszabb = item;
            }
            Console.WriteLine(leghosszabb);

            //feladat4 - Átlagos hosszúságú szóra jeleníts meg egy példát!
            Console.WriteLine("---------------------");
            int karakterek = 0;
            foreach (var item in sorok)
            {
                karakterek += item.Length;
            }
            int atlag = karakterek / sorok.Length;
            foreach (var item in sorok)
            {
                if (item.Length == atlag)
                {
                    Console.WriteLine($"pelda az atlagos hosszusagu szora: {item}");
                    break;
                }
            }

            //feladat5 - Jelenítsd meg azokat a szavakat melyek x betűt tartalmazzák.
            Console.WriteLine("---------------------");
            foreach (var item in sorok)
            {
                if(item.Contains('x')) Console.WriteLine(item);
            }

            //feladat6 -  A kötőjellel írsz szavakat jelenítsd meg,(de ami kötőjelre végződik azt ne!)
            Console.WriteLine("---------------------");
            foreach(var item in sorok)
            {
                if (item.Contains('-')) Console.WriteLine(item.TrimEnd('-'));
            }

            //feladat7 - Egy másik fájlba (a.txt) írjuk bele az a betűvel kezdődő szavakat.
            Console.WriteLine("---------------------");
            if (!File.Exists("a.txt"))
            {
                using (File.Create("a.txt")) { }
            }
            foreach (var item in sorok)
            {
                if (item.Contains('a'))
                {
                    File.AppendAllText("a.txt", item + "\n");
                }
            }

            //feladat8 - Olvass be egy szót, ha 'a' betűvel kezdődik írd hozzá az a.txt-hez 
            Console.WriteLine("---------------------");
            Console.WriteLine("adj meg egz szot: ");
            string szo = Console.ReadLine();
            if (szo[0] == 'a')
            {
                File.AppendAllText("a.txt", szo);
            }

            //feladat9 - Ellenőrízd le a magyar-szavak.txt-t, hogy a beolvasott szó szerepel -e benne!
            Console.WriteLine("---------------------");
            foreach (var item in sorok)
            {
                if (item == szo) Console.WriteLine($"Igen a {szo} szerepel a fileban");

            }

            //feladat10 -  10. Hány szó végződik a betűre az a.txt fájlban
            Console.WriteLine("---------------------");
            int hanyszo = 0;
            foreach (var item in sorok)
            {
                if (item[item.Length - 1] == 'a') hanyszo++;
            }
            Console.WriteLine(hanyszo);
        }

    }
}
