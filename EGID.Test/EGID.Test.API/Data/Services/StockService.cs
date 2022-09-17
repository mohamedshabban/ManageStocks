using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public class StockService : IStockService
    {
        private readonly IUnitOfWork _unitOfWork;
        public StockService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Stock> CreateStock(Stock newStock)
        {
            await _unitOfWork.Stocks.AddAsync(newStock);
            await _unitOfWork.CommitAsync();
            return newStock;
        }

        public async Task DeleteStock(Stock Stock)
        {
            _unitOfWork.Stocks.Remove(Stock);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Stock>> GetAllStocks()
        {
            return await _unitOfWork.Stocks.GetAllAsync();
        }

        public async Task<Stock> GetStockById(int id)
        {
            return await _unitOfWork.Stocks.GetByIdAsync(id);
        }

        public async Task UpdateStock(Stock StockToBeUpdated, Stock Stock)
        {
            //StockToBeUpdated.Name = Stock.Name;
            //StockToBeUpdated.BirthDate = Stock.BirthDate;
            //StockToBeUpdated.HiringDate = Stock.HiringDate;
            //StockToBeUpdated.Title = Stock.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}
