using System;
using System.Linq;
using AdventOfCode2021.Infrastructure;
using Xunit;
using Xunit.Abstractions;
using YamlDotNet.Serialization;

namespace AdventOfCode2021
{
    public class Day3
    {
        private readonly ITestOutputHelper _outputHelper;

        public Day3(ITestOutputHelper outputHelper)
        {
            _outputHelper = outputHelper;
        }

        [Theory]
        [InlineData(true, "10110", "01001", 198)]
        [InlineData(false, null, null, null)]
        void Day3_PartOne(bool isTestRun, string correctGamma, string correctEpsilon, int? correctAnswer)
        {
            var data = AdventData
                .GetData(3, ParseData, isTestRun);

            var length = data.First().Length;
            var dataLength = data.Length;
            var gamma = "";
            var epsilon = "";

            var acc = new int[length];

            foreach (var bytes in data)
            {
                for (int i = 0; i < length; i++)
                {
                    if (bytes[i] == '1') acc[i]++;
                }
            }

            gamma = new string(acc.Select(i => i > dataLength / 2 ? '1' : '0').ToArray());
            epsilon = new string(acc.Select(i => i < dataLength / 2 ? '1' : '0').ToArray());


            var answer = Convert.ToInt32(gamma, 2) * Convert.ToInt32(epsilon, 2);
            _outputHelper.WriteLine($"Gamma: {gamma}");
            _outputHelper.WriteLine($"Epsilon: {epsilon}");
            _outputHelper.WriteLine($"Answer: {answer}");

            if (correctAnswer.HasValue)
            {
                Assert.Equal(correctGamma, gamma);
                Assert.Equal(correctEpsilon, epsilon);
                Assert.Equal(correctAnswer, answer);
            }
        }

        [Theory]
        [InlineData(true, "10111", "01010", 230)]
        [InlineData(false, null, null, null)]
        void Day3_PartTwo(bool isTestRun, string correctOxygen, string correctCo2, int? correctAnswer)
        {
            var data = AdventData
                .GetData(3, ParseData, isTestRun);

            var length = data.First().Length;
            var oxygen = "";
            var co2 = "";


            string[] FilterDataBitCriteria(string[] data, int bit, bool isMostCommon)
            {
                var count = data.Select(s => s[bit])
                    .Count(c => c == '1');


                return (isMostCommon && 2 * count >= data.Length) || (!isMostCommon && 2 * count < data.Length)
                    ? data.Where(s => s[bit] == '1').ToArray()
                    : data.Where(s => s[bit] != '1').ToArray();
            }

            string SelectByByteCriteria(string[] data, bool isMostCommon)
            {
                var d = data;
                for (int i = 0; i < length; i++)
                {
                    d = FilterDataBitCriteria(d, i, isMostCommon);
                    if (d.Length == 1) return d.Single();
                }

                return d.Single();
            }

            oxygen = SelectByByteCriteria(data, true);
            co2 = SelectByByteCriteria(data, false);


            var answer = Convert.ToInt32(oxygen, 2) * Convert.ToInt32(co2, 2);
            _outputHelper.WriteLine($"Oxygen: {oxygen}");
            _outputHelper.WriteLine($"CO2: {co2}");
            _outputHelper.WriteLine($"Answer: {answer}");

            if (correctAnswer.HasValue)
            {
                Assert.Equal(correctOxygen, oxygen);
                Assert.Equal(correctCo2, co2);
                Assert.Equal(correctAnswer, answer);
            }
        }


        private static string[] ParseData(string str)
        {
            return str.SplitLines();
        }
    }
}