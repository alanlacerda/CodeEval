using System;
using System.IO;

namespace CompressedSequence
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                int count = 0;
                string number = "";

                foreach (string current in line.Split(' '))
                {
                    if (string.Equals(number, ""))
                    {
                        number = current;
                    }

                    if (string.Equals(number, current))
                    {
                        ++count;
                    }
                    else
                    {
                        Console.Write(count + " " + number + " ");
                        number = current;
                        count = 1;
                    }
                }

                Console.Write(count + " " + number + Environment.NewLine);
            }
        }
    }
}
