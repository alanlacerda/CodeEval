using System;

namespace LettercasePercentageRatio
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (var line in System.IO.File.ReadLines(args[0]))
            {
                int upperCount = 0;
                int lowerCount = 0;

                foreach (char character in line)
                {
                    if (char.IsUpper(character))
                        ++upperCount;
                    else
                        ++lowerCount;
                }

                Console.WriteLine("lowercase: {0:F} uppercase: {1:F}", 
                    lowerCount/(double) (lowerCount + upperCount)*100,
                    upperCount/(double) (lowerCount + upperCount)*100);
            }
        }
    }
}