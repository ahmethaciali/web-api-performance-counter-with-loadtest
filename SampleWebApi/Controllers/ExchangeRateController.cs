using SampleWebApi.Business.Contracts;
using SampleWebApi.Core.Common.Contracts.RequestMessage.ExchangeRate;
using SampleWebApi.Core.Common.Contracts.ResponseMessage.ExchangeRate;
using SampleWebApi.Data.Contracts;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Web.Http;

namespace SampleWebApi.Controllers
{
    public class ExchangeRateController : ApiController
    {
        private IExchangeRateService _exchangeRateService;
        private IExchangeRateEngine _exchangeRateEngine;

        public ExchangeRateController(IExchangeRateService exchangeRateService, IExchangeRateEngine exchangeRateEngine)
        {
            _exchangeRateService = exchangeRateService;
            _exchangeRateEngine = exchangeRateEngine;
        }

         public async Task<List<ExchangeRateResponse>> GetAsync()
        {
            ExchangeRateRequest request = new ExchangeRateRequest();
            request.CurrencyCodeList = new string[] { "USD", "EUR", "GBP" };
            var exchangeRateList = await _exchangeRateEngine.GetAsync(request);
            return exchangeRateList;
        }
    }
}
