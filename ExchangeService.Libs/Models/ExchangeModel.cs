using System.Runtime.Serialization;

namespace ExchangeService.Libs.Models
{
    [DataContract]
    public class ExchangeModel
    {
        [DataMember(Name = "r030")]
        public int R030 { get; set; }

        [DataMember(Name = "txt")]
        public string CurrencyFullName { get; set; }

        [DataMember(Name = "rate")]
        public double Rate { get; set; }

        [DataMember(Name = "cc")]
        public string CurrencyCode { get; set; }

        [DataMember(Name = "exchangedate")]
        public string Date { get; set; }
    }
}
