using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public class Executer
    {
        private Memory Memory = new Memory();
        private int currentInstruction = 0;
        private int accumulator = 0;

        // GRAPHICS
        private graphicalOutput Graphics = new graphicalOutput();
        private int PixelSize = 10;
        private int Width = 20;
        private int Height = 20;
        private const int MaxFormSize = 3860;
        private const int MinFormSize = 136;

        public void LoadIntoMemory(MemoryByte[] memory)
        {
            Memory = new Memory();
            for (int i = 0; i < memory.Length; i++)
            {
                Memory.Bytes[i].Value = memory[i].Value;
            }

            Graphics = new graphicalOutput();
            PixelSize = 10;
            Width = 20;
            Height = 20; 
            Graphics.RefreshForm(Width, Height, PixelSize);
        }

        public void Execute(out Exceptions.Exception exception)
        {
            currentInstruction = 0;
            accumulator = 0;
            ExecutionCycle(out exception);
        }
        public void Input(int input, out Exceptions.Exception exception)
        {
            accumulator = input;
            ExecutionCycle(out exception);
        }
        private void ExecutionCycle(out Exceptions.Exception exception)
        {
            exception = null;
            while (currentInstruction < OSConstants.MaxValue)
            {
                MemoryByte CurrentByte = Memory.Bytes[currentInstruction];
                int NumberValue = CurrentByte.GetNumberValue();
                string bin;
                switch (Memory.Bytes[currentInstruction].GetCommandID())
                {
                    case 0: // HLT
                        Graphics.Hide();
                        return;
                    case 1: // ADD
                        accumulator += Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue();
                        break;
                    case 2: // SUB
                        accumulator -= Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue(); 
                        break;
                    case 3: // STA
                        if (NumberValue >= 0)
                            Memory.Bytes[NumberValue].SetNumberValue(accumulator);
                        else
                            Memory.Bytes[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()].SetNumberValue(accumulator);
                        break;
                    case 4: // LDA
                        if (NumberValue >= 0)
                            accumulator = Memory.Bytes[NumberValue].GetNumberValue();
                        else
                            accumulator = Memory.Bytes[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()].GetNumberValue();
                        break;
                    case 5: // BRA
                        if (NumberValue >= 0)
                            currentInstruction = NumberValue;
                        else
                            currentInstruction = Math.Abs(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        break;
                    case 6: // BRZ
                        if (accumulator == 0)
                        {
                            if (NumberValue >= 0)
                                currentInstruction = NumberValue;
                            else
                                currentInstruction = Math.Abs(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        }
                        break;
                    case 7: // BRP
                        if (accumulator >= 0)
                        {
                            if (NumberValue >= 0)
                                currentInstruction = NumberValue;
                            else
                                currentInstruction = Math.Abs(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        }
                        break;
                    case 8: // INP
                        mainFrm.main.Input();
                        currentInstruction++;
                        return;
                    case 9: // OUT
                        mainFrm.main.Output(accumulator);
                        break;
                    case 10: // DAT
                        break;
                    case 11: // CON
                        break;
                    case 12: // MUL
                        accumulator *= Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue();
                        break;
                    case 13: // DIV
                        accumulator /= Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue();
                        break;
                    case 14: // ADN
                        accumulator += NumberValue;
                        break;
                    case 15: // SUN
                        accumulator -= NumberValue;
                        break;
                    case 16: // LBS
                        bin = Binary.DenToBin(accumulator, OSConstants.ValueSize);
                        for (int i = 0; i < NumberValue; i++)
                        {
                            bin = bin.Substring(1) + "0";
                        }
                        accumulator = Binary.BinToDen(bin);
                        break;
                    case 17: // RBS
                        bin = Binary.DenToBin(accumulator, OSConstants.ValueSize);
                        for (int i = 0; i < NumberValue; i++)
                        {
                            bin = "0" + bin.Remove(bin.Length - 1);
                        }
                        accumulator = Binary.BinToDen(bin);
                        break;
                    case 18: // LBR
                        bin = Binary.DenToBin(accumulator, OSConstants.ValueSize);
                        for (int i = 0; i < NumberValue; i++)
                        {
                            bin = bin.Substring(1) + bin[0];
                        }
                        accumulator = Binary.BinToDen(bin);
                        break;
                    case 19: // RBR
                        bin = Binary.DenToBin(accumulator, OSConstants.ValueSize);
                        for (int i = 0; i < NumberValue; i++)
                        {
                            bin = bin[bin.Length - 1] + bin.Remove(bin.Length - 1);
                        }
                        accumulator = Binary.BinToDen(bin);
                        break;
                    case 20: // SET
                        accumulator = NumberValue;
                        break;
                    case 21: // MUN
                        accumulator *= NumberValue;
                        break;
                    case 22: // DIN
                        accumulator /= NumberValue;
                        break;
                    case 23: // GRO
                        Graphics.Show();
                        break;
                    case 24: // GRC
                        Graphics.Hide();
                        break;
                    case 25: // GRR
                        if (PixelSize * Width < MinFormSize || PixelSize * Height < MinFormSize || PixelSize * Width > MaxFormSize || PixelSize * Height > MaxFormSize)
                        {
                            exception = new Exceptions.Exception(Exceptions.ExceptionType.InvalidFormSize);
                            return;
                        }
                        Graphics.RefreshForm(Width, Height, PixelSize);
                        break;
                    case 26: // GRP
                        PixelSize = Math.Abs(NumberValue);
                        break;
                    case 27: // GRW
                        Width = Math.Abs(NumberValue);
                        break;
                    case 28: // GRH
                        Height = Math.Abs(NumberValue);
                        break;
                    case 29: // GRE
                        if(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() >= Width * Height || Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() < 0)
                        {
                            exception = new Exceptions.Exception(Exceptions.ExceptionType.PixelOutOfRange);
                            return;
                        }
                        Graphics.Values[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()] = true;
                        Graphics.UpdatePixel(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        break;
                    case 30: // GRD
                        if (Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() >= Width * Height || Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() < 0)
                        {
                            exception = new Exceptions.Exception(Exceptions.ExceptionType.PixelOutOfRange);
                            return;
                        }
                        Graphics.Values[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()] = false;
                        Graphics.UpdatePixel(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        break;
                    case 31: // GRS
                        if (Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() >= Width * Height || Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue() < 0)
                        {
                            exception = new Exceptions.Exception(Exceptions.ExceptionType.PixelOutOfRange);
                            return;
                        }
                        Graphics.Values[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()] = !Graphics.Values[Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue()];
                        Graphics.UpdatePixel(Memory.Bytes[Math.Abs(NumberValue)].GetNumberValue());
                        break;
                }
                if (accumulator >= OSConstants.MaxValue)
                    accumulator -= OSConstants.MaxValue * 2 - 1; 
                if (accumulator <= OSConstants.MinValue)
                    accumulator += OSConstants.MaxValue * 2 - 1;
                currentInstruction++;
            }
        }
    }
}
