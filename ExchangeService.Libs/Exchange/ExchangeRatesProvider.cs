using ExchangeService.Libs.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace ExchangeService.Libs.Exchange
{
    public class ExchangeRateProvider : IExchangeRateProvider
    {
        public async Task<ExchangeModel> GetRate(string currency, DateTime date)
        {
            using (var client = new HttpClient())
            {
                string strDate = date.ToString("yyyyMMdd");

                var url = new Uri($"https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?valcode={currency}&date={strDate}&json");

                var response = await client.GetAsync(url);

                string json;
                using (var content = response.Content)
                {
                    json = await content.ReadAsStringAsync();
                }

                IEnumerable<ExchangeModel> rates = JsonConvert.DeserializeObject<IEnumerable<ExchangeModel>>(json);

                return (ExchangeModel)rates.First();
            }
        }
    }
}
