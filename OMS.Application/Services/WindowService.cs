using OMS.Application.Service;
using Core.Entities;
using OMS.Application.Repositories;

namespace OMS.Application.Services
{
    public class WindowService : IWindowService
    {
        private readonly IWindowRepository _windowRepository;
        public WindowService(IWindowRepository windowRepository)
        {
            _windowRepository = windowRepository;
        }

        public async Task Delete(int id)
        {
           await _windowRepository.DeleteAsync(id);
        }
    }
}



