using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Booking.Events;

public record BookingCompletedDomainEvent(Guid Id) : IDomainEvent;