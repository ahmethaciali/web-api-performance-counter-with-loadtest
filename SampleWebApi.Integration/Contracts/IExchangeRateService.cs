using Sample.WebApi.Integration.Messages.Request;
using Sample.WebApi.Integration.Messages.Response;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Data.Contracts
{
    public interface IExchangeRateService
    {
        Task<GetExchangeRateResponse> GetAsync(GetExchangeRateRequest request);
    }
}
