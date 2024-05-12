
using DynamicExpresso;

namespace DynamicExpressoTest
{
    public class DynamicExpressoTest
    {
        Interpreter _interpreter;

        [SetUp]
        public void Setup()
        {
            _interpreter = new Interpreter();
        }

        [Test]
        [TestCase("12","3+4+5")]
        [TestCase("15", "3*5")]
        [TestCase("3", "12/4")]
        [TestCase("100", "4*25")]
        [TestCase("10", "(1+5)/3 + 2 * 4")]
        public void SimpleEvalTest(string res, string expr)
        {
            var parameters = new[] {
                new Parameter("x1", typeof(int)),
            };
            var r = _interpreter.Parse("5+x1", parameters);

            var result = _interpreter.Eval(expr);
            Assert.AreEqual(res, result.ToString());
        }


    }
}