using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.WebApi.Integration.Messages.Request
{
    public class GetExchangeRateRequest
    {
        public string[] CurrencyCodeList { get; set; }
    }
}
