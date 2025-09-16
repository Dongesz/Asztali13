namespace ConsoleApp1
{
    internal class Program
    {
        class Szemely
        {
            private string _name;
            private int _weight;
            private bool _dLicense;

            public Szemely(string name, int weight, bool dLicense)
            {
                _name = name;
                _weight = weight;
                _dLicense = dLicense;
            }

            public override string ToString()
            {
                return $"Név: {_name}, Súly: {_weight}kg,  Jogosítvány: {(_dLicense?"Van":"Nincs")}";
            }
        }
        static void Main(string[] args)
        {
            Szemely szemely1 = new Szemely("Peti", 55, true);
            Console.WriteLine(szemely1.ToString());
        }
    }
}
