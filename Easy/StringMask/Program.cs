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
                int index = line.IndexOf(' ');

                string word = line.Substring(0, index);
                string mask = line.Substring(index + 1);

                for (index = 0; index < word.Length; index++)
                {
                    Console.Write(mask[index] == '1'
                        ? char.ToUpper(word[index])
                        : word[index]);
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}