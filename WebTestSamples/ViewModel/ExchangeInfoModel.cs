using System.ComponentModel.DataAnnotations;

namespace WebTestSamples.ViewModel
{
    public class ExchangeInfoModel
    {
        public int id { get; set;}

        [Range(0, double.PositiveInfinity)]
        public decimal Amount { get; set;}
    }
}
