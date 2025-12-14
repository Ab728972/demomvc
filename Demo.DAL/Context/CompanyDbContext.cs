using System.Collections.Generic;
using Demo.DAL.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore; // مهم جداً
using Microsoft.EntityFrameworkCore;

namespace Demo.DAL.Contexts
{
    // غير الوراثة لـ IdentityDbContext<ApplicationUser>
    public class CompanyDbContext : IdentityDbContext<ApplicationUser>
    {
        public CompanyDbContext(DbContextOptions<CompanyDbContext> options) : base(options)
        {
        }

        public DbSet<Department> Departments { get; set; }
        public DbSet<Employee> Employees { get; set; }
    }
}