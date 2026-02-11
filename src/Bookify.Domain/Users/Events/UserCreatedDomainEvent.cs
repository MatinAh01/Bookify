using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events;

public record UserCreatedDomainEvent(Guid UserId) : IDomainEvent;