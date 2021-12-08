using NFluent;
using TestsUnitaires;
using Xunit;

namespace TestsUnitairesXunit
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var integers = new int[] { 1, 2, 3, 4, 5, 666 };
            Check.That(integers).Contains(3, 5, 666);
        }
    }
}