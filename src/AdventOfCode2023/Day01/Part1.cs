using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day01
{
    public class Part1 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day01/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(54990)]
        public long Run()
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
    }
}
