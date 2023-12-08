using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day8.Common;

namespace AdventOfCode2023.Day8
{
    internal class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day8/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        /// <remarks>
        /// Traversing all paths simultaneously is slow and inefficient.
        /// The best way is to calculate the step value for all paths
        /// and find their lowest common multiple.
        ///
        /// The answer to this part is too big to fit in an integer.
        /// Refactoring was done so that all AOC part answers are longs. 
        /// </remarks>
        [AocAnswerExpected(9177460370549)]
        public long Run()
        {
            List<Node> nodes = _input.Skip(2).Select(x => new Node(x)).ToList();
            List<Node> currentNodes = nodes.Where(x => x.Id.EndsWith('A')).ToList();
            int[] pathLengths = currentNodes.Select(CountPathSteps).ToArray();

            long answer = GetLcm(pathLengths);
            Console.WriteLine(answer);
            return answer;
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
                    if (currentNode.Id.EndsWith('Z'))
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

        /// <remarks>
        /// Credit to Madhur Modi at GeeksForGeeks
        /// https://www.geeksforgeeks.org/lcm-of-given-array-elements/
        /// </remarks>
        private static long GetLcm(IList<int> elementArray)
        {
            long lcmOfArrayElements = 1;
            int divisor = 2;

            while (true)
            {
                int counter = 0;
                bool divisible = false;
                for (int i = 0; i < elementArray.Count; i++)
                {
                    switch (elementArray[i])
                    {
                        case 0:
                            return 0;
                        case < 0:
                            elementArray[i] *= (-1);
                            break;
                    }
                    if (elementArray[i] == 1)
                    {
                        counter++;
                    }

                    if (elementArray[i] % divisor != 0) continue;
                    divisible = true;
                    elementArray[i] /= divisor;
                }

                if (divisible)
                {
                    lcmOfArrayElements *= divisor;
                }
                else
                {
                    divisor++;
                }

                if (counter != elementArray.Count) continue;
                return lcmOfArrayElements;
            }
        }
    }
}
