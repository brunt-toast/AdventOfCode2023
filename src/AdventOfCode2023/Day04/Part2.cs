using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day04
{
    internal class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day04/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(11024379)]
        public long Run()
        {
            List<int> ids = Enumerable.Range(1, _input.Length).ToList();
            int answer = CountCards(ids);
            Console.WriteLine(answer);
            return answer;
        }

        private int CountMatches(int cardId)
        {
            string card = _input[cardId - 1].Split(": ")[1];

            List<int> winningNumbers = card.Split(" | ")[0]
                .Split(" ")
                .Where(x => int.TryParse(x, out int _))
                .Select(x => int.Parse(x.Trim()))
                .ToList();
            List<int> myNumbers = card.Split(" | ")[1]
                .Split(" ")
                .Where(x => int.TryParse(x, out int _))
                .Select(x => int.Parse(x.Trim()))
                .ToList();

            return myNumbers.Where(winningNumbers.Contains).Count();
        }

        private int CountCards(List<int> cardIds)
        {
            int n = 0;
            foreach (int id in cardIds)
            {
                int matches = CountMatches(id);
                n += 1;
                if (matches > 0)
                {
                    n += CountCards(Enumerable.Range(id + 1, matches).ToList());
                }
            }
            return n;
        }
    }
}
