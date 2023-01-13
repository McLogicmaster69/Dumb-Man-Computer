using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public static class Binary
    {
        public static string DenToBin(int number, int length)
        {
            int workingValue = number;
            string output = "";
            for (int i = length; i > 0; i--)
            {
                if(workingValue >= Math.Pow(2, i - 1))
                {
                    workingValue -= (int)Math.Pow(2, i - 1);
                    output += "1";
                }
                else
                {
                    output += "0";
                }
            }
            return output;
        }
        public static int BinToDen(string binary)
        {
            int output = 0;
            for (int i = 0; i < binary.Length; i++)
            {
                if (binary[i] == '1')
                    output += (int)Math.Pow(2, binary.Length - i - 1);
            }
            return output;
        }
    }
}
