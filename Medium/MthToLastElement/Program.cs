using System;

namespace MthToLastElement
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                var elements = line.Split(' ');
                int last = elements.GetUpperBound(0);
                int index = int.Parse(elements[last]);

                if (index > last)
                    continue;

                Console.WriteLine(elements[last - index]);
            }
        }
    }
}
