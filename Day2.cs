using System;
using System.Linq;
using AdventOfCode2021.Infrastructure;
using Xunit;
using Xunit.Abstractions;
using YamlDotNet.Serialization;

namespace AdventOfCode2021
{
    public class Day2
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day2(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(true, 15, 10, 150)]
        [InlineData(false, 1971, 830, 1635930)]
        void Day2_PartOne(bool isTestRun, int? correctHorizontal, int? correctDepth, int? correctAnswer)
        {
            var data = AdventData
                    .GetData(2, ParseData, isTestRun)
                //.Dump("Data", _outputHelper)
                ;

            var horizontal = 0;
            var depth = 0;
            foreach (var command in data)
            {
                switch (command)
                {
                    case {Direction: "forward"}:
                        horizontal += command.Steps;
                        break;
                    case {Direction: "up"}:
                        depth -= command.Steps;
                        break;
                    case {Direction: "down"}:
                        depth += command.Steps;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(command.Direction), command.Direction);
                }
            }


            _outputHelper.WriteLine($"Horizontal: {horizontal}");
            _outputHelper.WriteLine($"Depth: {depth}");
            _outputHelper.WriteLine($"Answer: {horizontal * depth}");
            var answer = horizontal * depth;

            if (correctAnswer.HasValue)
            {
                Assert.Equal(correctAnswer, answer);
                Assert.Equal(correctHorizontal, horizontal);
                Assert.Equal(correctDepth, depth);
            }
        }

        [Theory]
        [InlineData(true, 15, 60, 900)]
        [InlineData(false, 1971, 904018, 1781819478)]
        void Day2_PartTwo(bool isTestRun, int? correctHorizontal, int? correctDepth, int? correctAnswer)
        {
            var data = AdventData
                .GetData(2, ParseData, isTestRun);

            var horizontal = 0;
            var depth = 0;
            var aim = 0;
            foreach (var command in data)
            {
                switch (command)
                {
                    case {Direction: "forward"}:
                        horizontal += command.Steps;
                        depth += aim * command.Steps;
                        break;
                    case {Direction: "up"}:
                        aim -= command.Steps;
                        break;
                    case {Direction: "down"}:
                        aim += command.Steps;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException(nameof(command.Direction), command.Direction);

                }
            }


            _outputHelper.WriteLine($"Horizontal: {horizontal}");
            _outputHelper.WriteLine($"Depth: {depth}");
            _outputHelper.WriteLine($"Answer: {horizontal * depth}");
            var answer = horizontal * depth;

            if (correctAnswer.HasValue)
            {
                Assert.Equal(correctAnswer, answer);
                Assert.Equal(correctHorizontal, horizontal);
                Assert.Equal(correctDepth, depth);
            }
        }


        private static Command[] ParseData(string str)
        {
            return str.SplitLines()
                .Select(line =>
                {
                    var parts = line.Split(' ');
                    return new Command(parts[0], int.Parse(parts[1]));
                })
                .ToArray();
        }

        public readonly struct Command
        {
            public Command(string direction, int steps)
            {
                Direction = direction;
                Steps = steps;
            }

            public string Direction { get; }
            public int Steps { get; }
        }
    }
}