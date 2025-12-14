using System.Collections.Generic;
using Demo.DAL.Models;
using Microsoft.EntityFrameworkCore; // <--- تأكد إن السطر ده موجود

namespace Demo.DAL.Contexts
{
    public class CompanyDbContext : DbContext
    {
        // الـ Constructor ده ضروري عشان ياخد الـ Options من الـ Program.cs ويبعتها للأب (base)
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; } 
    }
}