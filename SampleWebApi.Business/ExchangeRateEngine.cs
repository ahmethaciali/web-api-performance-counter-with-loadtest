using Sample.WebApi.Integration.Messages.Request;
using Sample.WebApi.Integration.Messages.Response;
using SampleWebApi.Business.Contracts;
using SampleWebApi.Business.Helper;
using SampleWebApi.Core.Common.Contracts.Log;
using SampleWebApi.Core.Common.Contracts.RequestMessage.ExchangeRate;
using SampleWebApi.Core.Common.Contracts.ResponseMessage.ExchangeRate;
using SampleWebApi.Data.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Business
{
    public class ExchangeRateEngine : BusinessEngineBase, IExchangeRateEngine
    {
        private readonly ILogger _logger;
        private readonly IExchangeRateService _exchangeRateService;
        public ExchangeRateEngine(IExchangeRateService exchangeRateService, ILogger logger) : base(logger)
        {
            _exchangeRateService = exchangeRateService;
            _logger = logger;
        }
        public Task<List<ExchangeRateResponse>> GetAsync(ExchangeRateRequest request)
        {
            return base.ExecuteWithExceptionAndPerformanceCounterOperationAsync(async () =>
            {
                var serviceRequest = Mapper.Map<GetExchangeRateRequest>(request);
                var exchangeRateList = await _exchangeRateService.GetAsync(serviceRequest);
                var arrangedList = ExchangeRateHelper.ArrangeResponse(exchangeRateList);
                return arrangedList;
            });
        }
    }
}
