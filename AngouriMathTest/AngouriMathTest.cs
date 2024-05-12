
namespace AngouriMathTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase("12","3+4+5")]
        [TestCase("15", "3*5")]
        [TestCase("3", "12/4")]
        [TestCase("100", "4*25")]
        [TestCase("10", "(1+5)/3 + 2 * 4")]
        public void SimpleEvalTest(string res, string expr)
        {
            var ff = MathS.Parse("23*x3");

            Assert.AreEqual(res, expr.EvalNumerical().Stringize());
        }


    }
}