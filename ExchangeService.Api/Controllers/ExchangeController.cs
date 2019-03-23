using System;
using System.Globalization;
using System.Threading.Tasks;
using ExchangeService.Libs.Services;
using Microsoft.AspNetCore.Mvc;

namespace ExchangeService.Api.Controllers
{
    //[Route("api/v1/[controller]/[action]")]
    [ApiController]
    public class ExchangeController : ControllerBase
    {
        private readonly IExchangeService _exchangeService;

        public ExchangeController(IExchangeService exchangeService)
        {
            _exchangeService = exchangeService;
        }


        [HttpGet]
        [Route("api/v1/exchange/getRate/{currency}/{date}")]
        public async Task<IActionResult> GetRate(string currency, string date)
        {
            return await GetRates(currency, date, date);
        }

        [HttpGet]
        [Route("api/v1/exchange/getRates/{currency}/from{dateFrom}/to{dateTo}")]
        public async Task<IActionResult> GetRates(string currency, string dateFrom, string dateTo)
        {
            var format = new string[] { "yyyyMMdd" };
            var provider = CultureInfo.InvariantCulture;
            var style = DateTimeStyles.None;

            if (!DateTime.TryParseExact(dateFrom, format, provider, style, out DateTime dateTimeFrom) ||
                !DateTime.TryParseExact(dateTo, format, provider, style, out DateTime dateTimeTo) )
                return BadRequest("Invalid date parameter(s) format");

            var result = await _exchangeService.GetExchangeRatesFromTo(currency, dateTimeFrom, dateTimeTo);

            return Ok(result);
        }

    }
}