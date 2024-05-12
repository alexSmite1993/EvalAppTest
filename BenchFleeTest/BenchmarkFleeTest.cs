using BenchmarkDotNet.Attributes;
using Flee.CalcEngine.PublicTypes;
using Flee.PublicTypes;

namespace BenchTest
{
    [MemoryDiagnoser]
    public class BenchmarkFleeTest
    {
        private CalculationEngine ce;
        private ExpressionContext context;
        private string expr;

        [Params(10, 20, 30, 40, 50, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var data = new byte[N];
            new Random(42).NextBytes(data);

            ce = new CalculationEngine();
            context = new ExpressionContext();

            var r = new Random(21).Next(0, 3);
            this.expr = string.Join(GetOperator(r), data);
        }

        char GetOperator(int opIndex) => opIndex switch
        {
            0 => '+',
            1 => '-',
            2 => '/',
        };


        [Benchmark]
        public int BenchmarkEvalTest() {
            var v = $"result-{Guid.NewGuid().ToString("D")}";
            ce.Add(v, expr, context);
            ce.Recalculate(v);
            var result = ce.GetResult<int>(v);
            context.Variables.Remove(v);
            return result;
        }

    }
}
