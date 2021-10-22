using System;
using BenchmarkDotNet.Attributes;
using BenchmarkDotNet.Order;
using BenchmarkDotNet.Running;

namespace BenchmarkingRecords
{
    class Program
    {
        static void Main(string[] args)
        {
            BenchmarkRunner.Run<SampleBenchmarkClass>();
            Console.ReadLine();
        }
    }
}

[MemoryDiagnoser, Orderer(SummaryOrderPolicy.FastestToSlowest)]
public class SampleBenchmarkClass
{
    private const string sampleString = "sample";
    private const int sampleInt = 1;

    [Benchmark]
    public SampleClassStringProperty ClassStringProperty()
    {
        return new SampleClassStringProperty(sampleString);
    }
    [Benchmark]
    public SampleRecordStringProperty RecordStringProperty()
    {
        return new SampleRecordStringProperty(sampleString);
    }

    [Benchmark]
    public SampleClassIntProperty ClassIntProperty()
    {
        return new SampleClassIntProperty(sampleInt);
    }
    [Benchmark]
    public SampleRecordIntProperty RecordIntProperty()
    {
        return new SampleRecordIntProperty(sampleInt);
    }
}
public class SampleClassStringProperty
{
    public string SampleProp { get; init; }

    public SampleClassStringProperty(string sampleProp)
    {
        SampleProp = sampleProp;
    }
}
public record SampleRecordStringProperty(string SampleProp);

public class SampleClassIntProperty
{
    public int SampleProp { get; }

    public SampleClassIntProperty(int sampleProp)
    {
        SampleProp = sampleProp;
    }
}
public record SampleRecordIntProperty(int SampleProp);
