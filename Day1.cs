using System.Linq;
using AdventOfCode2021.Infrastructure;
using Xunit;
using Xunit.Abstractions;

namespace AdventOfCode2021
{
    public class Day1
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day1(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(true, 7)]
        [InlineData(false, 1616)]
        void Day1_PartOne(bool isTestRun, int? answer)
        {
            var increases = AdventData
                .GetData(1, ParseData, isTestRun)
                .SlidingWindow(2)
                .Count(window => window[0] < window[1]);


            _outputHelper.WriteLine($"Answer: {increases}");
            if (answer.HasValue)
            {
                Assert.Equal(answer.Value, increases);
            }
        }

        [Theory]
        [InlineData(true, 5)]
        [InlineData(false, 1645)]
        void Day1_PartTwo(bool isTestRun, int? answer)
        {
            var increases = AdventData
                .GetData(1, ParseData, isTestRun)
                .SlidingWindow(3)
                .Select(window=> window.Sum())
                .SlidingWindow(2)
                .Count(window => window[0] < window[1]);


            _outputHelper.WriteLine($"Answer: {increases}");
            if (answer.HasValue)
            {
                Assert.Equal(answer.Value, increases);
            }
        }

        private static int[] ParseData(string str)
        {
            return str.SplitLines()
                .Select(int.Parse)
                .ToArray();
        }
    }
}