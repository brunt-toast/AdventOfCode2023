using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day09.Common;

namespace AdventOfCode2023.Day09
{
    public class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day09/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(1798691765)]
        public long Run()
        {
            List<List<int>> lines = _input.Select(line => line.Split(' '))
                .Select(numbersAsStrings => numbersAsStrings.Select(int.Parse).ToList())
                .ToList();

            List<int> outputs = lines.Select(NextInSequence).ToList();

            Console.Write(outputs.Sum());
            return outputs.Sum();
        }

        private static int NextInSequence(List<int> input)
        {
            List<List<int>> gapsList = GetGapsList(input);

            gapsList.Reverse();

            for (int i = 1; i < gapsList.Count; i++)
            {
                gapsList[i].Add(gapsList[i].Last() + gapsList[i - 1].Last());
            }

            return gapsList.Last().Last();
        }

        
    }
}
