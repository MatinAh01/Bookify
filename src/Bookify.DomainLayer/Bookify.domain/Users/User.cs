using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;
using Bookify.domain.Users.Events;

namespace Bookify.domain.Users
{
    public sealed class User : Entity
    {
        public FirstName FirstName { get; private set; }
        public LastName LastName { get; private set; }
        public Email Email { get; private set; }


        private User(Guid id, FirstName firstName, LastName lastName, Email email) : base(id)
        {
            FirstName = firstName;
            LastName = lastName;
            Email = email;
        }

        public static User Create( FirstName firstName, LastName lastName, Email email)
        {
            var user = new User(Guid.NewGuid() , firstName, lastName, email);

            user.RaiseDomainEvents(new UserCreationDomainEvent(user.Id));
            
            return user;
        }


    }
}