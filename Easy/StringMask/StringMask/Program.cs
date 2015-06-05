using System;
using System.IO;

namespace StringMask
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(string line in File.ReadLines(args[0]))
            {
                string[] stringAndMask = line.Split(' ');
                
                for (int i = 0; i < stringAndMask[0].Length; i++)
                {
                    char letter = stringAndMask[0][i];

                    if (stringAndMask[1][i] == '1')
                    {
                        letter = char.ToUpper(letter);
                    }

                    Console.Write(letter);
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
