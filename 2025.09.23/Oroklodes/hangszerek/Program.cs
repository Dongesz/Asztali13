namespace hangszerek
{
    internal class Program
    {
        static void Main(string[] args)
        {
            InstrumentCollection instrumentcollection = new InstrumentCollection();
            instrumentcollection.Add(new StringInstrument("Violin", "wood", 4));
            instrumentcollection.Add(new StringInstrument("cello", "wood", 4));
            instrumentcollection.Add(new Instrument("guitar", "wood"));
            instrumentcollection.Add(new Instrument("guitar", "metal"));
            instrumentcollection.lists(null);
            instrumentcollection.Add(new Instrument("guitar", "wood"));
            instrumentcollection.lists(null);
            instrumentcollection.Tune();
        }
    }
}
