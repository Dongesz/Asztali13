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
                return $"Tanar neve: {_nev}, Eletkora: {_kor}, szakmaja: {_szak}, heti oraszama: {_oraszam}, osztalyfonok: {(_osztalyfonok ? "igen" : "nem")}, fizetese: {_fizetes}ft";
            }
            public void FizetesEmeles(Tanar tanar, int emeles)
            {
                if(emeles > 0)
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

            public void Felvesz(Tanar tanar) // Tanar felvetele
            {
                if (tanar != null)
                    _list.Add(tanar);
            }
            public void Kirug(Tanar tanar) // Tanar eltavolitasa
            {
                if (tanar != null)
                    _list.Remove(tanar);
            }
            
            public void Tanari() // Tanarok kilistazasa
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
            public void OsztondijEmeles( int emeles)
            {
                if( emeles > 0)
                    this._osztondij += emeles;
            }
            public void FigyelE() // megallapitja hogy a diak figyel vagy sem
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
            public List<Diak> _diakok = new List<Diak>(); // Az osszes diakot tarolja
            public string _szak;
            public string _osztalyfonok;

            public Osztaly(List<Diak> list, string szak, string osztalyfonok)
            {
                _diakok = list;
                _szak = szak;
                _osztalyfonok = osztalyfonok;
            }

            public void felvesz(Diak diak) // Diak hozzaadasa
            {
                if (diak != null)
                    _diakok.Add(diak);
            }
            public void Ekltanacsol(Diak diak) // Diak eltavolitasa 
            {
                if (diak != null)
                    _diakok.Remove(diak);
            }
            public void Osztalyterem() // Osztaly adatok kilistazasa
            {
                if (_diakok.Count == 0)
                {
                    Console.WriteLine("Üres az osztaly!");
                }
                else
                {
                    Console.WriteLine($"Osztalyfonok: {_osztalyfonok}");
                    foreach (Diak diak in _diakok)
                    {
                        Console.WriteLine(diak);
                    }
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
            Osztaly tizenharmadikB = new Osztaly(informatikaDiakok, "Informatika", "Deak Csaba");
            Osztaly tizenharmadikA = new Osztaly(matematikaDiakok, "Matematika", "Farkas zoltan");

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
            

            Console.WriteLine("\n--- Teszt 2: Tanárok kiíratása ---");
            tanarok.Tanari();
           
            Console.WriteLine("\n--- Teszt 3: Fizetésemelés tanar1 számára ---");
            tanar1.FizetesEmeles(tanar1, 20000);
            Console.WriteLine(tanar1.ToString());

            Console.WriteLine("\n--- Teszt 4: Ösztöndíjemelés diak2 számára ---");
            diak2.OsztondijEmeles(10000);
            Console.WriteLine(diak2.ToString());

            Console.WriteLine("\n--- Teszt 5: Tanár óraadás (sikeres eset) ---");
            tanar1.OratAd(tanar1, tizenharmadikB);
            tizenharmadikB.Osztalyterem();


            Console.WriteLine("\n--- Teszt 6: Tanár óraadás (sikertelen eset, rossz szak) ---");
            tanar2.OratAd(tanar2, tizenharmadikB);

            Console.WriteLine("\n--- Teszt 7: Diák felvétele és eltávolítása ---");
            tizenharmadikA.felvesz(diak4);
            tizenharmadikA.Osztalyterem();

            tizenharmadikA.Ekltanacsol(diak4);
            Console.WriteLine("Diák eltávolítása után:");
            tizenharmadikA.Osztalyterem();


            Console.WriteLine("\n--- Teszt 8: Tanár felvétele és kirúgása ---");
            tanarok.Felvesz(tanar3);
            tanarok.Tanari();
       
            tanarok.Kirug(tanar3);
            Console.WriteLine("Tanár kirúgása után:");
            tanarok.Tanari();


            Console.WriteLine("\n--- Teszt 9: Edge case - üres osztály ---");
            Osztaly uresOsztaly = new Osztaly(new List<Diak>(), "Fizika", "Negyesi Gabor");
            uresOsztaly.Osztalyterem();


            Console.WriteLine("\n--- Teszt 10: FigyelE metódus tesztelése ---");
            diak1.FigyelE();
            diak4.FigyelE(); 
        }
    }
}
