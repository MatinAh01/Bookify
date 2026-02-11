using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Domain.Apartments;

public interface IApartmentRepository
{
    Task<Apartment?> GetApartmentAsync(Guid id, CancellationToken cancellationToken = default);
}