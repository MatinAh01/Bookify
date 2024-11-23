using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.domain.Apartments
{
    public record Address
    (
        string Country,
        string State,
        string ZipCode,
        string City,
        string Street
    );

}