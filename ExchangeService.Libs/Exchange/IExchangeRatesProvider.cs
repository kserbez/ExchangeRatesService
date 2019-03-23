using ExchangeService.Libs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeService.Libs.Exchange
{
    public interface IExchangeRateProvider
    {
        Task<ExchangeModel> GetRate(string currency, DateTime date);
    }
}
