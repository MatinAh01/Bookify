using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Domain.Shared;

public record Currency
{
    public string Code {get; set;}
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Zero = new("");
    public static IReadOnlyCollection<Currency> All = [Usd, Eur];
    private Currency(string code)
    {
        Code = code;
    }

    public static Currency FromCode(string code)
    {
       return All.FirstOrDefault(x => x.Code == code) ??
            throw new ApplicationException("the currency code is invalid");
    }
}