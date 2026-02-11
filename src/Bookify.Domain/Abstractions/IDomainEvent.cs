using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;


namespace Bookify.Domain.Abstractions;

public interface IDomainEvent : INotification
{
}