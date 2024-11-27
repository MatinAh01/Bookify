using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Apartments;

namespace Bookify.domain.Bookings
{
    public record PricingDetails(
    Money PriceForPeriod,
    Money CleaningFee,
    Money AmenitiesUpCharge,
    Money TotalPrice);
}