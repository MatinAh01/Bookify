using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bookify.domain.Abstractions
{
    public interface IUntitOfWork
    {
        Task<int> SaveChangeAsync(CancellationToken cancellationToken= default);
    }
}