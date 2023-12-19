using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.Day05;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day17
{
    public class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day17/input.txt");
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
