using EGID.Test.API.Data.Entities;
using EGID.Test.API.Data.UnitOfWork;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace EGID.Test.API.Data.Services
{
    public class OrderService : IOrderService
    {
        private readonly IUnitOfWork _unitOfWork;
        public OrderService(IUnitOfWork unitOfWork)
        {
            this._unitOfWork = unitOfWork;
        }

        public async Task<Order> CreateOrder(Order newOrder)
        {
            await _unitOfWork.Orders.AddAsync(newOrder);
            await _unitOfWork.CommitAsync();
            return newOrder;
        }

        public async Task DeleteOrder(Order Order)
        {
            _unitOfWork.Orders.Remove(Order);

            await _unitOfWork.CommitAsync();
        }

        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _unitOfWork.Orders.GetAllAsync();
        }

        public async Task<Order> GetOrderById(int id)
        {
            return await _unitOfWork.Orders.GetByIdAsync(id);
        }

        public async Task UpdateOrder(Order OrderToBeUpdated, Order Order)
        {
            //OrderToBeUpdated.Name = Order.Name;
            //OrderToBeUpdated.BirthDate = Order.BirthDate;
            //OrderToBeUpdated.HiringDate = Order.HiringDate;
            //OrderToBeUpdated.Title = Order.Title;
            await _unitOfWork.CommitAsync();
        }
    }
}
