using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Reviews.Events;

public record ReviewCreatedDomainEvent(Guid Id) : IDomainEvent;