using BenchmarkDotNet.Attributes;
using Z.Expressions;

namespace BenchTest
{
    [MemoryDiagnoser]
    public class BenchmarkEvalExpressionTest
    {
        private string expr;

        [Params(10, 20, 30, 40, 50, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var data = new byte[N];
            new Random(42).NextBytes(data);

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
        public decimal BenchmarkEvalTest() {
            return Eval.Execute<decimal>(expr);
        }

    }
}
