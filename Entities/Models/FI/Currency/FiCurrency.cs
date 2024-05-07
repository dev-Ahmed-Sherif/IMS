using System.Collections.Generic;

namespace Entities.Models.FI.Currency
{
    public class FiCurrency
    {
        public int Id { get; set; }
        public string ArName { get; set; }
        public string EnName { get; set; }
        public virtual ICollection<FiCurrencyPrice> Prices { get; set; }
    }
}
