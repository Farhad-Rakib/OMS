using Core.Entities;
using Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;
using OMS.Application.Repositories;

namespace Infrastructure.Data.Repository
{
    public class OrderRepository : BaseRepository<Order>, IOrderRepository
    {
        public OrderRepository(ApplicationDbContext context) : base(context) { }

        public async Task Add(Order order)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Save the order
                await _context.Orders.AddAsync(order);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Handle any exceptions
                Console.WriteLine(ex.Message);

            }
        }

        public async Task Update(Order order)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Save the order
                _context.Orders.Update(order);
                await _context.SaveChangesAsync();

                await transaction.CommitAsync();

            }
            catch (Exception ex)
            {
                await transaction.RollbackAsync();
                // Handle any exceptions
                Console.WriteLine(ex.Message);

            }
        }


        public async Task<IEnumerable<Order>> GetAll()
        {
            return await _context.Orders.Include(o => o.Windows)
                .ThenInclude(w => w.subElements).ToListAsync(); 
        }

        public async Task<Order> GetById(long id)
        {
            return await _context.Orders
                .Include(h => h.Windows).ThenInclude(w => w.subElements)
                .FirstOrDefaultAsync(h => h.Id == id);
        }
    }
}
