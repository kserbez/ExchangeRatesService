using ExchangeService.Libs.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ExchangeService.Libs.Services
{
    public interface IExchangeService
    {
        Task<IEnumerable<ExchangeModel>> GetExchangeRatesFromTo(string currency, DateTime dateFrom, DateTime dateTo);
    }
}
