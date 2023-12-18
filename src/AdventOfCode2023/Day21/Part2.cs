using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day21
{
    internal class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day21/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        public long Run()
        {
            throw new NotImplementedException();
        }
    }
}
