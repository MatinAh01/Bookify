using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Bookify.domain.Abstractions;

namespace Bookify.domain.Apartments
{
    public static class ApartmentErrors
    {
        public static Error NotFound = new(
            "Apartment.NotFound",
            "The apartment with the specified identifier was not found");
    }
}