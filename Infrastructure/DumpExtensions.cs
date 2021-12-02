using Xunit.Abstractions;
using YamlDotNet.Serialization;
using YamlDotNet.Serialization.NamingConventions;

namespace AdventOfCode2021.Infrastructure
{
    public static class DumpExtensions
    {
        private static readonly ISerializer Serializer = new SerializerBuilder()
            .WithNamingConvention(CamelCaseNamingConvention.Instance)
            .Build();

        public static T Dump<T>(this T obj, string message, ITestOutputHelper output)
        {
            output.WriteLine(message);
            output.WriteLine(Serializer.Serialize(obj));
            return obj;
        }
    }
}