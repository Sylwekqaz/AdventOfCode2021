using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2021.Infrastructure
{
    public static class EnumerableExtensions
    {
        public static IEnumerable<T[]> SlidingWindow<T>(this IEnumerable<T> src, int windowSize)
        {
            return src.ToArray().SlidingWindow(windowSize);
        }

        public static IEnumerable<T[]> SlidingWindow<T>(this T[] src, int windowSize)
        {
            var lastIndex = src.Length - windowSize;
            for (int i = 0; i <= lastIndex; i++)
            {
                yield return src[new Range(i, i + windowSize)];
            }
        }
    }
}