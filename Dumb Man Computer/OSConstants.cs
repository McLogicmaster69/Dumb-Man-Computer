using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public static class OSConstants
    {
        public static int ByteSize { get { return CommandSize + ValueSize + 1; } }
        public static int MaxValue { get { return (int)Math.Pow(2, ValueSize); } }
        public static int MinValue { get { return -MaxValue; } }
        public static readonly int CommandSize = 5;
        public static readonly int ValueSize = 18;
    }
}
