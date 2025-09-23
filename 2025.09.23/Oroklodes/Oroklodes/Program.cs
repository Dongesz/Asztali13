namespace Oroklodes
{
    internal class Program
    {
        class Fruit
        {
            public string _name { get; set; }
            public double _weight { get; set; }
            public double _valueinkg { get; set; }

            public Fruit(string name, double weight)
            {
                _name = name;
                _weight = weight;
            }
            public override string ToString()
            {
                return $"Name: {_name}, Weight: {_weight}kg";
            }
            virtual public double GetValue()
            {
                return 1000;
            }
        }

        class Apple : Fruit
        {
            public string _color { get; set; }
            public string _type { get; set; }
            public int _valueinkg { get; set; }
            public Apple(double weight, string color, string type, int valueinkg) : base("Apple", weight)
            {
                _color = color;
                _type = type;
                _valueinkg = valueinkg;
            }
            public override string ToString()
            {
                return base.ToString() + $" Type: {_type}, Color: {_color}";
            }
            public override double GetValue()
            {
                return _weight * _valueinkg;
            }
        }
        static void Main(string[] args)
        {
            Fruit fruit1 = new Fruit("Apple", 0.5);
            Fruit fruit2 = new Fruit("Pear", 0.8);
            Apple apple1 = new Apple(1, "green", "green apple", 600);
            Apple apple2 = new Apple(1, "yellow", "Golden", 550);
            Apple apple3 = new Apple(1, "red", "Gala", 450);

            List<Fruit> fruits = new List<Fruit>();
            fruits.Add(apple1);
            fruits.Add(apple2);
            fruits.Add(apple3);
            fruits.Add(fruit1);
            fruits.Add(fruit2);

            // osszes gyumolcs kiiratasa
            foreach (var item in fruits)
            {
                Console.WriteLine(item);
            }
            // osszes gyumolcs tomege
            double weightsum = 0;
            foreach (var item in fruits)
            {
                weightsum += item._weight;
            }
            Console.WriteLine($"Weight of all fruit: {weightsum}kg");
            // hany piros gyumolcs van
            int reds = 0;
            foreach (var item in fruits)
            {
                if (item is Apple && ((Apple)item)._color.ToLower() == "red")
                {
                    reds++;
                }
            }
            Console.WriteLine($"Red fruits count: {reds}");
            // hany nem alma van
            int notapple = 0;
            foreach (var item in fruits)
            {
                if (item is not Apple) notapple++;
            }
            Console.WriteLine($"Not apples count: {notapple}");
            // mennyi az erteke az osszes gyumolcsnek
            double valuesum = 0;
            foreach (var item in fruits)
            {
                valuesum += item.GetValue();
            }
            Console.WriteLine($"Value of all fruits: {valuesum}");
        }
    }
}
