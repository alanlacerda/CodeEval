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
                int limit = words.Length;

                for (int index = 0; index < limit; ++index)
                {
                    int key;

                    if (index < indexes.Length)
                    {
                        key = int.Parse(indexes[index]);
                        sum += key;
                    }
                    else
                    {
                        key = (int)((index + 2) * ((index + 1) / 2.00) - sum);
                    }

                    sortedWords.Add(key, words[index]);
                }

                foreach(string value in sortedWords.Values)
                {
                    Console.Write(value + " ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}