using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day04
{
    public class Part1 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day04/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(21485)]
        public long Run()
        {
            int total = 0;
            foreach (string line in _input)
            {
                string cardContent = line.Split(": ")[1];

                List<int> winningNumbers = cardContent.Split(" | ")[0]
                    .Split(" ")
                    .Where(x => int.TryParse(x, out int _))
                    .Select(x => int.Parse(x.Trim()))
                    .ToList();
                List<int> myNumbers = cardContent.Split(" | ")[1]
                    .Split(" ")
                    .Where(x => int.TryParse(x, out int _))
                    .Select(x => int.Parse(x.Trim()))
                    .ToList();

                int cardTotal = 0;
                if (winningNumbers.Any(myNumbers.Contains))
                {
                    cardTotal = 1;
                }

                int nExtraWinningNumbers = myNumbers.Where(winningNumbers.Contains).Count() - 1;
                for (int i = 0; i < nExtraWinningNumbers; i++)
                {
                    cardTotal *= 2;
                }

                total += cardTotal;
            }
            Console.WriteLine(total);
            return total;
        }
    }
}
