using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day15
{
    public class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day15/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split(',');
        }

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
