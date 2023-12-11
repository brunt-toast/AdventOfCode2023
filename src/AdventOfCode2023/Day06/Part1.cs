using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day06
{
    internal class Part1 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day06/input.txt");
        private readonly string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        [AocAnswerExpected(252000)]
        public long Run()
        {
            List<int> raceTimes = _input[0].Replace("Time: ", "").Split(" ").Where(x => int.TryParse(x, out int _)).Select(x => int.Parse(x.Trim())).ToList();
            List<int> maxDistances = _input[1].Replace("Distance: ", "").Split(" ").Where(x => int.TryParse(x, out int _)).Select(x => int.Parse(x.Trim())).ToList();
            int answer = 1;

            for (int i = 0; i < raceTimes.Count; i++)
            {
                int distanceRecord = maxDistances[i];
                int raceTime = raceTimes[i];
                int nWinningTimes = 0;

                for (int boatSpeed = 1; boatSpeed <= raceTime; boatSpeed++)
                {
                    int timeToTravel = raceTime - boatSpeed;
                    int distanceTraveled = timeToTravel * boatSpeed;

                    if (distanceTraveled > distanceRecord)
                    {
                        nWinningTimes++;
                    }
                }
                answer *= nWinningTimes;
            }

            Console.WriteLine(answer);
            return answer;
        }
    }
}
