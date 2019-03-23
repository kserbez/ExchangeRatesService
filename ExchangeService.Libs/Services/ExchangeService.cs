using ExchangeService.Libs.Exchange;
using ExchangeService.Libs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeService.Libs.Services
{
    public class ExchangeService : IExchangeService
    {
        private readonly IExchangeRateProvider _ratesProvider;

        public ExchangeService(IExchangeRateProvider ratesProvider)
        {
            _ratesProvider = ratesProvider;
        }

        public async Task<IEnumerable<ExchangeModel>> GetExchangeRatesFromTo(string currency, DateTime dateFrom, DateTime dateTo)
        {
            var result = new List<ExchangeModel>();

            for(var date = dateFrom.Date; date.Date <= dateTo.Date; date = date.AddDays(1))
            {
                result.Add(await _ratesProvider.GetRate(currency, date));
            }

            return result;
        }
    }
}
