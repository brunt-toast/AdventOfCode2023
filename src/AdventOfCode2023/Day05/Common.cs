namespace AdventOfCode2023.Day05
{
    internal static class Common
    {
        internal static List<MapItem> ExtractMapItems(string[] input, int lowestLineIndex, int highestLineIndex) =>
    new ArraySegment<string>(input, lowestLineIndex, highestLineIndex - lowestLineIndex).Select(
        x => new MapItem(
            ulong.Parse(x.Split(" ").Where(x => ulong.TryParse(x, out ulong _)).ToArray()[0]),
            ulong.Parse(x.Split(" ").Where(x => ulong.TryParse(x, out ulong _)).ToArray()[1]),
            ulong.Parse(x.Split(" ").Where(x => ulong.TryParse(x, out ulong _)).ToArray()[2])
            )
        ).ToList();

        internal class MapItem
        {
            public ulong DestinationRangeStart { get; }
            public ulong SourceRangeStart { get; }
            public ulong RangeLength { get; }

            public List<ulong> SourceRange => ULongRange(SourceRangeStart, RangeLength);
            public List<ulong> DestinationRange => ULongRange(DestinationRangeStart, RangeLength);

            public MapItem(ulong destinationRangeStart, ulong sourceRangeStart, ulong rangeLength)
            {
                DestinationRangeStart = destinationRangeStart;
                SourceRangeStart = sourceRangeStart;
                RangeLength = rangeLength;
            }
        }

        private static List<ulong> ULongRange(ulong startIndex, ulong nItems)
        {
            List<ulong> output = new();
            for (ulong i = startIndex; i < nItems; i++)
            {
                output.Add(i);
            }
            return output;
        }
    }
}
