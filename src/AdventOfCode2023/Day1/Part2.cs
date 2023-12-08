using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;
using Microsoft.VisualBasic;

namespace AdventOfCode2023.Day1
{
    internal class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day1/input.txt");
        private readonly string[] _input;
        private readonly Dictionary<string, string> _conversions = new()
        {
            { "threeight", "38"},
            { "fiveight", "58"},
            { "nineight", "98"},
            { "twone", "21"},
            { "oneight", "18"},
            { "sevenine", "79"},
            { "eightwo", "82" },

            { "one", "1" },
            { "two", "2" },
            { "three", "3" },
            { "four", "4" },
            { "five", "5" },
            { "six", "6" },
            { "seven", "7" },
            { "eight", "8" },
            { "nine", "9" },
            { "zero", "0" }
        };

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(54473)]
        public long Run()
        {
            int total = 0;
            foreach (string s in _input)
            {
                string formatted_string = s;
                foreach (KeyValuePair<string, string> kvp in _conversions)
                {
                    formatted_string = formatted_string.Replace(kvp.Key, kvp.Value);
                }

                List<char> numbers = formatted_string.Where(char.IsDigit).ToList();
                int number = int.Parse($"{numbers.First()}{numbers.Last()}");
                total += number;
            }
            Console.WriteLine(total);
            return total;
        }
    }
}
