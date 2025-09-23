using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangszerek
{
    internal class InstrumentCollection
    {
        private List<Instrument> instrumentList;

        public InstrumentCollection()
        {
            this.instrumentList = new List<Instrument>();
        }
        public void Add(Instrument instrument)
        {
           foreach (var item in instrumentList)
            {
                if (!(instrument._name == item._name)) instrumentList.Add(item);
                else Console.WriteLine("List already contains this item!");
            }
        }
        public void lists(string materialsort)
        {
            foreach (var item in instrumentList)
            {
                if (materialsort != null && item._material == materialsort) Console.WriteLine(item.Info());
                else Console.WriteLine(item.Info());
            }
        }
        public void Tune()
        {
            foreach (var item in instrumentList)
            {
                if (item is StringInstrument)
                {
                    ((StringInstrument)item).Tuning();
                }
            }
        }

    }
}
