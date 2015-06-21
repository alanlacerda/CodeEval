using System;

namespace FindAWriter
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                int separator = line.IndexOf('|');
                string scrambled = line.Substring(0, separator);

                foreach (string index in line.Substring(separator + 2).Split(' '))
                {
                    Console.Write(scrambled[int.Parse(index) - 1]);
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
