namespace zoldsegek
{
    internal class Program
    {
        class Vegetables
        {
            public string _name { get; set; }
            public double _weight { get; set; }
            public int _valueinkg { get; set; }
            public Vegetables()
            {
                _name = "Vegetable";
                _weight = 0;
                _valueinkg = 0;
            }
            public override string ToString()
            {
                return $"Vegetables name: {_name}, Weight: {_weight}, ValueInKg: {_valueinkg}Ft/kg, Value: {this.GetValue()}Ft";
            }
            public Vegetables(string name, double weight, int valueinkg)
            {
                _name = name;
                _weight = weight;
                _valueinkg = valueinkg;
            }
            public double GetValue()
            {
                return _weight * _valueinkg;
            }
        }
        class Carrot : Vegetables
        {
            public double _lenght;
            public Carrot(double weight, int valueinkg, double lenght) : base("Carrot", weight, valueinkg)
            {
                _lenght = lenght;
            }
            public override string ToString()
            {
                return base.ToString() + $" Lenght: {_lenght}cm";
            }
        }
        class Potato : Vegetables
        {
            public string _type { get; set; }
            public Potato(double weight, int valueinkg, string type) : base("Potato", weight, valueinkg)
            {
                _type = type;
            }
            public override string ToString()
            {
                return base.ToString() + $" Type: {_type}";
            }
        }
        static void Main(string[] args)
        {
            Vegetables vegetable = new Vegetables("Cabbage", 1.2, 1000);
            Carrot carrot = new Carrot(1, 400, 20);
            Potato potato = new Potato(0.5, 345, "Sweet");
            List<Vegetables> vegetables = new List<Vegetables>();
            vegetables.Add(potato);
            vegetables.Add(carrot);
            vegetables.Add(vegetable);

            // kiiratas
            foreach (var item in vegetables)
            {
                Console.WriteLine(item);
            }
            // mennyibe kerulnek a listaban levo zoldsegek
            double valuesum = 0;
            foreach (var item in vegetables)
            {
                valuesum += item.GetValue();
            }
            Console.WriteLine($"Sum of value in the list: {valuesum}Ft");
            // legolcsobb peldany
            Vegetables min = vegetables[0];
            foreach (var item in vegetables)
            {
                if (min.GetValue() > item.GetValue()) min = item;
            }
            Console.WriteLine($"Cheapest element in the list: {min._name}");
            // hany nem repa
            int notcarrot = 0;
            foreach (var item in vegetables)
            {
                if (item is not Carrot) notcarrot++;
            }
            Console.WriteLine($"Not carrots count: {notcarrot}");
        }
    }
}
