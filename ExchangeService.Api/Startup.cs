using ExchangeService.Libs.Exchange;
using ExchangeService.Libs.Services;
using ExchangeServiceImplementation = ExchangeService.Libs.Services.ExchangeService;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;

namespace ExchangeService.Api
{
    public class Startup
    {
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc();
            services.AddSingleton<IExchangeService, ExchangeServiceImplementation>();
            services.AddSingleton<IExchangeRateProvider, ExchangeRateProvider>();
        }

        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseMvc();
        }
    }
}
