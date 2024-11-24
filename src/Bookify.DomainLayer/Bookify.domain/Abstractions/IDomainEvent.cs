using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.VisualBasic;

namespace Bookify.domain.Abstractions
{
    public interface IDomainEvent : INotification
    {
        
    }
}