using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day2
{
    internal class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day2/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\n");
        }

        [AocAnswerExpected(65371)]
        public long Run()
        {
            int totalPower = 0;
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

                totalPower += values[0] * values[1] * values[2];
            }

            Console.WriteLine(totalPower);
            return totalPower;
        }

    }
}
