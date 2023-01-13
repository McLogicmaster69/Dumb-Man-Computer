using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer.Exceptions
{
    public enum ExceptionType
    {
        // COMPILE
        LineOverflow,
        LineUnderflow,
        UnknownCommand,
        UnknownIdentifier,
        ReservedKeyword,
        NonInteger,
        InvalidIdentifier,
        InvalidMemoryLocation,
        InvalidTrackedLabel,
        
        // RUNTIME
        InvalidFormSize,
        PixelOutOfRange,
    }
    public class Exception
    {
        public readonly ExceptionType Type;
        public readonly int Line = -1;
        public Exception(ExceptionType type)
        {
            Type = type;
        }
        public Exception(ExceptionType type, int line)
        {
            Type = type;
            Line = line;
        }
    }
}
