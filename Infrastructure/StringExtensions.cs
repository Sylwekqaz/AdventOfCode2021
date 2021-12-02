using System;

namespace AdventOfCode2021.Infrastructure
{
    public static class StringExtensions
    {
        public static string[] SplitLines(this string str)
        {
            return str.Split(Environment.NewLine);
        }
    }
}