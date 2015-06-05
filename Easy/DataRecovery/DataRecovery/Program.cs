using System;
using System.Collections.Generic;
using System.IO;

namespace DataRecovery
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                string[] splittedLine = line.Split(';');
                string[] words = splittedLine[0].Split(' ');
                string[] indexes = splittedLine[1].Split(' ');

                var sortedWords = new SortedList<int, string>();
                int sum = 0;
                int index;

                for (int i = 0; i < words.Length; i++)
                {
                    if (i < indexes.Length)
                    {
                        index = int.Parse(indexes[i]);
                        sum += index;
                    }
                    else
                    {
                        index = (int)((i + 2) * ((i + 1) / 2.00) - sum);
                    }

                    sortedWords.Add(index, words[i]);
                }

                Console.WriteLine(string.Join(" ", sortedWords.Values));
            }
        }
    }
}