// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using BenchTest;


BenchmarkRunner.Run<BenchmarkAngouriMathTest>();

Console.WriteLine("THE END!");
Console.ReadLine();
