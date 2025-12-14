using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;

namespace Demo.BLL.Repositories
{
    public class DepartmentRepository : IDepartmentRepository
    {
        private readonly CompanyDbContext _context;
        public DepartmentRepository(CompanyDbContext context) => _context = context;

        public int Add(Department entity) { _context.Departments.Add(entity); return _context.SaveChanges(); }
        public int Update(Department entity) { _context.Departments.Update(entity); return _context.SaveChanges(); }
        public int Delete(Department entity) { _context.Departments.Remove(entity); return _context.SaveChanges(); }
        public Department Get(int id) => _context.Departments.Find(id);
        public IEnumerable<Department> GetAll() => _context.Departments.ToList();
    }
}