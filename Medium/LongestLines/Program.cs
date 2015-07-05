using System;
using System.Collections.Generic;

namespace LongestLines
{
    class Program
    {
        static void Main(string[] args)
        {
            var lines = new List<string>(System.IO.File.ReadAllLines(args[0]));
            int count = int.Parse(lines[0]);

            lines.RemoveAt(0);
            lines.Sort((x, y) => y.Length - x.Length);

            for (int i = 0; i < count; ++i)
            {
                Console.WriteLine(lines[i]);
            }
        }
    }
}
