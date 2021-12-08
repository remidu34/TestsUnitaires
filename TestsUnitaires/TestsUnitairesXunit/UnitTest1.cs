using FluentAssertions;
using System.Collections.Generic;
using Xunit;

namespace TestsUnitairesXunit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            IEnumerable<int> numbers = new[] { 1, 2, 3 };

            numbers.Should().OnlyContain(n => n > 0);
            numbers.Should().HaveCount(3, "parce que nous pensions avoir mis quatre articles dans la collection");
        }
    }
}