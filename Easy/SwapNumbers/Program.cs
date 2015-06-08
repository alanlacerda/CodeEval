using System;
using System.IO;

namespace SwapNumbers
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                string[] words = line.Split(' ');

                foreach (string word in words)
                {
                    char first = word[0];
                    char last = word[word.Length - 1];

                    if (first == last)
                    {
                        Console.Write(word + ' '); 
                    }
                    else
                    {
                        Console.Write(last + word.Substring(1, word.Length - 2) + first + ' ');
                    }
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
