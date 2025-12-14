using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;

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
    }
}