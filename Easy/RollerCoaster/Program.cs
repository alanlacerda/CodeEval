using System;
using System.IO;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                if (line.Length == 0)
                {
                    continue;
                }

                bool wasUpper = false;
                    
                foreach (string word in line.Split(' '))
                {
                    foreach (char character in word)
                    {
                        if (char.IsLetter(character))
                        {
                            Console.Write(wasUpper ? char.ToLower(character) : char.ToUpper(character));

                            wasUpper = !wasUpper;
                        }
                        else
                        {
                            Console.Write(character);    
                        }
                    }

                    Console.Write(" ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
