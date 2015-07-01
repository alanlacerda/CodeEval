using System;

namespace StepwiseWord
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                string longest = "";

                foreach (string word in line.Split(' '))
                {
                    if (word.Length > longest.Length)
                        longest = word;
                }

                for (int i = 0; i < longest.Length; ++i)
                {
                    Console.Write(new string('*', i) + longest[i] + ' ');
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
