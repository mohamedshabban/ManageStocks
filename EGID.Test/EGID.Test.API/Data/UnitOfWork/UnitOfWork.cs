using EGID.Test.API.Data.Repositores;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly EGIDDbContext _context;
        private StockRepository _StockRepository;
        private OrderRepository _OrderRepository;
        private ClientRepository _ClientRepository;
        private BrokerRepository _BrokerRepository;

        public UnitOfWork(EGIDDbContext context)
        {
            this._context = context;
        }


        public IStockRepository Stocks => _StockRepository = _StockRepository ?? new StockRepository(_context);
        public IOrderRepository Orders => _OrderRepository = _OrderRepository ?? new OrderRepository(_context);
        public IClientRepository Clients => _ClientRepository = _ClientRepository ?? new ClientRepository(_context);
        public IBrokerRepository Brokers =>  _BrokerRepository ?? new BrokerRepository(_context);

        public async Task<int> CommitAsync()
        {
            return await _context.SaveChangesAsync();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
