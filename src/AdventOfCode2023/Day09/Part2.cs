using AdventOfCode2023.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static AdventOfCode2023.Day09.Common;

namespace AdventOfCode2023.Day09
{
    internal class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day09/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(1798691765)]
        public long Run()
        {
            List<List<int>> lines = _input.Select(line => line.Split(' '))
                .Select(numbersAsStrings => numbersAsStrings.Select(int.Parse).ToList())
                .ToList();

            List<int> outputs = lines.Select(PreviousInSequence).ToList();

            Console.Write(outputs.Sum());
            return outputs.Sum();
        }

        private static int PreviousInSequence(List<int> input)
        {
            List<List<int>> gapsList = GetGapsList(input);

            //gapsList.Reverse();

            for (int i = 1; i < gapsList.Count; i++)
            {
                gapsList[i].Add(gapsList[i].Last() + gapsList[i - 1].Last());
            }

            return gapsList.First().First();
        }
    }
}
