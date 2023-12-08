using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day3
{
    internal class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day3/input.txt");
        private static string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\n");
        }

        public long Run() =>
            throw new NotImplementedException();

    }
}
