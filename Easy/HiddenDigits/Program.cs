using System;
using System.IO;

namespace HiddenDigits
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                bool found = false;

                foreach(char character in line)
                {
                    if (char.IsDigit(character))
                    {
                        Console.Write(character);
                        found = true;
                    }
                    else if (character >= 'a' && character < 'k')
                    {
                        Console.Write(character - 'a');
                        found = true;
                    }
                }

                if (!found)
                {
                    Console.Write("NONE");
                }

                Console.Write(Environment.NewLine);
            }

            Console.Read();
        }
    }
}
