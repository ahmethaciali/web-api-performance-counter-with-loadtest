using Sample.WebApi.Integration.Messages.Request;
using SampleWebApi.Core;
using SampleWebApi.Core.Common.Contracts;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sample.WebApi.Integration.Helper
{
    public class ExchangeRateHelper
    {
        private const string tcmbBaseUrl = "https://evds2.tcmb.gov.tr/service/evds/series={0}&startDate={1}&endDate={2}&type={3}&key={4}";

        private IConfigurationHelper _configurationHelper;
        public ExchangeRateHelper(IConfigurationHelper configurationHelper)
        {
            _configurationHelper = configurationHelper;
        }
        private static string arrangeCurrenyCodeListForRequest(string[] exchangeRateCodeList)
        {
            if (exchangeRateCodeList == null || exchangeRateCodeList.Length == 0)
            {
                return "";
            }
            StringBuilder stringBuilder = new StringBuilder();
            foreach (var exchangeRateCode in exchangeRateCodeList)
            {
                stringBuilder.Append(String.Format("TP.DK.{0}.A-", exchangeRateCode));
            }
            var result = stringBuilder.ToString();
            if (result.EndsWith("-"))
            {
                result = result.Remove(result.Length - 1, 1);
            }
            return result;
        }

        private static string arrangeDateForRequest(DateTime date)
        {
            return date.ToString("dd-MM-yyyy");
        }
        internal static string CreateExchangeRateHttpUrl(GetExchangeRateRequest request)
        {
            string key = ConfigurationHelper.ExchangeRateApiKey;
            
            var now = DateTime.Now;
            string url = String.Format(
                tcmbBaseUrl,
                arrangeCurrenyCodeListForRequest(request.CurrencyCodeList),
                arrangeDateForRequest(now.AddDays(-7)),
                arrangeDateForRequest(now),
                "json",
                key);
            return url;
        }
        
    }
}
