using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day1
{
    /*
     * --- Day 1: Trebuchet?! ---
     * Something is wrong with global snow production, and you've been selected to take a look. The Elves have even given you a map; on it, they've used stars to mark the top fifty locations that are likely to be having problems.
     * 
     * You've been doing this long enough to know that to restore snow operations, you need to check all fifty stars by December 25th.
     * 
     * Collect stars by solving puzzles.Two puzzles will be made available on each day in the Advent calendar; the second puzzle is unlocked when you complete the first.Each puzzle grants one star. Good luck!
     * 
     * You try to ask why they can't just use a weather machine ("not powerful enough") and where they're even sending you ("the sky") and why your map looks mostly blank("you sure ask a lot of questions") and hang on did you just say the sky("of course, where do you think snow comes from") when you realize that the Elves are already loading you into a trebuchet("please hold still, we need to strap you in").
     * 
     * As they're making the final adjustments, they discover that their calibration document (your puzzle input) has been amended by a very young Elf who was apparently just excited to show off her art skills. Consequently, the Elves are having trouble reading the values on the document.
     * 
     * The newly-improved calibration document consists of lines of text; each line originally contained a specific calibration value that the Elves now need to recover.On each line, the calibration value can be found by combining the first digit and the last digit(in that order) to form a single two-digit number.
     * For example:
     * 
     * 1abc2
     * pqr3stu8vwx
     * a1b2c3d4e5f
     * treb7uchet
     * In this example, the calibration values of these four lines are 12, 38, 15, and 77. Adding these together produces 142.
     * 
     * Consider your entire calibration document.What is the sum of all of the calibration values?
     * 
     * --- Part Two ---
     * Your calculation isn't quite right. It looks like some of the digits are actually spelled out with letters: one, two, three, four, five, six, seven, eight, and nine also count as valid "digits".
     * 
     * Equipped with this new information, you now need to find the real first and last digit on each line. For example:
     * 
     * two1nine
     * eightwothree
     * abcone2threexyz
     * xtwone3four
     * 4nineeightseven2
     * zoneight234
     * 7pqrstsixteen
     * In this example, the calibration values are 29, 83, 13, 24, 42, 14, and 76. Adding these together produces 281.
     * 
     * What is the sum of all of the calibration values? 
    */
    internal class Day1 : IAocAnswer
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

        public Day1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(54990)]
        public int Part1()
        {
            int total = 0;
            foreach (string s in _input)
            {
                List<char> numbers = s.Where(char.IsDigit).ToList();
                int number = int.Parse($"{numbers.First()}{numbers.Last()}");
                total += number;
            }

            Console.WriteLine(total);
            return total;
        }

        [AocAnswerExpected(54473)]
        public int Part2()
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
