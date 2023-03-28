using Core.Entities;
using Infrastructure.Dbcontext;
using OMS.Application.Repositories;

namespace Infrastructure.Data.Repository
{
    public class SubElementRepository : BaseRepository<SubElement>, ISubElementRepository
    {
        public SubElementRepository(ApplicationDbContext context) : base(context) { }

     
    }
}
