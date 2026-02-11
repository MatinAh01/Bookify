using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.Domain.Abstractions;
using Bookify.Domain.Users.Events;

namespace Bookify.Domain.Users;

public class User : Entity
{
    public FirstName FirstName { get; private set; }
    public LastName LastName { get; private set; }
    public Email Email { get; private set; }
     public User(
        Guid id,
        FirstName firstName,
        LastName lastName,
        Email email) : base(id)
     {
        FirstName = firstName;
        LastName = lastName;
        Email = email;
     }

     public static User Create(FirstName firstName, LastName lastName, Email email)
    {
        var user = new User(Guid.NewGuid(), firstName, lastName, email);

        user.RaiseDomainEvents(new UserCreatedDomainEvent(user.Id));

        return user;
    }
}