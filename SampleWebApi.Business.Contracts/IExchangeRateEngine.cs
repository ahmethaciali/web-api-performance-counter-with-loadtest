using SampleWebApi.Core.Common.Contracts.RequestMessage.ExchangeRate;
using SampleWebApi.Core.Common.Contracts.ResponseMessage.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Business.Contracts
{
    public interface IExchangeRateEngine
    {
        Task<List<ExchangeRateResponse>> GetAsync(ExchangeRateRequest request);
    }
}
