using SampleWebApi.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Core
{
    public class ConfigurationHelper
    {

        public static string ExchangeRateApiKey
        {
            get { return ConfigurationManager.AppSettings["tcmkKey"]; }
        }
    }
}
