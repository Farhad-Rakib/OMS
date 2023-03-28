using OMS.Application.Service;
using OMS.Application.Repositories;

namespace OMS.Application.Services
{
    public class SubElementService : ISubElementService
    {
        private readonly ISubElementRepository _subElementRepository;
        public SubElementService(ISubElementRepository subElementRepository)
        {
            _subElementRepository= subElementRepository;
        }

        public async Task Delete(int id)
        {
            try
            {
                var order = await _subElementRepository.GetByIdAsync(id);
                if (order != null)
                {
                    await _subElementRepository.DeleteAsync(order.Id);
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message, ex);
            }
        }
    }
}



