using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Users.Events
{
    public record UserCreationDomainEvent(Guid UserId) : IDomainEvent;
}