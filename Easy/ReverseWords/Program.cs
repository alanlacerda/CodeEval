using System;
using System.IO;

namespace ReverseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            var before = GC.GetTotalMemory(false);
            
            foreach(var line in File.ReadLines(args[0]))
            {
                if (line.Length < 3)
                {
                    continue;
                }
                
                string[] words = line.Split(' ');
                int limit = words.Length - 1;

                for (int i = limit; i >= 0; --i)
                {
                    Console.Write(words[i] + " ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}