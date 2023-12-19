﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day18
{
    public class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day18/input.txt");
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
