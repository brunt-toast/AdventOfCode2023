using AdventOfCode2023.TestSupport;
using static AdventOfCode2023.Day05.Common;

namespace AdventOfCode2023.Day05
{
    public class Part2 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day05/input.txt");
        private readonly string[] _input;

        private List<UInt64> _seeds;
        private List<MapItem> _seedToSoilMap;
        private List<MapItem> _soilToFertilizerMap;
        private List<MapItem> _fertilizerToWaterMap;
        private List<MapItem> _waterToLightMap;
        private List<MapItem> _lightToTemperatureMap;
        private List<MapItem> _temperatureToHumidityMap;
        private List<MapItem> _humidityToLocationMap;

        public Part2()
        {
            _input = _stream.ReadToEnd().Split("\r\n");

            _seeds = _input[0].Split(": ")[1].Split(" ").Select(UInt64.Parse).ToList();
            _seedToSoilMap = ExtractMapItems(_input, 3, 37);
            _soilToFertilizerMap = ExtractMapItems(_input, 40, 72);
            _fertilizerToWaterMap = ExtractMapItems(_input, 75, 102);
            _waterToLightMap = ExtractMapItems(_input, 105, 119);
            _lightToTemperatureMap = ExtractMapItems(_input, 122, 154);
            _temperatureToHumidityMap = ExtractMapItems(_input, 156, 187);
            _humidityToLocationMap = ExtractMapItems(_input, 190, 205);
        }

        public long Run() =>
            throw new NotImplementedException();
    }
}
