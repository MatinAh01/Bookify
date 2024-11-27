using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Reviews.Events
{
public record ReviewCreatedDomainEvent(Guid ReviewId) : IDomainEvent;
}