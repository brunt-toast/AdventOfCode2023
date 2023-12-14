using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdventOfCode2023.Day11
{
    internal class Common
    {
        internal class Galaxy
        {
            private static int _id = 0;

            public int Id { get; }
            public int X { get; }
            public int Y { get; }

            public Galaxy(int x, int y)
            {
                Id = _id++;
                X = x;
                Y = y;
            }

            public int GetShortestDistanceTo(Galaxy other, List<string> map) =>
                Math.Abs(other.X - X) + Math.Abs(other.Y - Y);
        }

        internal static List<Galaxy> GetGalaxiesFromMap(List<string> map)
        {
            List<Galaxy> galaxies = new();
            for (int i = 0; i < map.Count; i++)
            {
                for (int j = 0; j < map[0].Length; j++)
                {
                    if (map[i][j] == '#')
                    {
                        galaxies.Add(new Galaxy(j, i));
                    }
                }
            }
            return galaxies;
        }

        internal static List<string> GetModifiedInput(string[] input, int multiplicationFactor = 2)
        {
            multiplicationFactor--;

            List<string> modifiedInput = input.ToList();
            for (int i = 0; i < modifiedInput.Count; i++)
            {
                if (RowHasGalaxy(modifiedInput, i)) continue;

                for (int n = 0; n < multiplicationFactor; n++)
                {
                    modifiedInput.Insert(i, modifiedInput[i]);
                }
                i += multiplicationFactor;
            }

            for (int i = 0; i < modifiedInput[0].Length; i++)
            {
                if (ColumnHasGalaxy(modifiedInput, i)) continue;

                for (int j = 0; j < modifiedInput.Count; j++)
                {
                    for (int n = 0; n < multiplicationFactor; n++)
                    {
                        modifiedInput[j] = modifiedInput[j].Insert(i, ".");
                    }
                }

                i += multiplicationFactor;
            }

            return modifiedInput;
        }

        internal static bool RowHasGalaxy(List<string> input, int rowIndex) =>
            input[rowIndex].Any(x => x == '#');

        internal static bool ColumnHasGalaxy(List<string> input, int columnIndex) =>
            input.Select(x => x[columnIndex]).Any(x => x == '#');
    }
}
