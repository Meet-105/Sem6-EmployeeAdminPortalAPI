using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalAPI.DataModels
{
    public class EmployeeAdminContext : DbContext
    {
        public EmployeeAdminContext( DbContextOptions<EmployeeAdminContext> options ) : base(options ) { 

        }
        public DbSet<Employee> Employee { get; set; }
        public DbSet<Department> Department { get; set; }
        public DbSet<Role> Role { get; set; }  


    }
}
