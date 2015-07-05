using System;

namespace StringsAndArrows
{
    class Program
    {
        private static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                int count = 0;

                for (int i = 0; i + 4 < line.Length; ++i)
                {
                    string chunk = line.Substring(i, 5);

                    if (chunk == ">>-->" || chunk == "<--<<")
                        ++count;
                }

                Console.WriteLine(count);
            }
        }
    }
}
