using AutoMapper;
using Core.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using OMS.Application.Service;
using OMS.Shared.DTO;

namespace OMS.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController : ControllerBase
    {

        private readonly IOrderService _orderService;
        private readonly IWindowService _windowService;
        private readonly ISubElementService _subElementService;
        private readonly IMapper _mapper;
        public OrderController(IOrderService orderService, IMapper mapper, IWindowService windowService, ISubElementService subElementService)
        {
            _orderService = orderService;
            _windowService = windowService;
            _subElementService = subElementService;
            _mapper = mapper;
        }

       

        [HttpGet("orders")]
        public async Task<ActionResult<List<OrderDTO>>> GetOrdersData()
        {
            var orders = await _orderService.Get();
            List<OrderDTO> orderDTO = _mapper.Map<List<OrderDTO>>(orders);
            return Ok(orderDTO);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<Order>> GetSingleOrder(int id)
        {
            var order = await _orderService.GetById( id);
            if (order == null)
            {
                return NotFound("Sorry,the item you are looking for is unavailable. :/");
            }

            var orderDTO = _mapper.Map<OrderDTO>(order);
            return Ok(orderDTO);
        }

        [HttpPost]
        public async Task<ActionResult<List<Order>>> PostOrder(Order order)
        {

            try
            {
                order.CreatedOn = DateTime.Now.ToUniversalTime();
                order.UpdatedOn = DateTime.Now.ToUniversalTime();
                await _orderService.Add(order);

            }
            catch (Exception ex)
            {
               
                Console.WriteLine(ex.Message);

            }

            return Ok(await GetOrdersData());
        }


        [HttpPut("{id}")]
        public async Task<ActionResult<List<Order>>> UpdateOrder(Order order, int id)
        {
            await _orderService.Update(order);

            return Ok(await GetOrdersData());
        }

        [HttpDelete("{id}")]
        public async Task DeleteOrder(int id)
        {
            await _orderService.Delete(id);
        }

        [HttpDelete("window-delete/{id}")]
        public async Task DeleteWindow(int id)
        {
            await _windowService.Delete( id);
        }

        [HttpDelete("subelement-delete/{id}")]
        public async Task DeleteSubElement(int id)
        {
            await _subElementService.Delete(id);
        }
        
    }
}
