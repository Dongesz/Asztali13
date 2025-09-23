using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangszerek
{
    public class StringInstrument : Instrument
    {
        private int _stringcount {  get; set; }
        public StringInstrument(string name, string material, int stringcount) : base(name, material)
        {
            _stringcount = stringcount;
        }
        public void Tuning()
        {
            Console.WriteLine($"{_stringcount} strings need to be tuned!");
        }

        public override string Info()
        {
            return base.Info + $"Strings count: {_stringcount}";
        }
    }
}
