namespace ConsoleApp3
{
    internal class Program
    {
        public class Kerek
        {
            private string _brand;
            private int _diameter;
            private int _width;
            private bool _season;
            private float _textureDepth;

            public Kerek(string brand, int diameter, int width, bool season, float textureDepth)
            {
                _brand = brand;
                _diameter = diameter;
                _width = width;
                _season = season;
                _textureDepth = textureDepth;
            }
            
            public override string ToString()
            {
                return $"A kerek márkaja: {_brand}, átmeroje: {_diameter}col, szelessege: {_width}, teli/nyari:{(_season ? "teli" : "nyari")}, minta melysege: {_textureDepth}mm";
            }
            public override bool Equals(object? obj)
            {
                if (obj != null && obj is Kerek && this._brand == ((Kerek)obj)._brand && this._width == ((Kerek)obj)._width && this._diameter == ((Kerek)obj)._diameter)
                {
                    return true ;
                } else return false ;
            }
            public bool Usable()
            {
                if (_textureDepth > 2.6f) return true ;
                else return false ;
            }      
        }
        public class KerekTarolo
        {
            private List<Kerek> _list = new List<Kerek>();

            public void Add(Kerek kerek)
            {
                if (_list.Count < 100)
                   _list.Add(kerek);
                else Console.WriteLine("A tarolo megtelt!");
            }
            public void Remove(Kerek kerek)
            {
                _list.Remove(kerek);
            }
            public Kerek Find(string brand, int dimeter, int width, bool season, float textureDepth)
            {
                Kerek keresett = new Kerek(brand, dimeter, width, true, 0);
                foreach (Kerek item in _list)
                {
                    if (item.Equals(keresett)) return item;
                   
                }
                return null;
            }
            public void Show()
            {
                foreach (Kerek kerek in _list)
                {
                    Console.WriteLine(kerek);
                }
            }
            public KerekTarolo(List<Kerek> list)
            {
                _list = list ;
            }

        }
        static void Main(string[] args)
        {
            Kerek wheel1 = new Kerek("marka1", 16, 10, true, 3.5f) ;
            Kerek wheel2 = new Kerek("marka2", 36, 6, true, 3.7f) ;
            Kerek wheel3 = new Kerek("marka3", 17, 9, true, 1.1f) ;
            Kerek wheel4 = new Kerek("marka4", 13, 11, true, 3.9f) ;

            List<Kerek> _list = new List<Kerek>();
            _list.Add(wheel1);
            _list.Add(wheel2);
            _list.Add(wheel3);
            _list.Add(wheel4);

            KerekTarolo tarolo = new KerekTarolo(_list);
            Kerek wheel5 = new Kerek("marka5", 11, 5, true, 2.5f);
            tarolo.Add(wheel5);
            tarolo.Remove(wheel2);

            Kerek keresett = tarolo.Find("marka4", 13, 11, true, 3.9f);

            if (!(keresett is null)) Console.WriteLine("Talalat!");

            tarolo.Show();
            
        }
    }
}
