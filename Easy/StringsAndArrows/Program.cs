using System;

namespace StringsAndArrows
{
    class Program
    {
        static void Main(string[] args)
        {
            const string rightArrow = ">>-->";
            const string leftArrow = "<--<<";

            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                if (line.Length < 5)
                    continue;

                int count = ((line.Length - line.Replace(rightArrow, "").Length) / 5) +
                             ((line.Length - line.Replace(leftArrow, "").Length) / 5);
                
                Console.WriteLine(count);
            }
        }
    }
}
