using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public struct LabelledAddress
    {
        public string Label;
        public int Address;
        public LabelledAddress(string label, int address)
        {
            Label = label;
            Address = address;
        }
    }
}
