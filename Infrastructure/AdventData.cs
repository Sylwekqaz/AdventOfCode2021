using System;
using System.IO;

namespace AdventOfCode2021.Infrastructure
{
    public static class AdventData
    {
        public static TData GetData<TData>(int dayNumber, Func<string,TData> shaperFunc, bool dummyData = false)
        {
            var path = string.Format("Day{0}_{1}.txt", dayNumber, dummyData ? "DummyInput" : "Input");
            var text = File.ReadAllText(path);
            return shaperFunc(text);
        }
    }
}