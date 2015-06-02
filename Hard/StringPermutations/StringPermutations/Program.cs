using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace StringPermutations
{
    public class StringPermutations
    {
        static void Main(string[] args)
        {
            foreach (var permutations in File.ReadLines(args[0]).Select(Permute))
            {
                permutations.Sort(CompareTo);

                Console.WriteLine(string.Join(",", permutations));
            }

            Console.Read();
        }

        static int CompareTo(string left, string right)
        {
            Func<char, int> evaluateType = c => char.IsDigit(c) ? -1 : char.IsUpper(c) ? 0 : 1;

            var index = 0;

            do
	        {
                var l = evaluateType(left[index]);
                var r = evaluateType(right[index]);
            
                if (l != r)
                {
                    return l < r ? -1 : 1;
                }
                
                var s = left[index].CompareTo(right[index]);
                    
                if (s != 0)
                {
                    return s;
                }

                index++;
            } while (index < left.Length && index < right.Length);
                        
            return 0;
        }

        public static List<string> Permute(string source) 
        {
            var target = new List<string>();
            
            if (string.IsNullOrEmpty(source)) 
            {
                target.Add("");
                return target;
		    }

            var fixedChar = source[0];
            var remaining = source.Substring(1);

            var words = Permute(remaining);

		    foreach(var newString in words) 
            {
			    for(var i = 0; i <= newString.Length; i++) 
                {
                    target.Add(CharAdd(newString, fixedChar, i));
			    }
		    }

            return target;
	    }

        public static string CharAdd(string source, char fixedChar, int index)
        {
            return source.Substring(0, index) + fixedChar + source.Substring(index);
        }

    }
}
