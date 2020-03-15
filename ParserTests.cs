using NUnit.Framework;

namespace CodeRetreat
{
    [TestFixture]
    class ParserTests
    {
        [TestCase("2 + 3", new[] { "2", "3", "+" })]
        [TestCase("5 - 1", new[] { "5", "1", "-" })]
        [TestCase("( 2 + 3 ) + ( 6 - 1 )", new[] { "2", "3", "+", "6", "1", "-", "+" })]
        [TestCase("2 ^ 3", new[] { "2", "3", "^" })]
        [TestCase("2 ( ^ 2 ^ 2 )", new[] { "2", "2", "2", "^", "^" })]
        //[TestCase(new[] { "4", "sqrt", "1", "2", "/", "2", "2", "^", "sqrt", "*", "-" })]

        public void TestCase(string str, string[] expected)
        {
            Assert.AreEqual(expected, Parser.CreateNotation(str));
        }
    }
}