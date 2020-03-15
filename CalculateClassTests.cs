using NUnit.Framework;

namespace CodeRetreat
{
    [TestFixture]
    class CalculateClassTests
    {
        [TestCase(new [] { "2", "3", "+"}, 5)]
        [TestCase(new[] { "5", "1", "-" }, 4)]
        [TestCase(new[] { "2", "3", "+", "6", "1", "-", "+" }, 10)]
        [TestCase(new[] { "2", "3", "^" }, 8)]
        [TestCase(new[] { "2", "2", "2", "^", "^" }, 16)]
        [TestCase(new[] {"4","sqrt","1","2","/","2","2","^","sqrt","*","-"}, 1)]

        public void TestCase(string[] notation, int expected)
        {
            Assert.AreEqual(expected, CalculateClass.Calculate(notation));
        }
    }
}