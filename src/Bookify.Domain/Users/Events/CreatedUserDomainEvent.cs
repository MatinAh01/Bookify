using Bookify.Domain.Abstractions;

namespace Bookify.Domain.Users.Events;

public record CreatedUserDomainEvent(Guid UserId) : IDomainEvent;