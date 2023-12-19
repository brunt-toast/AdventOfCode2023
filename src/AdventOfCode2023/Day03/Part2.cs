using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day03
{
    public class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day03/input.txt");
        private static string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\n");
        }

        public long Run() =>
            throw new NotImplementedException();

    }
}
