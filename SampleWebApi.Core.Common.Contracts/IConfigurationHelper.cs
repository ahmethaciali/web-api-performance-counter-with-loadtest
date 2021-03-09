using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Core.Common.Contracts
{
    public interface IConfigurationHelper
    {
        string ExchangeRateApiKey { get; }
    }
}
