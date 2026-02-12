using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Apartments;
using Bookify.Domain.Booking.Events;

namespace Bookify.Domain.Booking;

public class Booking : Entity
{
    public Guid ApartmrntId { get; private set; }
    public Guid UserId { get; private set; }
    public DateRange Duration { get; private set; }
    public Money PriceForPerio { get; private set; }
    public Money CleaningFee { get; private set; }
    public Money AmenitiesUpCharge { get; private set; }
    public Money TotalPrice { get; private set; }
    public BookingStatus Status { get; private set; }
    public DateTime CreateOnUtc { get; private set; }
    public DateTime? ConfirmedOnUtc { get; private set; }
    public DateTime? RejectedOnUtc { get; private set; }
    public DateTime? CompletedOnUtc { get; private set; }
    public DateTime? CancelledOnUtc { get; private set; }
    private Booking(
        Guid id,
        Guid apartmrntId,
        Guid userId, 
        DateRange duration, 
        Money priceForPeriod, 
        Money cleaningFee, 
        Money amenitiesUpCharge, 
        Money totalPrice, 
        BookingStatus status, 
        DateTime createOnUtc) : base(id)
    {
        ApartmrntId = apartmrntId;
        UserId = userId;
        Duration = duration;
        PriceForPerio = priceForPeriod;
        CleaningFee = cleaningFee;
        AmenitiesUpCharge = amenitiesUpCharge;
        TotalPrice = totalPrice;
        Status = status;
        CreateOnUtc = createOnUtc;
    }

    public static Booking Reserve(Apartment apartment,Guid userId, DateRange duration, DateTime utcNoew, PricingService pricingService)
    {
        var pricingdetail = pricingService.CalculatePrice(apartment, duration);

        var booking = new Booking(
            Guid.NewGuid(), 
            apartment.Id, 
            userId, 
            duration,
            pricingdetail.PriceForPeriod,
            pricingdetail.cleaningFee,
            pricingdetail.amenitiesUpCharge,
            pricingdetail.totalPrice,
            BookingStatus.Reserved,
            utcNoew);

        booking.RaiseDomainEvents(new BookingReservedDomainEvent(booking.Id));

        apartment.LastBookedOnUtc = booking.CreateOnUtc;

        return booking;
    }
    
}