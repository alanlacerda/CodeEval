using System;
using System.Collections.Generic;

namespace StringPermutations
{
    public class StringPermutations
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                var permutations = Permute(line);

                permutations.Sort(OrdinalSort);

                int limit = permutations.Count;

                for (int index = 0; index < limit; ++index)
                {
                    if (index == limit - 1)
                        Console.Write(permutations[index] + Environment.NewLine);
                    else
                        Console.Write(permutations[index] + ",");
                }
            }
        }

        public static List<string> Permute(string source)
        {
            var output = new List<string>();

            if (source.Length == 1)
            {
                output.Add(source);
            }
            else
            {
                string character = source[0].ToString();
                string remaining = source.Substring(1);

                foreach (string word in Permute(remaining))
                {
                    for (var index = 0; index <= word.Length; ++index)
                    {
                        output.Add(word.Insert(index, character));
                    }
                }
            }

            return output;
        }

        private static int OrdinalSort(string left, string right)
        {
            for (int index = 0; index < left.Length; ++index)
            {
                int result = left[index] - right[index];

                if (result != 0)
                    return result;
            }

            return 0;
        }
    }
}