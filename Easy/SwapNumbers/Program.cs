using System;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                foreach (string word in line.Split(' '))
                {
                    char first = word[0];
                    char last = word[word.Length - 1];

                    if (first != last)
                        Console.Write(last + word.Substring(1, word.Length - 2) + first + ' '); 
                    else
                        Console.Write(word + ' '); 
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
