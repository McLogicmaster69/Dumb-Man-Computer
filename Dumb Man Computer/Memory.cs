
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public class Memory
    {
        public MemoryByte[] Bytes = new MemoryByte[OSConstants.MaxValue];
        public Memory()
        {
            for (int i = 0; i < Bytes.Length; i++)
            {
                Bytes[i].SetValue(0, 0);
                Bytes[i].MemoryLocation = i;
            }
        }
    }
}
