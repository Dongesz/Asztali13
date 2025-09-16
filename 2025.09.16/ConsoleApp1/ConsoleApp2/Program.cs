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
                if (this._age <= 1950) return true ;
                else return false ;
            }
            public class KonyvesBolt
            {
                private List<Konyv> _antikKonyvek;

                public void Add(Konyv konyv)
                {
                    if (konyv.antik())
                    {
                        _antikKonyvek.Add(konyv);
                    }
                    else Console.WriteLine("Csak antik könyveket vasarlunk!");      
                }
                public void Remove(Konyv konyv)
                {
                    _antikKonyvek.Remove(konyv);
                }
                public void Show(Konyv konyv)
                {
                    foreach (var item in _antikKonyvek)
                    {
                        Console.WriteLine(item);
                    }
                }
        }
        static void Main(string[] args)
        {

        }
    }
}
