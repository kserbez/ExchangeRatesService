# Exchange Rates Service

This is a personal educational and fun project. It sends requests to bank.gov.ua APIs to get some currency exchange rates to UAH on a particular day. These requests are used to create responses to personal APIs which have more convenient format and might return some currency exchange to UAH for some periods of time. So the project might be viewed as an adapter APIs to 3rd party APIs.

The VisualStudio solution consists of an AspNetCore 2.1 project and the exchange service dynamic library (dll) which is injected to the AspNet project through built in Dependency Injection (DI) container.

### API format
- To get exchange rates on a certaing day send a GET response on URL **/api/v1/exchange/getRate/{currency}/{date}**
- To get exchange rates during a certain period of time send a GET response on URL **api/v1/exchange/getRates/{currency}/from{date}/to{date}**

**{date}** has **YYYYMMDD** format
**{currency}** might be for instance **USD**, **EUR**, **RUB**, **GBP** and many others (the full list see at https://bank.gov.ua/NBUStatService/v1/statdirectory/exchange?json)

### Building for source
Open the solution in Visual Studio 2017+ and rebuild all projects. Then run the project.

### License
MIT
