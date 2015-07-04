using System;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in System.IO.File.ReadLines(args[0]))
            {
                bool isUpper = false;

                foreach (char character in line)
                {
                    if (char.IsLetter(character))
                        Console.Write((isUpper = !isUpper) ? char.ToUpper(character) : char.ToLower(character));
                    else
                        Console.Write(character);
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
