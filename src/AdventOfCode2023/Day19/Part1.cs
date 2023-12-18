using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day19
{
    internal class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day19/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
