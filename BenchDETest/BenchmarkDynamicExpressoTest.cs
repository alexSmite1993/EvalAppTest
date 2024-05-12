using BenchmarkDotNet.Attributes;
using DynamicExpresso;

namespace BenchTest
{
    [MemoryDiagnoser]
    public class BenchmarkDynamicExpressoTest
    {
        private string expr;
        private Interpreter _interpreter;

        [Params(10, 20, 30, 40, 50, 100)]
        public int N;

        [GlobalSetup]
        public void Setup()
        {
            _interpreter = new Interpreter();
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
        public int BenchmarkEvalTest() {
            var result = _interpreter.Eval<int>(expr);
            return result;
        }

    }
}
