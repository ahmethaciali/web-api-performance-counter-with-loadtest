using Sample.WebApi.Integration.Helper;
using Sample.WebApi.Integration.Messages.Request;
using Sample.WebApi.Integration.Messages.Response;
using SampleWebApi.Data.Contracts;
using SampleWebApi.Data2.Helper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data2
{
    public class ExchangeRateService : IExchangeRateService
    {
        public async Task<GetExchangeRateResponse> GetAsync(GetExchangeRateRequest request)
        {
            string url = ExchangeRateHelper.CreateExchangeRateHttpUrl(request);
            GetExchangeRateResponse response = await HttpHelper.Get<GetExchangeRateResponse>(url);
            return response;
        }
    }
}
