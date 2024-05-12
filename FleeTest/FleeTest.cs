using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;

namespace FleeTest
{
    public class Tests
    {
        [SetUp]
        public void Setup()
        {
        }

        [Test]
        [TestCase(12, "3 + 4 + 5")]
        [TestCase(15, "3 * 5")]
        [TestCase(3, "12 / 4")]
        [TestCase(100, "4 * 25")]
        [TestCase(10, "(1 + 5) / 3 + 2 * 4")]
        public void SimpleEvalTest(int res, string expr)
        {
            var ce = new CalculationEngine();
            var context = new ExpressionContext();
            ce.Add("result", expr, context);
            ce.Recalculate("result");
            var result = ce.GetResult<int>("result");
            Assert.AreEqual(res, result);
        }
    }
}