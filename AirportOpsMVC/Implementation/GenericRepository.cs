using AirportOpsMVC.Data;
using AirportOpsMVC.Interface;
using Microsoft.EntityFrameworkCore;

namespace AirportOpsMVC.Implementation
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly AirportDbContext _context;
        private readonly DbSet<T> _dbSet;
        public GenericRepository(AirportDbContext Context)
        {
            _context = Context;
            _dbSet = Context.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T?> GetByIdAsync(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task AddAsync(T entity)
        {
           await _dbSet.AddAsync(entity);
        }
        public async Task UpdateAsync(T entity)
        {
             _dbSet.Update(entity);   
        }
        public async Task DeleteAsync(T entity)
        {
            _dbSet.Remove(entity);
        }
        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }
    }
}
