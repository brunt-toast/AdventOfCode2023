using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day09
{
    internal static class Common
    {
        internal static List<List<int>> GetGapsList(List<int> input)
        {
            List<List<int>> output = new() { input };
            Console.WriteLine($"[{string.Join(',', output.Last())}]");


            while (output.Last().Any(x => x != 0))
            {
                List<int> n = GetGaps(output.Last());
                Console.WriteLine($"[{string.Join(',', n)}]");
                output.Add(n);
            }

            return output;
        }

        private static List<int> GetGaps(List<int> input)
        {
            List<int> output = new();
            for (int i = 0; i < input.Count - 1; i++)
            {
                output.Add(input[i + 1] - input[i]);
            }

            return output;
        }
    }
}
