using SampleWebApi.Business.PerformanceCounterHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading;
using System.Web;

namespace SampleWebApi.Business.CounterHelper
{
    public class AverageTimer32 : IPerformanceCounter
    {
        private static PerformanceCounter averageTimerPerformanceCounter;
        private static PerformanceCounter averageTimerPerformanceCounterBase;

        private const String categoryName = "AverageTimer32SampleCategory";
        private const String counterName = "AverageTimer32Sample";
        private const String baseCounterName = "AverageTimer32SampleBase";

        private AverageTimer32(){}

        private static AverageTimer32 _instance;

        private static object lockObject = new object();

        public static AverageTimer32 Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (lockObject)
                    {
                        if(_instance == null)
                        {
                            _instance = new AverageTimer32();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetupCategory()
        {
            if (!PerformanceCounterCategory.Exists(categoryName))
            {
                CounterCreationDataCollection counterAverageTimeDataCollection = new CounterCreationDataCollection();

                CounterCreationData averageTimer32 = new CounterCreationData();
                averageTimer32.CounterType = PerformanceCounterType.AverageTimer32;
                averageTimer32.CounterName = counterName;
                counterAverageTimeDataCollection.Add(averageTimer32);

                CounterCreationData averageTimer32Base = new CounterCreationData();
                averageTimer32Base.CounterType = PerformanceCounterType.AverageBase;
                averageTimer32Base.CounterName = baseCounterName;
                counterAverageTimeDataCollection.Add(averageTimer32Base);

                PerformanceCounterCategory.Create(categoryName,
                    "Demonstrates usage of the AverageTimer32 performance counter type",
                    PerformanceCounterCategoryType.SingleInstance, counterAverageTimeDataCollection);

            }
        }

        public void CreateCounters()
        {
            averageTimerPerformanceCounter = new PerformanceCounter(categoryName,
                     counterName,
                     false);

            averageTimerPerformanceCounterBase = new PerformanceCounter(categoryName,
                baseCounterName,
                false);

            averageTimerPerformanceCounter.RawValue = 0;
            averageTimerPerformanceCounterBase.RawValue = 0;
        }

        public void Increment()
        {
            averageTimerPerformanceCounter.Increment();
            averageTimerPerformanceCounterBase.Increment();
        }

        public void SetValue(long value)
        {
            averageTimerPerformanceCounter.RawValue = value;
            averageTimerPerformanceCounterBase.Increment();
        }

        public void IncrementBy(long value)
        {
            averageTimerPerformanceCounter.IncrementBy(value);
            averageTimerPerformanceCounterBase.Increment();
        }

        public void Dispose()
        {
            PerformanceCounterCategory.Delete(categoryName);
        }
    }
}