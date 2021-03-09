using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Sample.WebApi.stringegration.Entities;
namespace Sample.WebApi.Integration.Messages.Response
{
    public class GetExchangeRateResponse
    {
        public int totalCount { get; set; }
        public List<ExchangeRate> items { get; set; }
    }
}
