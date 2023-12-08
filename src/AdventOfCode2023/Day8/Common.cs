using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day8
{
    internal static class Common
    {
        internal class Node
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
    }
}
