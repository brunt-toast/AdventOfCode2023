using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day2
{
    internal class Part1 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day2/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\n");
        }

        [AocAnswerExpected(3059)]
        public long Run()
        {
            int total = 0;
            foreach (string gameLine in _input)
            {
                int[] values = { 0, 0, 0 };
                foreach (string colorCollection in gameLine.Split(": ")[1].Split("; "))
                {
                    foreach (string colorValuePair in colorCollection.Split(", "))
                    {
                        string[] colorValuePairArray = colorValuePair.Split(" ");

                        int value = int.Parse(colorValuePairArray[0]);
                        string color = colorValuePairArray[1];

                        int index = color switch
                        {
                            "red" => 0,
                            "green" => 1,
                            "blue" => 2,
                            _ => throw new ArgumentOutOfRangeException()
                        };

                        values[index] = Math.Max(value, values[index]);
                    }
                }

                if (values[0] <= 12 && values[1] <= 13 && values[2] <= 14)
                {
                    total += ExtractGameId(gameLine);
                }
            }

            Console.WriteLine(total);
            return total;
        }

        private int ExtractGameId(string line) =>
            int.Parse(line.Split(": ")[0].Split(" ")[1]);
    }
}
