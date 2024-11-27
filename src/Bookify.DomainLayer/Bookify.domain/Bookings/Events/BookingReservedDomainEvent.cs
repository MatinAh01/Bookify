using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Bookings.Events
{
    public record BookingReservedDomainEvent(Guid BookingId) : IDomainEvent;
}