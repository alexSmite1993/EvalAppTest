using AngouriMath.Extensions;
using BenchmarkDotNet.Attributes;
using System;

namespace BenchTest
{
    [MemoryDiagnoser]
    public class BenchmarkAngouriMathTest
    {
        private string expr;

        [Params(10, 20, 30, 40, 50, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            var data = new byte[N];
            new Random(42).NextBytes(data);

            var r = new Random(21).Next(0, 4);
            this.expr = string.Join(GetOperator(r), data);
        }

        char GetOperator(int opIndex) => opIndex switch
        {
            0 => '+',
            1 => '-',
            2 => '*',
            3 => '/',
        };


        [Benchmark]
        public string BenchmarkEvalTest() {
            return expr.EvalNumerical().Stringize();
        }

    }
}
