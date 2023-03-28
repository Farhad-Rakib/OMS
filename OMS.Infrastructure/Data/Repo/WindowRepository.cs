using Core.Entities;
using Infrastructure.Dbcontext;
using Microsoft.EntityFrameworkCore;
using OMS.Application.Repositories;

namespace Infrastructure.Data.Repository
{
    public class WindowRepository : BaseRepository<Window>, IWindowRepository
    {
        public WindowRepository(ApplicationDbContext context) : base(context) { }

        public async Task DeleteWindow(int id)
        {
            await using var transaction = await _context.Database.BeginTransactionAsync();

            try
            {
                // Delet the window
                var window = await _context.Windows
                    .Include(se => se.subElements)
                    .FirstOrDefaultAsync(se => se.Id == id);

                if (window == null)
                {
                    await transaction.RollbackAsync();
                }
                else
                {
                    _context.Windows.Remove(window);
                    await _context.SaveChangesAsync();
                    await transaction.CommitAsync();
                }
            }
            catch (Exception exception)
            {
                await transaction.RollbackAsync();
                throw new Exception(exception.Message);
            }
        }
    }
}
