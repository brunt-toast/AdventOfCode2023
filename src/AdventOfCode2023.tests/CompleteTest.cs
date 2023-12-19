using AdventOfCode2023.TestSupport;
using System.Reflection;

namespace AdventOfCode2023.Tests
{
    [TestClass]
    public class CompleteTest
    {
        private void Check(IAocAnswer answer)
        {
            long expectedAnswer;
            try
            {
                expectedAnswer = answer.GetType().GetMethod("Run").GetCustomAttributes(true).OfType<AocAnswerExpected>().First().TargetValue;
            }
            catch (InvalidOperationException)
            {
                throw new Exception($"No answer was given for {answer.GetType().FullName}");
            }

            long actualAnswer;
            try
            {
                actualAnswer = answer.Run();
            }
            catch (Exception ex)
            {
                throw new Exception($"An exception was thrown while running {answer.GetType().FullName}: {ex}");
            }

            Assert.AreEqual(expectedAnswer, actualAnswer, "Actual answer differs from expected");
        }

        
        [TestMethod]
        public void Day01_Part1() => Check(new Day01.Part1());
        [TestMethod]
        public void Day02_Part1() => Check(new Day02.Part1());
        [TestMethod]
        public void Day03_Part1() => Check(new Day03.Part1());
        [TestMethod]
        public void Day04_Part1() => Check(new Day04.Part1());
        [TestMethod]
        public void Day05_Part1() => Check(new Day05.Part1());
        [TestMethod]
        public void Day06_Part1() => Check(new Day06.Part1());
        [TestMethod]
        public void Day07_Part1() => Check(new Day07.Part1());
        [TestMethod]
        public void Day08_Part1() => Check(new Day08.Part1());
        [TestMethod]
        public void Day09_Part1() => Check(new Day09.Part1());
        [TestMethod]
        public void Day10_Part1() => Check(new Day10.Part1());
        [TestMethod]
        public void Day11_Part1() => Check(new Day11.Part1());
        [TestMethod]
        public void Day12_Part1() => Check(new Day12.Part1());
        [TestMethod]
        public void Day13_Part1() => Check(new Day13.Part1());
        [TestMethod]
        public void Day14_Part1() => Check(new Day14.Part1());
        [TestMethod]
        public void Day15_Part1() => Check(new Day15.Part1());
        [TestMethod]
        public void Day16_Part1() => Check(new Day16.Part1());
        [TestMethod]
        public void Day17_Part1() => Check(new Day17.Part1());
        [TestMethod]
        public void Day18_Part1() => Check(new Day18.Part1());
        [TestMethod]
        public void Day19_Part1() => Check(new Day19.Part1());
        [TestMethod]
        public void Day20_Part1() => Check(new Day20.Part1());
        [TestMethod]
        public void Day21_Part1() => Check(new Day21.Part1());
        [TestMethod]
        public void Day22_Part1() => Check(new Day22.Part1());
        [TestMethod]
        public void Day23_Part1() => Check(new Day23.Part1());
        [TestMethod]
        public void Day24_Part1() => Check(new Day24.Part1());

        [TestMethod]
        public void Day01_Part2() => Check(new Day01.Part2());
        [TestMethod]
        public void Day02_Part2() => Check(new Day02.Part2());
        [TestMethod]
        public void Day03_Part2() => Check(new Day03.Part2());
        [TestMethod]
        public void Day04_Part2() => Check(new Day04.Part2());
        [TestMethod]
        public void Day05_Part2() => Check(new Day05.Part2());
        [TestMethod]
        public void Day06_Part2() => Check(new Day06.Part2());
        [TestMethod]
        public void Day07_Part2() => Check(new Day07.Part2());
        [TestMethod]
        public void Day08_Part2() => Check(new Day08.Part2());
        [TestMethod]
        public void Day09_Part2() => Check(new Day09.Part2());
        [TestMethod]
        public void Day10_Part2() => Check(new Day10.Part2());
        [TestMethod]
        public void Day11_Part2() => Check(new Day11.Part2());
        [TestMethod]
        public void Day12_Part2() => Check(new Day12.Part2());
        [TestMethod]
        public void Day13_Part2() => Check(new Day13.Part2());
        [TestMethod]
        public void Day14_Part2() => Check(new Day14.Part2());
        [TestMethod]
        public void Day15_Part2() => Check(new Day15.Part2());
        [TestMethod]
        public void Day16_Part2() => Check(new Day16.Part2());
        [TestMethod]
        public void Day17_Part2() => Check(new Day17.Part2());
        [TestMethod]
        public void Day18_Part2() => Check(new Day18.Part2());
        [TestMethod]
        public void Day19_Part2() => Check(new Day19.Part2());
        [TestMethod]
        public void Day20_Part2() => Check(new Day20.Part2());
        [TestMethod]
        public void Day21_Part2() => Check(new Day21.Part2());
        [TestMethod]
        public void Day22_Part2() => Check(new Day22.Part2());
        [TestMethod]
        public void Day23_Part2() => Check(new Day23.Part2());
        [TestMethod]
        public void Day24_Part2() => Check(new Day24.Part2());
    }
}
