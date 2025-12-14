using Demo.BLL.Interfaces;
using Demo.DAL.Contexts;
using Demo.DAL.Models;

namespace Demo.BLL.Repositories
{
    public class EmployeeRepository : GenericRepository<Employee>, IEmployeeRepository
    {
        public EmployeeRepository(CompanyDbContext context) : base(context) { }
    }
}