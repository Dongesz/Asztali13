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
                return $"A kerek márkaja: {_brand}, átmeroje: {_diameter}, szelessege: {_width}, teli/nyari:{(_season ? "teli" : "nyari")}, minta melysege: {_textureDepth}";
            }
            public override bool Equals(object? obj)
            {
                if (obj != null && obj is Kerek && this._diameter == ((Kerek)obj)._diameter && this._width == ((Kerek)obj)._width)
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

        }
        static void Main(string[] args)
        {

        }
    }
}
