using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day07
{
    internal class Part2 : IAocAnswer
    {
        private StreamReader _stream = new(@"Day07/input.txt");
        private readonly string[] _input;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");
        }

        public long Run() =>
            throw new NotImplementedException();
    }
}
