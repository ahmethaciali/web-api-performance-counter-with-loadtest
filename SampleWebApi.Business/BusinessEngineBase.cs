using AutoMapper;
using Sample.WebApi.Integration.Messages.Request;
using SampleWebApi.Business.CounterHelper;
using SampleWebApi.Core.Common.Contracts.Log;
using SampleWebApi.Core.Common.Contracts.RequestMessage.ExchangeRate;
using System;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace SampleWebApi.Business
{
    public class BusinessEngineBase
    {
        protected IMapper Mapper;
        private readonly ILogger _logger;

        public BusinessEngineBase(ILogger logger)
        {
            _logger = logger;
            var mapperConfiguration = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<ExchangeRateRequest, GetExchangeRateRequest> ();
            });

            Mapper = mapperConfiguration.CreateMapper();
        }

        protected T ExecuteWithExceptionHandledOperation<T>(Func<T> func)
        {
            try
            {
                var result = func.Invoke();
                _logger.Info(string.Format("{0} Methodu Çalıştırıldı.", func.Method.Name));
                return result;
            }
            catch (Exception ex)
            {
                _logger.Error(ex.Message, ex);
                throw;
            }
        }

        protected async Task<T> ExecuteWithExceptionAndPerformanceCounterOperationAsync<T>(Func<Task<T>> func)
        {
            try
            {
                NumberOfItems.Instance.Increment();
                Stopwatch stopwatcher = new Stopwatch();
                stopwatcher.Start();
                var result = await func.Invoke();
                AverageCount64.Instance.IncrementBy(stopwatcher.ElapsedMilliseconds);
                stopwatcher.Stop();
                
                return result;
            }
            catch (Exception ex)
            {
                throw;
            }
        }
    }

   
}
