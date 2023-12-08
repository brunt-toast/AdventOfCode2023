using AdventOfCode2023.TestSupport;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day6
{
    internal class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day6/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(36992486)]
        public long Run()
        {
            long raceTime = ExtractNumberWithKerning(_input[0]);
            long distanceRecord = ExtractNumberWithKerning(_input[1]);

            int nWinningTimes = 0;
            for (int boatSpeed = 1; boatSpeed <= raceTime; boatSpeed++)
            {
                long timeToTravel = raceTime - boatSpeed;
                long distanceTraveled = timeToTravel * boatSpeed;

                if (distanceTraveled > distanceRecord)
                {
                    nWinningTimes++;
                }
            }

            Console.WriteLine(nWinningTimes);
            return nWinningTimes;
        }

        private long ExtractNumberWithKerning(string s) =>
            long.Parse(string.Join("", s.ToCharArray().Where(char.IsDigit).ToList()));
    }
}
