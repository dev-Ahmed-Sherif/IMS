using System;

namespace Entities.Models.FI.Currency
{
    public class FiCurrencyPrice
    {
        public int Id { get; set; }
        public int CurrencyId { get; set; }
        public virtual FiCurrency Currency { get; set; }
        public DateTime Date { get; set; }
        public decimal Price { get; set; }
    }
}
