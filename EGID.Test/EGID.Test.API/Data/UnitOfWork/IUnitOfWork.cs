using EGID.Test.API.Data.Repositores;
using System;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.UnitOfWork
{
    public interface IUnitOfWork : IDisposable
    {
        IStockRepository Stocks { get; }
        IOrderRepository Orders { get; }
        IClientRepository Clients { get; }
        IBrokerRepository Brokers { get; }
        Task<int> CommitAsync();
    }
}
