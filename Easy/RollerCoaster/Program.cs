using System;
using System.IO;

namespace RollerCoaster
{
    class Program
    {
        static void Main(string[] args)
        {
            foreach (string line in File.ReadLines(args[0]))
            {
                if (line.Length == 0)
                {
                    continue;
                }

                string[] words = line.Split(' ');

                bool wasUpper = false;
                int wordLimit = words.Length;

                for (int wordIndex = 0; wordIndex < wordLimit; ++wordIndex)
                {
                    string word = words[wordIndex];
                    int charlimit = word.Length;

                    for (int charIndex = 0; charIndex < charlimit; ++charIndex)
                    {
                        char character = word[charIndex];

                        if (char.IsLetter(character))
                        {
                            if (wasUpper)
                            {
                                character = char.ToLower(character);
                                wasUpper = false;
                            }
                            else
                            {
                                character = char.ToUpper(character);
                                wasUpper = true;
                            }
                        }

                        Console.Write(character);
                    }

                    Console.Write(" ");
                }

                Console.Write(Environment.NewLine);
            }
        }
    }
}
