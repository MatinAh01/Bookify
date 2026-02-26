using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Reviews.Events;

namespace Bookify.Domain.Reviews;

public class Review : Entity
{
    public Guid UserId { get; private set; }
    public Guid ApartmentId { get; private set; }
    public Guid BookingId { get; private set; }
    public Rating Rating { get; private set; }
    public Comment Comment { get; private set; }
    public DateTime CreatedOnUtc { get; set; }
    private Review(
        Guid id, 
        Guid userId, 
        Guid apartmentId, 
        Guid bookingId, 
        Rating rating, 
        Comment comment, 
        DateTime createdOnUtc) : base(id)
    {
        UserId = userId;
        ApartmentId = apartmentId;
        BookingId = bookingId;
        Rating = rating;
        Comment = comment;
        CreatedOnUtc = createdOnUtc;
    }

    public static Result<Review> Create(
        Booking.Booking booking, 
        Rating rating, 
        Comment comment,
        DateTime createdOnUtc)
    {
        if (booking.Status != Booking.BookingStatus.Completed)
        {
            return Result.Failure<Review>(ReviewErrors.NotEligible);
        }

        var review = new Review(
            Guid.NewGuid(),
            booking.UserId,
            booking.ApartmrntId,
            booking.Id,
            rating,
            comment,
            createdOnUtc);
        
        review.RaiseDomainEvents(new ReviewCreatedDomainEvent(review.Id));

        return review;
    }
}