using System.ComponentModel;

namespace ConsoleApp2
{
    internal class Program
    {
        public class Konyv
        {
            private string _author;
            private string _title;
            private int _age;
            private int _value;

            public Konyv(string author, string title, int age, int value)
            {
                _author = author;
                _title = title;
                _age = age;
                _value = value;
            }
            public override string ToString()
            {
                return $"Szerzo: {_author}, Cim: {_title}, Ev: {_age}, Ar: {_value}";
            }
            public bool antik()
            {
                if (this._age <= 1950) return true;
                else return false;
            }
            public class KonyvesBolt
            {
                private List<Konyv> _antikKonyvek = new List<Konyv>();

                public void Add(Konyv konyv)
                {
                    if (konyv.antik() && konyv != null)
                    {
                        _antikKonyvek.Add(konyv);
                    }
                    else Console.WriteLine("Csak antik könyveket vasarlunk!");
                }
                public void Remove(Konyv konyv)
                {
                    _antikKonyvek.Remove(konyv);
                }
                public void Show()
                {
                    foreach (var item in _antikKonyvek)
                    {
                        Console.WriteLine(item);
                    }
                }
            }
            static void Main(string[] args)
            {
                Konyv konyv1 = new Konyv("szerzo1", "konyv1", 43, 5000);
                Konyv konyv2 = new Konyv("szerzo2", "konyv2", 53, 8999);
                Konyv konyv3 = new Konyv("szerzo3", "konyv3", 47, 6673);
                Konyv konyv4 = new Konyv("szerzo4", "konyv4", 21, 4563);

                KonyvesBolt bolt = new KonyvesBolt();

                bolt.Add(konyv1);
                bolt.Add(konyv2);
                bolt.Add(konyv3);
                bolt.Add(konyv4);
                bolt.Show();
            }
        }
    }
}
