using Bookify.Domain.Apartments;
using Bookify.Domain.Shared;

namespace Bookify.Domain.Bookings;

public sealed class PricingService
{
    public PricingDetails Calculate(
        Apartment apartment,
        DateRange duration)
    {
        var currency = apartment.Price.Currency;

        var priceForPeriod = new Money(
            duration.LengthInDays * apartment.Price.Amount,
            currency);

        decimal UpchargePercentage = 0;

        foreach (var amenity in apartment.Amenities)
        {
            UpchargePercentage += amenity switch
            {
                Amenity.GardenView or Amenity.MountainView => 0.05m,
                Amenity.AirConditioning => 0.01m,
                Amenity.Parking => 0.01m,
                _ => 0m
            };
        }

        var amenitiesUprcharge = new Money(
            UpchargePercentage * priceForPeriod.Amount,
            currency);

        var cleaningFee = apartment.CleaningFee;

        var totalPrice =
            priceForPeriod +
            cleaningFee +
            amenitiesUprcharge;

        return new PricingDetails(
            priceForPeriod,
            cleaningFee,
            amenitiesUprcharge,
            totalPrice);
    }
}