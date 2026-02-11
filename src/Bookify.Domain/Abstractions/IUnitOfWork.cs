using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.Domain.Abstractions;

public interface IUnitOfWork
{
    Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
} 