using System;

namespace DataRecovery
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                int semicolon = line.IndexOf(';');

                var scrambled = line.Substring(0, semicolon).Split(' ');
                var indexes = Array.ConvertAll(line.Substring(semicolon + 1).Split(' '), x => int.Parse(x) - 1);
                int limit = indexes.Length;

                var ordered = new string[limit + 1];
                
                for (int index = 0; index < limit; ++index)
                {
                    ordered[indexes[index]] = scrambled[index];
                }

                for (int index = 0; index <= limit; ++index)
                {
                    Console.Write((ordered[index] ?? scrambled[limit]) + ' ');
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}