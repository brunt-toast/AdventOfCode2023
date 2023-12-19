using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day07.Common;

namespace AdventOfCode2023.Day07
{
    public class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day07/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        public long Run()
        {
            List<Hand> hands = _input.Select(x => new Hand(x.Split(" ")[0])).ToList();
            List<int> bids = _input.Select(x => int.Parse(x.Split(" ")[1])).ToList();

            hands = hands.OrderBy(x => x.GetHandType()).ToList();

            List<int> results = new();
            for (int i = 0; i < hands.Count; i++)
            {
                Hand hand = hands[i];
                int bid = bids[i];

                Console.WriteLine($"{i + 1} * {bid}: Hand with {string.Join("", hand.Cards)} has power of {hand.GetHandType()} ({(int)hand.GetHandType()})");
                // Note - look at the values and ordering in the example.

                results.Add((i + 1) * bid);
            }

            Console.WriteLine(results.Sum());
            return results.Sum();
        }
    }
}
