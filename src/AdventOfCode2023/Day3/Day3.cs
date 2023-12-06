namespace AdventOfCode2023.Day3
{
    /* 
     * --- Day 3: Gear Ratios ---
     * You and the Elf eventually reach a gondola lift station; he says the gondola lift will take you up to the water source, but this is as far as he can bring you. You go inside.
     * 
     * It doesn't take long to find the gondolas, but there seems to be a problem: they're not moving.
     * 
     * "Aaah!"
     * 
     * You turn around to see a slightly-greasy Elf with a wrench and a look of surprise. "Sorry, I wasn't expecting anyone! The gondola lift isn't working right now; it'll still be a while before I can fix it." You offer to help.
     * 
     * The engineer explains that an engine part seems to be missing from the engine, but nobody can figure out which one. If you can add up all the part numbers in the engine schematic, it should be easy to work out which part is missing.
     * 
     * The engine schematic (your puzzle input) consists of a visual representation of the engine. There are lots of numbers and symbols you don't really understand, but apparently any number adjacent to a symbol, even diagonally, is a "part number" and should be included in your sum. (Periods (.) do not count as a symbol.)
     * 
     * Here is an example engine schematic:
     * 
     * 467..114..
     * ...*......
     * ..35..633.
     * ......#...
     * 617*......
     * .....+.58.
     * ..592.....
     * ......755.
     * ...$.*....
     * .664.598..
     * In this schematic, two numbers are not part numbers because they are not adjacent to a symbol: 114 (top right) and 58 (middle right). Every other number is adjacent to a symbol and so is a part number; their sum is 4361.
     * 
     * Of course, the actual engine schematic is much larger. What is the sum of all of the part numbers in the engine schematic?
    */
    internal class Day3
    {
        private readonly StreamReader _stream = new(@"Day3/input.txt");

        private static string[] _input;

        public Day3()
        {
            string input = _stream.ReadToEnd();
            _input = input.Split("\n");
        }

        public void Part1()
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
            Console.WriteLine(partNumbers.Select(x => x.Value).Sum());
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
