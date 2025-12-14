using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;

namespace Demo.BLL.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly CompanyDbContext _context;

        
        public IEmployeeRepository EmployeeRepository { get; set; }
        public IDepartmentRepository DepartmentRepository { get; set; }

        public UnitOfWork(CompanyDbContext context)
        {
            _context = context;
            EmployeeRepository = new EmployeeRepository(_context);
            DepartmentRepository = new DepartmentRepository(_context);
        }

        public int Complete()
        {
            return _context.SaveChanges();
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}