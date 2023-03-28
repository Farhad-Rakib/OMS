
using Core.Entities;
using OMS.Application.Repositories.Base;
namespace OMS.Application.Repositories
{
    public interface IOrderRepository : IBaseRepository<Order>
    {
        Task Add(Order order);
        Task Update(Order order);
        Task<IEnumerable<Order>> GetAll();
        Task<Order> GetById(long id);
    }
}
