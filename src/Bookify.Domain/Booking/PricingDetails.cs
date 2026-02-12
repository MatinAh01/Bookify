using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Booking;

public record PricingDetails(
    Money PriceForPeriod,
    Money cleaningFee,
    Money amenitiesUpCharge,
    Money totalPrice);