using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.domain.Abstractions
{
    public abstract class Entity
    {
        public Guid Id { get; init; }

        protected Entity(Guid id)
        {
            Id = id;
        }
    }
}