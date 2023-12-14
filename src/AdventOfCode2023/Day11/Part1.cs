using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day11.Common;

namespace AdventOfCode2023.Day11
{
    public class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day11/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(9799681)]
        public long Run()
        {
            List<string> modifiedInput = GetModifiedInput(_input);
            List<Galaxy> galaxies = GetGalaxiesFromMap(modifiedInput);
            
            int total = 0;

            for (int i = 0; i < galaxies.Count; i++)
            {
                for (int j = i + 1; j < galaxies.Count; j++)
                {
                    Galaxy galaxy1 = galaxies[i];
                    Galaxy galaxy2 = galaxies[j];

                    total += galaxy1.GetShortestDistanceTo(galaxy2, modifiedInput);
                }
            }

            Console.WriteLine(total);
            return total;
        }
    }
}
