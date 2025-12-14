using System;

namespace Demo.BLL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        public IEmployeeRepository EmployeeRepository { get; }
        public IDepartmentRepository DepartmentRepository { get; }

        int Complete(); 
    }
}