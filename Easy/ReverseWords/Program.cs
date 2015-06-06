using System;
using System.IO;

namespace ReverseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach(var line in File.ReadLines(args[0]))
            {
                if (line.Length < 3)
                {
                    continue;
                }
                
                string[] words = line.Split(' ');

                if (words.Length > 0)
                {
                    for(int i = words.Length - 1; i >= 0; --i)
                    {
                        Console.Write(words[i] + " ");
                    }

                    Console.Write(Environment.NewLine);
                }                
            }
        }
    }
}