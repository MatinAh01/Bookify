using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Apartments;

namespace Bookify.Domain.Booking;

public class PricingService
{
    public PricingDetails CalculatePrice(Apartment apartment, DateRange duration)
    {
        var currency = apartment.Price.Currency;
        var PriceForPeriod = new Money(apartment.Price.Amount * duration.Lenghtdate, currency);

        decimal percentageUpCharge = 0;

        foreach (var amentity in apartment.Amenities)
        {
            percentageUpCharge += amentity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0
            };
        }

        var amenitiesUpCharge = Money.Zero(currency);

        if (percentageUpCharge > 0)
        {
            amenitiesUpCharge = new Money(PriceForPeriod.Amount * percentageUpCharge, currency);
        }

        var totalPrice = amenitiesUpCharge + PriceForPeriod;

        if (!apartment.CleaningFee.IsZero())
        {
            totalPrice += apartment.CleaningFee;
        }

        return new(PriceForPeriod, apartment.CleaningFee, amenitiesUpCharge, totalPrice);
    }
}