using AdventOfCode2023.TestSupport;

namespace AdventOfCode2023.Day03
{
    internal class Part1 : IAocAnswer
    {
        private readonly StreamReader _stream = new(@"Day03/input.txt");
        private static string[] _input;

        public Part1()
        {
            _input = _stream.ReadToEnd().Split("\n");
        }

        public long Run()
        {
            List<GridPosition> gridPositions = new();
            for (int y = 0; y < _input.Length; y++)
            {
                for (int x = 0; x < _input[0].Length; x++)
                {
                    gridPositions.Add(new(x, y));
                }
            }

            List<GridNumber> gridNumbers = new();
            foreach (GridPosition gridPosition in gridPositions)
            {
                if (gridPosition.IsStartOfNumber)
                {
                    gridNumbers.Add(new(gridPosition));
                }
            }

            List<GridNumber> partNumbers = gridNumbers.Where(x => x.IsPartNumber).ToList();
            Console.WriteLine(string.Join("\n\n", partNumbers.Select(x => x.ShowAdjacent())));
            int answer = partNumbers.Select(x => x.Value).Sum();
            Console.WriteLine(answer);
            return answer;
        }

        private class GridPosition
        {
            public int X { get; }
            public int Y { get; }
            public char Value => IsInBounds ? _input[Y][X] : '.';

            public bool IsInBounds =>
                Y >= 0 && X >= 0
                && Y < _input.Length
                && X < _input[0].Length;

            public bool IsStartOfNumber => char.IsDigit(Value) && (X == 0 || !(char.IsDigit(_input[Y][X - 1])));
            public bool IsNumericChar => char.IsDigit(Value);
            public bool IsSymbol => "#!£$%^&*()_+-={}[]:@;',<>/?".ToCharArray().Contains(Value);

            public bool IsAdjacentToSymbol
            {
                get
                {
                    var l = new List<GridPosition>()
                    {
                        new (X-1, Y-1),
                        new (X, Y-1),
                        new (X+1, Y-1),
                        new (X-1, Y),
                        new (X+1, Y),
                        new (X-1, Y+1),
                        new (X, Y+1),
                        new (X+1, Y+1)
                    };

                    return l.Where(g => g.IsInBounds).Any(x => x.IsSymbol);
                }
            }

            public GridPosition(int x, int y)
            {
                X = x;
                Y = y;

                while (X >= _input[0].Length) X--;
                while (Y >= _input.Length) Y--;
            }
        }

        private class GridNumber
        {
            public List<GridPosition> Positions;
            public bool IsPartNumber => Positions.Any(x => x.IsAdjacentToSymbol);
            public int Value;

            public GridNumber(GridPosition initialPosition)
            {
                Positions = new();
                if (!initialPosition.IsStartOfNumber) throw new Exception();

                List<char> numericChars = new();
                while (true)
                {
                    if (initialPosition.X + numericChars.Count > _input.Length)
                    {
                        break;
                    }

                    GridPosition g = new(initialPosition.X + numericChars.Count, initialPosition.Y);
                    if (g.IsNumericChar)
                    {
                        numericChars.Add(g.Value);
                        Positions.Add(g);
                    }
                    else
                    {
                        break;
                    }
                }

                Value = int.Parse(string.Join("", numericChars));
            }

            public string ShowAdjacent()
            {
                GridPosition TopLeft = new(Positions[0].X - 1, Positions[0].Y - 1);
                GridPosition BottomLeft = new(Positions[0].X - 1, Positions[0].Y + 1);
                GridPosition TopRight = new(Positions[0].X + 1, Positions[0].Y - 1);
                GridPosition BottomRight = new(Positions[0].X + 1, Positions[0].Y + 1);
                GridPosition DirectLeft = new(Positions[0].X - 1, Positions[0].Y);
                GridPosition DirectRight = new(Positions.Last().X + 1, Positions[0].Y);

                List<GridPosition> TopRow = Positions.Select(x => new GridPosition(x.X, x.Y - 1)).ToList();
                List<GridPosition> BottomRow = Positions.Select(x => new GridPosition(x.X, x.Y + 1)).ToList();

                string output = "";
                output += $"{TopLeft.Value}{string.Join("", TopRow.Select(x => x.Value))}{TopRight.Value}\n";
                output += $"{DirectLeft.Value}{string.Join("", Positions.Select(x => x.Value))}{DirectRight.Value}\n";
                output += $"{BottomLeft.Value}{string.Join("", BottomRow.Select(x => x.Value))}{BottomRight.Value}\n";
                Console.WriteLine(" ");
                return output;
            }
        }
    }
}
