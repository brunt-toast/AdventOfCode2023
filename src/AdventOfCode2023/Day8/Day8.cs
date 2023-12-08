using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day8
{
    /*
     *--- Day 8: Haunted Wasteland ---
     * You're still riding a camel across Desert Island when you spot a sandstorm quickly approaching. When you turn to warn the Elf, she disappears before your eyes! To be fair, she had just finished warning you about ghosts a few minutes ago.
     * 
     * One of the camel's pouches is labeled "maps" - sure enough, it's full of documents (your puzzle input) about how to navigate the desert. At least, you're pretty sure that's what they are; one of the documents contains a list of left/right instructions, and the rest of the documents seem to describe some kind of network of labeled nodes.
     * 
     * It seems like you're meant to use the left/right instructions to navigate the network. Perhaps if you have the camel follow the same instructions, you can escape the haunted wasteland!
     * 
     * After examining the maps for a bit, two nodes stick out: AAA and ZZZ. You feel like AAA is where you are now, and you have to follow the left/right instructions until you reach ZZZ.
     * 
     * This format defines each node of the network individually. For example:
     * 
     * RL
     * 
     * AAA = (BBB, CCC)
     * BBB = (DDD, EEE)
     * CCC = (ZZZ, GGG)
     * DDD = (DDD, DDD)
     * EEE = (EEE, EEE)
     * GGG = (GGG, GGG)
     * ZZZ = (ZZZ, ZZZ)
     * Starting with AAA, you need to look up the next element based on the next left/right instruction in your input. In this example, start with AAA and go right (R) by choosing the right element of AAA, CCC. Then, L means to choose the left element of CCC, ZZZ. By following the left/right instructions, you reach ZZZ in 2 steps.
     * 
     * Of course, you might not find ZZZ right away. If you run out of left/right instructions, repeat the whole sequence of instructions as necessary: RL really means RLRLRLRLRLRLRLRL... and so on. For example, here is a situation that takes 6 steps to reach ZZZ:
     * 
     * LLR
     * 
     * AAA = (BBB, BBB)
     * BBB = (AAA, ZZZ)
     * ZZZ = (ZZZ, ZZZ)
     * Starting at AAA, follow the left/right instructions. How many steps are required to reach ZZZ?
     */
    internal class Day8 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day8/input.txt");
        private readonly string[] _input;

        public Day8()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        class Node
        {
            public string Id { get; set; }
            public string LeftId { get; set; }
            public string RightId { get; set; }

            public Node(string input)
            {
                Id = input.Substring(0, 3);
                LeftId = input.Substring(7, 3);
                RightId = input.Substring(12, 3);
            }
        }

        [AocAnswerExpected(19783)]
        public long Part1()
        {
            List<Node> nodes = _input.Skip(2).Select(x => new Node(x)).ToList();
            int steps = Part1_CountPathSteps(nodes.Find(x => x.Id == "AAA")!);
            Console.WriteLine(steps);
            return steps;
        }

        [AocAnswerExpected(9177460370549)]
        public long Part2()
        {
            List<Node> nodes = _input.Skip(2).Select(x => new Node(x)).ToList();
            List<Node> currentNodes = nodes.Where(x => x.Id.EndsWith('A')).ToList();
            List<int> pathLengths = currentNodes.Select(Part2_CountPathSteps).ToList();

            long answer = GetLcm(pathLengths.ToArray());
            Console.WriteLine(answer);
            return answer;
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
                            elementArray[i] = elementArray[i] * (-1);
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

        private int Part1_CountPathSteps(Node sourceNode)
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

        private int Part2_CountPathSteps(Node sourceNode)
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
    }
}
