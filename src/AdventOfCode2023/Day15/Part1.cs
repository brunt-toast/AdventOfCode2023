using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day15
{
    internal class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day15/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split(',');
        }

        [AocAnswerExpected(519041)]
        public long Run()
        {
            List<int> hashedValues = new();

            foreach (string step in _input)
            {
                int total = 0;
                foreach (var charValue in step.Select(c => (int)c))
                {
                    total += charValue;
                    total *= 17;
                    total %= 256;
                }

                Console.WriteLine($"{step} = {total}");

                hashedValues.Add(total);
            }

            Console.WriteLine(hashedValues.Sum());
            return hashedValues.Sum(); 
        }
    }
}
