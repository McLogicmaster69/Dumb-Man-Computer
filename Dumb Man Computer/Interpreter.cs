using Dumb_Man_Computer.Exceptions;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dumb_Man_Computer
{
    public class Interpreter
    {
        private readonly List<string> Keywords = new List<string>() { "HLT", "ADD", "SUB", "STA", "LDA", "BRA", "BRZ", "BRP", "INP", "OUT", "DAT", "CON", "MUL", "DIV", "ADN", "SUN", "LBS", "RBS", "LBR", "RBR", "SET", "MUN", "DIN", /*GRAPHICS*/ "GRO", "GRC", "GRR", "GRP", "GRW", "GRH", "GRE", "GRD", "GRS"};
        private const string Numbers = "0123456789";
        public MemoryByte[] Interpret(List<string> commands)
        {
            List<MemoryByte> bytes = new List<MemoryByte>();
            foreach (string command in commands)
            {
                string[] phrases = command.Split(' ');
                int commandValue = 0;
                for (int i = 0; i < Keywords.Count; i++)
                {
                    if (Keywords[i] == phrases[0])
                    {
                        commandValue = i;
                        break;
                    }
                }
                bytes.Add(new MemoryByte(commandValue, int.Parse(phrases[1])));
            }
            return bytes.ToArray();
        }
        public List<string> ConvertToCommands(string inputText, out Exception exception)
        {
            string text = inputText;
            exception = null;
            if(text == "")
                return new List<string>();

            // REMOVE WHITESPACE

            while (true)
            {
                if (text[text.Length - 1] == '\n')
                    text = text.Remove(text.Length - 2);
                else if (text[text.Length - 1] == ' ')
                    text = text.Remove(text.Length - 1);
                else
                    break;
            }
            while (true)
            {
                if (text[0] == ' ')
                    text = text.Substring(1);
                else if (text[0] == '\r')
                    text = text.Substring(2);
                else
                    break;
            }
            int cur = 0;
            bool lastSpace = false;
            bool lastEnter = false;
            while(cur < text.Length)
            {
                if (text[cur] == ' ')
                {
                    if (lastSpace)
                    {
                        lastEnter = false;
                        text = text.Remove(cur, 1);
                    }
                    else
                    {
                        if (lastEnter)
                        {
                            text = text.Remove(cur, 1);
                        }
                        else
                        {
                            lastSpace = true;
                            cur++;
                        }
                    }
                }
                else if(text[cur] == '\r')
                {
                    lastSpace = false;
                    if (lastEnter)
                    {
                        text = text.Remove(cur, 2);
                    }
                    else
                    {
                        lastEnter = true;
                        cur += 2;
                    }
                }
                else
                {
                    lastSpace = false;
                    lastEnter = false;
                    cur++;
                }
            }
            cur = text.Length - 1;
            lastEnter = false;
            while(cur >= 0)
            {
                if(text[cur] == '\n')
                {
                    lastEnter = true;
                    cur -= 2;
                }
                else if(text[cur] == ' ')
                {
                    if (lastEnter)
                    {
                        text = text.Remove(cur, 1);
                        cur--;
                    }
                    else
                    {
                        cur--;
                    }
                }
                else
                {
                    lastEnter = false;
                    cur--;
                }
            }

            // EXTRACT TEXT

            string[] lines = text.Split('\r');
            for (int i = 1; i < lines.Length; i++)
            {
                lines[i] = lines[i].Remove(0, 1);
            }

            // EXTEND CON

            List<string> newLines = new List<string>();
            for (int i = 0; i < lines.Length; i++)
            {
                string[] phrases = lines[i].Split(' ');
                if (phrases.Length > 3)
                {
                    exception = new Exception(ExceptionType.LineOverflow, i);
                    return null;
                }
                if (phrases.Length == 0)
                {
                    exception = new Exception(ExceptionType.LineUnderflow, i);
                    return null;
                }
                if(phrases.Length == 3)
                {
                    if(phrases[1] == "CON")
                    {
                        if (int.TryParse(phrases[2], out int value))
                        {
                            newLines.Add(lines[i]);
                            for (int j = 1; j < value; j++)
                            {
                                newLines.Add("CON");
                            }
                        }
                        else
                        {
                            exception = new Exception(ExceptionType.NonInteger);
                            return null;
                        }
                    }
                    else
                    {
                        newLines.Add(lines[i]);
                    }
                }
                else if(phrases.Length == 2)
                {
                    if(phrases[0] == "CON")
                    {
                        if (int.TryParse(phrases[1], out int value))
                        {
                            newLines.Add(lines[i]);
                            for (int j = 1; j < value; j++)
                            {
                                newLines.Add("CON");
                            }
                        }
                        else
                        {
                            exception = new Exception(ExceptionType.NonInteger);
                            return null;
                        }
                    }
                    else
                    {
                        newLines.Add(lines[i]);
                    }
                }
                else
                {
                    newLines.Add(lines[i]);
                }
            }

            lines = newLines.ToArray();

            // Collect flags

            List<string> flagIdentifiers = new List<string>();
            List<int> flagLocations = new List<int>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] phrases = line.Split(' ');
                if(phrases.Length > 3)
                {
                    exception = new Exception(ExceptionType.LineOverflow, i);
                    return null;
                }
                if(phrases.Length == 0)
                {
                    exception = new Exception(ExceptionType.LineUnderflow, i);
                    return null;
                }

                if(phrases.Length == 3)
                {
                    if (Keywords.Contains(phrases[0]))
                    {
                        exception = new Exception(ExceptionType.ReservedKeyword, i);
                        return null;
                    }
                    if (Numbers.Contains(phrases[0][0]))
                    {
                        exception = new Exception(ExceptionType.InvalidIdentifier, i);
                        return null;
                    }
                    if (!Keywords.Contains(phrases[1]))
                    {
                        exception = new Exception(ExceptionType.UnknownCommand, i);
                        return null;
                    }
                    if(phrases[0][0] == '-')
                    {
                        exception = new Exception(ExceptionType.InvalidIdentifier, i);
                        return null;
                    }
                    flagIdentifiers.Add(phrases[0]);
                    flagLocations.Add(i);
                }
                else if(phrases.Length == 2)
                {
                    if (!Keywords.Contains(phrases[0]))
                    {
                        if (Numbers.Contains(phrases[0][0]))
                        {
                            exception = new Exception(ExceptionType.InvalidIdentifier, i);
                            return null;
                        }
                        if (!Keywords.Contains(phrases[1]))
                        {
                            exception = new Exception(ExceptionType.UnknownCommand, i);
                            return null;
                        }
                        if (phrases[0][0] == '-')
                        {
                            exception = new Exception(ExceptionType.InvalidIdentifier, i);
                            return null;
                        }
                        flagIdentifiers.Add(phrases[0]);
                        flagLocations.Add(i);
                    }
                }
                else if(phrases.Length == 1)
                {
                    if(phrases[0] == "")
                    {
                        exception = new Exception(ExceptionType.UnknownCommand, i);
                        return null;
                    }
                    if (!Keywords.Contains(phrases[0]))
                    {
                        if (Numbers.Contains(phrases[0][0]))
                        {
                            exception = new Exception(ExceptionType.InvalidIdentifier, i);
                            return null;
                        }
                        if (phrases[0][0] == '-')
                        {
                            exception = new Exception(ExceptionType.InvalidIdentifier, i);
                            return null;
                        }
                        flagIdentifiers.Add(phrases[0]);
                        flagLocations.Add(i);
                    }
                }
            }

            // Replace flags

            List<string> commands = new List<string>();

            for (int i = 0; i < lines.Length; i++)
            {
                string line = lines[i];
                string[] phrases = line.Split(' ');
                if (phrases.Length == 3)
                {
                    if (!Keywords.Contains(phrases[1]))
                    {
                        exception = new Exception(ExceptionType.UnknownCommand, i);
                        return null;
                    }
                    if (phrases[2][0] == '-')
                    {
                        string possibleKeyword = phrases[2].Remove(0, 1); 
                        if (flagIdentifiers.Contains(possibleKeyword))
                        {
                            int pos = 0;
                            for (int j = 0; j < flagIdentifiers.Count; j++)
                            {
                                if (flagIdentifiers[j] == possibleKeyword)
                                {
                                    pos = j;
                                    break;
                                }
                            }
                            string newLine = $"{phrases[1]} -{flagLocations[pos]}";
                            commands.Add(newLine);
                        }
                        else
                        {
                            if (int.TryParse(phrases[2], out int value))
                            {
                                if (value <= OSConstants.MinValue || value >= OSConstants.MaxValue)
                                {
                                    exception = new Exception(ExceptionType.InvalidMemoryLocation, i);
                                    return null;
                                }
                                string newLine = $"{phrases[1]} {phrases[2]}";
                                commands.Add(newLine);
                            }
                            else
                            {
                                exception = new Exception(ExceptionType.NonInteger, i);
                                return null;
                            }
                        }
                    }
                    else if (flagIdentifiers.Contains(phrases[2]))
                    {
                        int pos = 0;
                        for (int j = 0; j < flagIdentifiers.Count; j++)
                        {
                            if(flagIdentifiers[j] == phrases[2])
                            {
                                pos = j;
                                break;
                            }
                        }
                        string newLine = $"{phrases[1]} {flagLocations[pos]}";
                        commands.Add(newLine);
                    }
                    else
                    {
                        if (int.TryParse(phrases[2], out int value))
                        {
                            if (value <= OSConstants.MinValue || value >= OSConstants.MaxValue)
                            {
                                exception = new Exception(ExceptionType.InvalidMemoryLocation, i);
                                return null;
                            }
                            string newLine = $"{phrases[1]} {phrases[2]}";
                            commands.Add(newLine);
                        }
                        else
                        {
                            exception = new Exception(ExceptionType.NonInteger, i);
                            return null;
                        }
                    }
                }
                else if(phrases.Length == 2)
                {
                    if (Keywords.Contains(phrases[0]))
                    {
                        if (phrases[1][0] == '-')
                        {
                            string possibleKeyword = phrases[1].Remove(0, 1);
                            if (flagIdentifiers.Contains(possibleKeyword))
                            {
                                int pos = 0;
                                for (int j = 0; j < flagIdentifiers.Count; j++)
                                {
                                    if (flagIdentifiers[j] == possibleKeyword)
                                    {
                                        pos = j;
                                        break;
                                    }
                                }
                                string newLine = $"{phrases[0]} -{flagLocations[pos]}";
                                commands.Add(newLine);
                            }
                            else
                            {
                                if (int.TryParse(phrases[1], out int value))
                                {
                                    if (value <= OSConstants.MinValue || value >= OSConstants.MaxValue)
                                    {
                                        exception = new Exception(ExceptionType.InvalidMemoryLocation, i);
                                        return null;
                                    }
                                    string newLine = $"{phrases[0]} {phrases[1]}";
                                    commands.Add(newLine);
                                }
                                else
                                {
                                    exception = new Exception(ExceptionType.NonInteger, i);
                                    return null;
                                }
                            }
                        }
                        else if (flagIdentifiers.Contains(phrases[1]))
                        {
                            int pos = 0;
                            for (int j = 0; j < flagIdentifiers.Count; j++)
                            {
                                if (flagIdentifiers[j] == phrases[1])
                                {
                                    pos = j;
                                    break;
                                }
                            }
                            string newLine = $"{phrases[0]} {flagLocations[pos]}";
                            commands.Add(newLine);
                        }
                        else
                        {
                            if (int.TryParse(phrases[1], out int value))
                            {
                                if (value <= OSConstants.MinValue || value >= OSConstants.MaxValue)
                                {
                                    exception = new Exception(ExceptionType.InvalidMemoryLocation, i);
                                    return null;
                                }
                                string newLine = $"{phrases[0]} {phrases[1]}";
                                commands.Add(newLine);
                            }
                            else
                            {
                                exception = new Exception(ExceptionType.NonInteger, i);
                                return null;
                            }
                        }
                    }
                    else if (Keywords.Contains(phrases[1]))
                    {
                        string newLine = $"{phrases[1]} 0";
                        commands.Add(newLine);
                    }
                    else
                    {
                        exception = new Exception(ExceptionType.UnknownCommand, i);
                        return null;
                    }
                }
                else if(phrases.Length == 1)
                {
                    if (Keywords.Contains(phrases[0]))
                    {
                        string newLine = $"{phrases[0]} 0";
                        commands.Add(newLine);
                    }
                    else
                    {
                        exception = new Exception(ExceptionType.UnknownCommand, i);
                        return null;
                    }
                }
            }

            exception = null;
            return commands;
        }
    }
}