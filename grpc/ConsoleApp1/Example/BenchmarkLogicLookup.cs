using BenchmarkDotNet.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Example
{
    [MemoryDiagnoser]
    [Orderer(BenchmarkDotNet.Order.SummaryOrderPolicy.FastestToSlowest)]
    [RankColumn]
    public class BenchmarkLogicLookup
    {
        BenchmarkLogic obj = new BenchmarkLogic();
        [Benchmark]
        public void RestRequest()
        {
            obj.RestRequest1();
        }

        [Benchmark]
        public void WebRequest()
        {
            obj.WebRequest();
        }
    }
}
