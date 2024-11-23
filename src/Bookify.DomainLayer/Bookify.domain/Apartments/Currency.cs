using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.domain.Apartments
{
    public record Currency
    {
        public string Code { get; init; }
        private Currency(string code)
        {
            Code = code;
        }

        internal static readonly Currency None = new("");
        public static readonly Currency Usd = new("USD");
        public static readonly Currency Eur = new("EUR");

        public static readonly IReadOnlyCollection<Currency> All = new[] 
        { 
            Usd,
            Eur
        };
        
        public static Currency FromeCode(string code)
        {
            return All.FirstOrDefault(c => c.Code == code)??
                throw new ApplicationException("the currency code invalid");
        }
    }
}