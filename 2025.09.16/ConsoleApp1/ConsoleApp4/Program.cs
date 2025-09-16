using static ConsoleApp4.Program;

namespace ConsoleApp4
{
    internal class Program
    {
        // Tanar - Diak
        public class Tanar
        {
            private string _nev; 
            private int _kor; 
            private string _szak; // Szaktanar, fontos kit tud tanitani
            private int _oraszam;
            private bool _osztalyfonok;
            public int _fizetes; // lehet emelni, csokkenteni
            public int _terheles; // diakokra valo terheles

            public Tanar(string nev, int kor, string szak, int oraszam, bool osztalyfonok, int fizetes, int terheles)
            {
                _nev = nev;
                _kor = kor;
                _szak = szak;
                _oraszam = oraszam;
                _osztalyfonok = osztalyfonok;
                _fizetes = fizetes;
                _terheles = terheles;
            }

            public override string ToString()
            {
                return $"Tanar neve: {_nev}, Eletkora: {_kor}, szakmaja: {_szak}, heti oraszama: {_oraszam}, osztalyfonok: {(_osztalyfonok ? "igen" : "nem")}, fizetese: {_fizetes}";
            }
            public void FizetesEmeles(Tanar tanar, int emeles)
            {
                tanar._fizetes += emeles;
            }
            public void OratAd(Tanar tanar, Osztaly osztaly)
            {
                if (tanar != null && osztaly != null && tanar._szak == osztaly._szak)
                {
                    foreach (var diak in osztaly._diakok)
                    {
                        diak._elmeAllapot -= tanar._terheles;
                    }
                } else Console.WriteLine("A Szaktanarnak nem itt van oraja!");
            }

        }
        public class Tanarok
        {
            private List<Tanar> _list = new List<Tanar>(); // az osszes tanart tarolja

            public Tanarok(List<Tanar> list)
            {
                _list = list;
            }

            public void Felvesz(Tanar tanar)
            {
                _list.Add(tanar);
            }
            public void Kirug(Tanar tanar)
            {
                _list.Remove(tanar);
            }
            
            public void Tanari()
            {
                foreach(Tanar tanar in _list)
                {
                    Console.WriteLine(tanar);
                }
            }
        }
        public class Diak
        {
            private string _nev;
            private int _kor;
            public int _elmeAllapot;
            public bool _figyel;
            private int _osztondij;

            public Diak(string nev, int kor, string szak, int elmeAllapot, int osztondij)
            {
                _nev = nev;
                _kor = kor;
                _elmeAllapot = elmeAllapot;
                _osztondij = osztondij;
            }

            public override string ToString()
            {
                return $"Diak neve: {_nev}, Eletkora: {_kor}, allapota: {_elmeAllapot}, osztondij: {_osztondij}"; 
            }
            public void OsztondijEmeles(Diak diak, int emeles)
            {
                diak._osztondij += emeles;
            }
            public void FigyelE(Diak diak)
            {
                if (_elmeAllapot < 50)
                {
                    _figyel = false;
                    Console.WriteLine($"{_nev} elkalandozott!");
                } else Console.WriteLine($"{_nev} még figyel!");
            }

        }
        public class Osztaly
        {
            public List<Diak> _diakok = new List<Diak>();
            const int _osztalylimit = 30;
            public string _szak;

            public Osztaly(List<Diak> list, string szak)
            {
                _diakok = list;
                _szak = szak;
            }

            public void felvesz(Diak diak)
            {
                _diakok.Add(diak);
            }
            public void Ekltanacsol(Diak diak)
            {
                _diakok.Remove(diak);
            }
            public void Osztalyterem()
            {
                foreach(Diak diak in _diakok)
                {
                    Console.WriteLine(diak);
                }
            }
        }
        static void Main(string[] args)
        {
            // Tesztadatok létrehozása
            // Diákok
            Diak diak1 = new Diak("Kovács Anna", 16, "Informatika", 80, 50000);
            Diak diak2 = new Diak("Nagy Péter", 17, "Informatika", 90, 60000);
            Diak diak3 = new Diak("Szabó Eszter", 16, "Matematika", 70, 45000);
            Diak diak4 = new Diak("Tóth Bence", 17, "Informatika", 40, 40000); // Alacsony elmeAllapot a FigyelE teszteléséhez

            // Osztályok inicializálása
            List<Diak> informatikaDiakok = new List<Diak> { diak1, diak2, diak4 };
            List<Diak> matematikaDiakok = new List<Diak> { diak3 };
            Osztaly tizenharmadikB = new Osztaly(informatikaDiakok, "Informatika");
            Osztaly tizenharmadikA = new Osztaly(matematikaDiakok, "Matematika");

            // Tanárok
            Tanar tanar1 = new Tanar("Deák Csaba", 30, "Informatika", 20, true, 300000, 10);
            Tanar tanar2 = new Tanar("Farkas Zoltán", 32, "Matematika", 15, false, 280000, 15);
            Tanar tanar3 = new Tanar("Négyesi Gábor", 29, "Informatika", 25, false, 320000, 5);

            // Tanárok listája
            List<Tanar> tanarLista = new List<Tanar> { tanar1, tanar2 };
            Tanarok tanarok = new Tanarok(tanarLista);

            // Tesztelés kezdete
            Console.WriteLine("--- Teszt 1: Osztályterem kiíratása (tizenharmadikB) ---");
            tizenharmadikB.Osztalyterem();
            // Várható kimenet:
            // Diak neve: Kovács Anna, Eletkora: 16, allapota: 80, osztondij: 50000
            // Diak neve: Nagy Péter, Eletkora: 17, allapota: 90, osztondij: 60000
            // Diak neve: Tóth Bence, Eletkora: 17, allapota: 40, osztondij: 40000

            Console.WriteLine("\n--- Teszt 2: Tanárok kiíratása ---");
            tanarok.Tanari();
            // Várható kimenet:
            // Tanar neve: Deák Csaba, Eletkora: 30, szakmaja: Informatika, heti oraszama: 20, osztalyfonok: igen, fizetese: 300000
            // Tanar neve: Farkas Zoltán, Eletkora: 32, szakmaja: Matematika, heti oraszama: 15, osztalyfonok: nem, fizetese: 280000

            Console.WriteLine("\n--- Teszt 3: Fizetésemelés tanar1 számára ---");
            tanar1.FizetesEmeles(tanar1, 20000);
            Console.WriteLine(tanar1.ToString());
            // Várható kimenet: Tanar neve: Deák Csaba, Eletkora: 30, ..., fizetese: 320000

            Console.WriteLine("\n--- Teszt 4: Ösztöndíjemelés diak2 számára ---");
            diak2.OsztondijEmeles(diak2, 10000);
            Console.WriteLine(diak2.ToString());
            // Várható kimenet: Diak neve: Nagy Péter, Eletkora: 17, allapota: 90, osztondij: 70000

            Console.WriteLine("\n--- Teszt 5: Tanár óraadás (sikeres eset) ---");
            tanar1.OratAd(tanar1, tizenharmadikB);
            tizenharmadikB.Osztalyterem();
            // Várható kimenet (minden diák _elmeAllapot értéke csökken 10-zel):
            // Diak neve: Kovács Anna, Eletkora: 16, allapota: 70, osztondij: 50000
            // Diak neve: Nagy Péter, Eletkora: 17, allapota: 80, osztondij: 70000
            // Diak neve: Tóth Bence, Eletkora: 17, allapota: 30, osztondij: 40000

            Console.WriteLine("\n--- Teszt 6: Tanár óraadás (sikertelen eset, rossz szak) ---");
            tanar2.OratAd(tanar2, tizenharmadikB);
            // Várható kimenet: "A Szaktanarnak nem itt van oraja!"

            Console.WriteLine("\n--- Teszt 7: Diák felvétele és eltávolítása ---");
            tizenharmadikA.felvesz(diak4);
            tizenharmadikA.Osztalyterem();
            // Várható kimenet:
            // Diak neve: Szabó Eszter, Eletkora: 16, allapota: 70, osztondij: 45000
            // Diak neve: Tóth Bence, Eletkora: 17, allapota: 30, osztondij: 40000
            tizenharmadikA.Ekltanacsol(diak4);
            Console.WriteLine("Diák eltávolítása után:");
            tizenharmadikA.Osztalyterem();
            // Várható kimenet:
            // Diak neve: Szabó Eszter, Eletkora: 16, allapota: 70, osztondij: 45000

            Console.WriteLine("\n--- Teszt 8: Tanár felvétele és kirúgása ---");
            tanarok.Felvesz(tanar3);
            tanarok.Tanari();
            // Várható kimenet: mindhárom tanár adatai
            tanarok.Kirug(tanar3);
            Console.WriteLine("Tanár kirúgása után:");
            tanarok.Tanari();
            // Várható kimenet: csak tanar1 és tanar2 adatai

            Console.WriteLine("\n--- Teszt 9: Edge case - üres osztály ---");
            Osztaly uresOsztaly = new Osztaly(new List<Diak>(), "Fizika");
            uresOsztaly.Osztalyterem();
            // Várható kimenet: üres, nem ír ki semmit

            Console.WriteLine("\n--- Teszt 10: FigyelE metódus tesztelése ---");
            diak1.FigyelE(diak1); // elmeAllapot: 70, várható: semmi, mert >= 50
            diak4.FigyelE(diak4); // elmeAllapot: 30, várható: "Tóth Bence elkalandozott"

        }
    }
}
