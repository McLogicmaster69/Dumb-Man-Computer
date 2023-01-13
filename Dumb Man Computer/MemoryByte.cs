using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public struct MemoryByte
    {
        public string Value;
        public int MemoryLocation;
        public MemoryByte(int value)
        {
            Value = Binary.DenToBin(value, OSConstants.ByteSize);
            MemoryLocation = 0;
        }
        public MemoryByte(int instruction, int value)
        {
            MemoryLocation = 0;
            if (value >= 0)
                Value = Binary.DenToBin(instruction, OSConstants.CommandSize) + "0" + Binary.DenToBin(value, OSConstants.ValueSize);
            else
                Value = Binary.DenToBin(instruction, OSConstants.CommandSize) + "1" + Binary.DenToBin(-value, OSConstants.ValueSize);
        }
        public void SetValue(int value)
        {
            Value = Binary.DenToBin(value, OSConstants.ByteSize);
        }
        public void SetValue(int instruction, int value)
        {
            if (value >= 0)
                Value = Binary.DenToBin(instruction, OSConstants.CommandSize) + "0" + Binary.DenToBin(value, OSConstants.ValueSize);
            else
                Value = Binary.DenToBin(instruction, OSConstants.CommandSize) + "1" + Binary.DenToBin(-value, OSConstants.ValueSize);
        }
        public void SetNumberValue(int value)
        {
            if (value >= 0)
                Value = Value.Substring(0, OSConstants.CommandSize) + "0" + Binary.DenToBin(value, OSConstants.ValueSize);
            else
                Value = Value.Substring(0, OSConstants.CommandSize) + "1" + Binary.DenToBin(-value, OSConstants.ValueSize);
            return;
        }
        public int GetCommandID()
        {
            return Binary.BinToDen(Value.Substring(0, OSConstants.CommandSize));
        }
        public int GetNumberValue()
        {
            if(Value[OSConstants.CommandSize] == '0')
                return Binary.BinToDen(Value.Substring(OSConstants.CommandSize + 1, OSConstants.ValueSize));
            else
                return -Binary.BinToDen(Value.Substring(OSConstants.CommandSize + 1, OSConstants.ValueSize));
        }
        public int GetValue()
        {
            return Binary.BinToDen(Value);
        }
    }
}
