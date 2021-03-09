using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Core.Common.Contracts.ResponseMessage.ExchangeRate
{
    public class ExchangeRateResponse
    {
        public string Name { get; set; }
        public decimal ExchangeRate { get; set; }
    }
}
