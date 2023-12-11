using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day08.Common;

namespace AdventOfCode2023.Day08
{
    internal class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day08/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(19783)]
        public long Run()
        {
            List<Node> nodes = _input.Skip(2).Select(x => new Node(x)).ToList();
            int steps = CountPathSteps(nodes.Find(x => x.Id == "AAA")!);
            Console.WriteLine(steps);
            return steps;
        }

        private int CountPathSteps(Node sourceNode)
        {
            int totalSteps = 0;
            char[] directions = _input[0].ToCharArray();
            List<Node> nodes = _input.Skip(2).Select(x => new Node(x)).ToList();
            Node currentNode = sourceNode;

            while (true)
            {
                foreach (char direction in directions)
                {
                    if (currentNode.Id == "ZZZ")
                    {
                        return totalSteps;
                    }

                    currentNode = direction == 'L'
                        ? nodes.Find(x => x.Id == currentNode.LeftId)!
                        : nodes.Find(x => x.Id == currentNode.RightId)!;
                    totalSteps++;
                }
            }
        }
    }
}
