using System;

namespace BeautifulStrings
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                var occurrences = new int[26];

                foreach (char character in line)
                {
                    if (char.IsLetter(character))
                        ++occurrences[char.ToUpper(character) - 'A'];
                }

                Array.Sort(occurrences, (x, y) => x > y ? -1 : 1);

                var maxBeauty = 0;

                for (int index = 0; index < 26 && occurrences[index] != 0; ++index)
                {
                    maxBeauty += occurrences[index] * (26 - index);
                }

                Console.WriteLine(maxBeauty);
            }
        }
    }
}
