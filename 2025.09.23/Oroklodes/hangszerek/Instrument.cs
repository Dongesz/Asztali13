using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace hangszerek
{
    public class Instrument
    {
        public string _name {  get; protected set; }
        public string _material {  get; private set; }
        public Instrument(string name, string material)
        {
            _name = name;
            _material = material;
        }
        public virtual string Info()
        {
            return $"Name of instrument: {_name}, Material: {_material}";
        }
    }
}
