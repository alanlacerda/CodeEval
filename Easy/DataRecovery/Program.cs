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
                string[] words = CopyUntilDelimiter(line, ';').Split(' ');
                string[] indexes = CopyUntilDelimiter(line, ';', true).Split(' ');

                var sortedWords = new SortedDictionary<int, string>();
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

        private static string CopyUntilDelimiter(string input, char delimiter, bool backwards = false)
        {
            string output = "";

            if (backwards)
            {
                for (int i = input.Length - 1; i >= 0; --i)
                {
                    if (input[i] == delimiter)
                    {
                        return output;
                    }

                    output = input[i] + output;
                }
            }
            else
            {
                foreach (char c in input)
                {
                    if (c == delimiter)
                    {
                        return output;
                    }

                    output = output + c;
                }
            }

            return output;
        }
    }
}