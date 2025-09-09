namespace feladat5
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string path = "magyar-szavak.txt";
            string[] sorok = File.ReadAllLines(path);
            //feladat1 - optimalizalatlan
            /*
            File.WriteAllText("szotar.txt", "");
            for (int i = 0; i < sorok.Length; i++)
            {
                bool csakbetuk = true;
                foreach (var item in sorok[i])
                {
                 if(!char.IsLetter(item)) csakbetuk = false;
                }
                if (sorok[i].ToLower() == sorok[i] && csakbetuk) File.AppendAllText("szotar.txt",sorok[i] + "\n");
            }
            Console.WriteLine("kesz");*/

            //feladat1 - optimalis
            List<string> szotar = new List<string>();
            for (int i = 0; i < sorok.Length; i++)
            {
                bool csakbetuk = true;
                foreach (var item in sorok[i])
                {
                    if (!char.IsLetter(item)) csakbetuk = false;
                }
                if (sorok[i].ToLower() == sorok[i] && csakbetuk) szotar.Add(sorok[i]);
            }
            File.AppendAllLines("szotar.txt", szotar);
            Console.WriteLine("kesz");
        }
    }
}
