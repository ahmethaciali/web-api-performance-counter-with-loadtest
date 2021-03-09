using SampleWebApi.Business.PerformanceCounterHelper;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SampleWebApi.Business.CounterHelper
{
    public class AverageCount64 : IPerformanceCounter
    {
        private static readonly string AvgResponseTimeCategoryName = "AverageCounter64SampleCategory";
        private static readonly string AvgResponseTimeHelp = "Demonstrates usage of the AverageCounter64 performance counter type.";
        private static readonly string AvgResponseTimeCounterName = "AverageCounter64Sample";
        private static readonly string AvgResponseTimeBaseCounterName = "AverageCounter64SampleBase";
        
        private static PerformanceCounter avgCounter64Sample;
        private static PerformanceCounter avgCounter64SampleBase;

        private static AverageCount64 _instance;

        private static object lockObject = new object();

        public static AverageCount64 Instance
        {
            get
            {
                if (_instance == null)
                {
                    lock (lockObject)
                    {
                        if (_instance == null)
                        {
                            _instance = new AverageCount64();
                        }
                    }
                }
                return _instance;
            }
        }
        
        public void SetupCategory()
        {
            if (!PerformanceCounterCategory.Exists(AvgResponseTimeCategoryName))
            {
                CounterCreationDataCollection counterDataCollection = new CounterCreationDataCollection();

                CounterCreationData averageCount64 = new CounterCreationData();
                averageCount64.CounterType = PerformanceCounterType.AverageCount64;
                averageCount64.CounterName = AvgResponseTimeCounterName;
                counterDataCollection.Add(averageCount64);

                CounterCreationData averageCount64Base = new CounterCreationData();
                averageCount64Base.CounterType = PerformanceCounterType.AverageBase;
                averageCount64Base.CounterName = AvgResponseTimeBaseCounterName;
                counterDataCollection.Add(averageCount64Base);

                PerformanceCounterCategory.Create(AvgResponseTimeCategoryName,AvgResponseTimeHelp,
                    PerformanceCounterCategoryType.SingleInstance, counterDataCollection);
            }
        }

        public void CreateCounters()
        {
            if (avgCounter64Sample == null)
            {
                avgCounter64Sample = new PerformanceCounter(AvgResponseTimeCategoryName,
                AvgResponseTimeCounterName,
                false);
            }

            if (avgCounter64SampleBase == null)
            {
                avgCounter64SampleBase = new PerformanceCounter(AvgResponseTimeCategoryName,
                AvgResponseTimeBaseCounterName,
                false);
            }

            if (avgCounter64Sample.RawValue != 0)
            {
                avgCounter64Sample.RawValue = 0;
            }

            if (avgCounter64SampleBase.RawValue != 0)
            {
                avgCounter64SampleBase.RawValue = 0;
            }
        }

        public void Increment()
        {
            avgCounter64Sample.Increment();
            avgCounter64SampleBase.Increment();
        }

        public void IncrementBy(long value)
        {
            avgCounter64Sample.IncrementBy(value);
            avgCounter64SampleBase.Increment();
        }

        public void SetValue(long value)
        {
            avgCounter64Sample.RawValue = value;
            avgCounter64SampleBase.Increment();
        }

        public void Dispose()
        {
            PerformanceCounterCategory.Delete(AvgResponseTimeCategoryName);
        }
    }
}