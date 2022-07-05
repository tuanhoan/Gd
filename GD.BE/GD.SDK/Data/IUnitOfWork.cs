using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace GD.SDK.Data
{
    public interface IUnitOfWork :IDisposable
    {
        Task<int> SaveAsync(CancellationToken  cancellationToken = default);
    }
}
