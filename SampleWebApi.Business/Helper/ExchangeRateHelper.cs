using Sample.WebApi.Integration.Messages.Response;
using SampleWebApi.Core.Common.Contracts.ResponseMessage.ExchangeRate;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SampleWebApi.Business.Helper
{
    public class ExchangeRateHelper
    {
        public static List<ExchangeRateResponse> ArrangeResponse(GetExchangeRateResponse response)
        {
            List<ExchangeRateResponse> currencies = new List<ExchangeRateResponse>();

            var lastCurrencies = response.items.FirstOrDefault(item =>
            !string.IsNullOrEmpty(item.TP_DK_EUR_A) &&
            !string.IsNullOrEmpty(item.TP_DK_USD_A) &&
            !string.IsNullOrEmpty(item.TP_DK_GBP_A));
            currencies.Add(
                        new ExchangeRateResponse()
                        {
                            Name = "EUR",
                            ExchangeRate = Convert.ToDecimal(lastCurrencies.TP_DK_EUR_A)
                        });
            currencies.Add(
                        new ExchangeRateResponse()
                        {
                            Name = "USD",
                            ExchangeRate = Convert.ToDecimal(lastCurrencies.TP_DK_USD_A)
                        });
            currencies.Add(
                       new ExchangeRateResponse()
                       {
                           Name = "GBP",
                           ExchangeRate = Convert.ToDecimal(lastCurrencies.TP_DK_GBP_A)
                       });
            return currencies;
        }

    }
}
