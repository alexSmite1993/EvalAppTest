// See https://aka.ms/new-console-template for more information
using BenchmarkDotNet.Running;
using BenchTest;

BenchmarkRunner.Run<BenchmarkFleeTest>();

Console.WriteLine("THE END!");
Console.ReadLine();
