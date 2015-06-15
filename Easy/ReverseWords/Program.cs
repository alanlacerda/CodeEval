using System;

namespace ReverseWords
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                var words = line.Split(' ');
                int limit = words.Length - 1;

                for (int i = limit; i >= 0; --i)
                {
                    Console.Write(words[i] + ' ');
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}