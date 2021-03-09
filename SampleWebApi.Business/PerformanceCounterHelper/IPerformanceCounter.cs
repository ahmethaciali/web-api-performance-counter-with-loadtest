using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Business.PerformanceCounterHelper
{
    public interface IPerformanceCounter
    {
        void SetupCategory();
        void CreateCounters();
        void Increment();
        void IncrementBy(long value);
        void SetValue(long value);
        void Dispose();
    }
}
