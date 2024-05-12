using org.matheval;

namespace MathEvalTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(12, "3+4+5")]
        [TestCase(15, "3*5")]
        [TestCase(3, "12/4")]
        [TestCase(100, "4*25")]
        [TestCase(10, "(1+5)/3 + 2 * 4")]
        public void SimpleEvalTest(int res, string expr)
        {
            var expression1 = new Expression("3+4+x2");
            expression1.Bind("x2", 5);
            var ev = expression1.Eval();


            Expression expression = new Expression(expr);
            Assert.AreEqual(res, expression.Eval());
        }
    }
}