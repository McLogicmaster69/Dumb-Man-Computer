using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public class MemoryTracker
    {
        public MemoryList[] Log;
        public MemoryTracker(int size)
        {
            Log = new MemoryList[size];
            for (int i = 0; i < size; i++)
            {
                Log[i] = new MemoryList();
            }
        }
        public void LogMemory(int[] memory)
        {
            for (int i = 0; i < memory.Length; i++)
            {
                Log[i].List.Add(memory[i]);
            }
        }
    }
}
