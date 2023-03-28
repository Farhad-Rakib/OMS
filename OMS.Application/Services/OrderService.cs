using OMS.Application.Service;
using Core.Entities;
using OMS.Application.Repositories;

namespace OMS.Application.Services
{
    public class OrderService : IOrderService
    {
        private readonly IOrderRepository _orderRepository;
        public OrderService(IOrderRepository  orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public async Task<IEnumerable<Order>> Get()
        {
            try
            {
                return await _orderRepository.GetAll();
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task<Order> GetById(int id)
        {
            try
            {
                return await _orderRepository.GetById(id);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Add(Order order)
        {
            await _orderRepository.AddAsync(order);
        }

        public async Task Update(Order order)
        {
            try
            {
                await _orderRepository.Update(order);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }

        public async Task Delete(int id)
        {
            try
            {
                var orderToDelete = await _orderRepository.GetById(id);
                if (orderToDelete != null)
                {
                    await _orderRepository.DeleteAsync(orderToDelete.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}



