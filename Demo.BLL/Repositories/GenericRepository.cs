using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Microsoft.EntityFrameworkCore;

namespace Demo.BLL.Repositories
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        private readonly CompanyDbContext _context;
        public GenericRepository(CompanyDbContext context) => _context = context;

        public int Add(T entity) { _context.Set<T>().Add(entity); return _context.SaveChanges(); }
        public int Delete(T entity) { _context.Set<T>().Remove(entity); return _context.SaveChanges(); }
        public T Get(int id) => _context.Set<T>().Find(id);
        public IEnumerable<T> GetAll() => _context.Set<T>().ToList();
        public int Update(T entity) { _context.Set<T>().Update(entity); return _context.SaveChanges(); }

        
        public async Task AddAsync(T entity) { await _context.Set<T>().AddAsync(entity); await _context.SaveChangesAsync(); }
        public async Task<T> GetAsync(int id) => await _context.Set<T>().FindAsync(id);
        public async Task<IEnumerable<T>> GetAllAsync() => await _context.Set<T>().ToListAsync();
    }
}