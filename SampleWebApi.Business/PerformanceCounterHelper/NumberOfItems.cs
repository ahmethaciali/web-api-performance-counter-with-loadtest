using SampleWebApi.Business.PerformanceCounterHelper;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Web;

namespace SampleWebApi.Business.CounterHelper
{
    public class NumberOfItems : IPerformanceCounter
    {
        private static readonly string TransactionCountCategoryName = "TransactionCountSampleCategory";
        private static readonly string TransactionCountCategoryHelpName = "Demonstrates usage of the TransactionCount performance counter type.";
        private static readonly string TransactionCountCounterName = "TransactionCountSampleBase";
        private static PerformanceCounter transactionCounterSample;

        private static NumberOfItems _instance;

        private static object lockObject = new object();

        private NumberOfItems(){ }

        public static NumberOfItems Instance
        {
            get
            {
                if(_instance == null)
                {
                    lock (lockObject)
                    {
                        if(_instance == null)
                        {
                            _instance = new NumberOfItems();
                        }
                    }
                }
                return _instance;
            }
        }

        public void SetupCategory()
        {
            if (!PerformanceCounterCategory.Exists(TransactionCountCategoryName))
            {
                CounterCreationDataCollection counterNumberOfItemsDataCollection = new CounterCreationDataCollection();

                CounterCreationData numberOfItems32 = new CounterCreationData();
                numberOfItems32.CounterType = PerformanceCounterType.NumberOfItems32;
                numberOfItems32.CounterName = TransactionCountCounterName;
                counterNumberOfItemsDataCollection.Add(numberOfItems32);

                PerformanceCounterCategory.Create(TransactionCountCategoryName, TransactionCountCategoryHelpName,
                   PerformanceCounterCategoryType.SingleInstance, counterNumberOfItemsDataCollection);
            }
        }

        public void CreateCounters()
        {
            transactionCounterSample = new PerformanceCounter(TransactionCountCategoryName, TransactionCountCounterName, false);
            transactionCounterSample.RawValue = 0;
        }

        public void Increment()
        {
            transactionCounterSample.Increment();
        }

        public void IncrementBy(long value)
        {
            transactionCounterSample.IncrementBy(value);
        }

        public void SetValue(long value)
        {
            transactionCounterSample.RawValue = value;
        }

        public void Dispose()
        {
            PerformanceCounterCategory.Delete(TransactionCountCategoryName);
        }
    }
}