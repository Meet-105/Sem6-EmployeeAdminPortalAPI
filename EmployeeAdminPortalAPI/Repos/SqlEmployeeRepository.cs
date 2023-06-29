using EmployeeAdminPortalAPI.DataModels;
using Microsoft.EntityFrameworkCore;

namespace EmployeeAdminPortalAPI.Repos
{


    public class SqlEmployeeRepository : IEmployeeRepository
    {
        private readonly EmployeeAdminContext context;

        public SqlEmployeeRepository(EmployeeAdminContext context)
        {
            this.context = context;
        }
        public async Task<List<Employee>> GetEmployees()
        {
            return await context.Employee.ToListAsync();
        }
        public async Task<Employee> GetEmployeeAsync(long id)
        {
            return await context.Employee.FirstOrDefaultAsync( x => x.ID  == id);
        }

        public async Task<List<Role>> GetRoles()
        {
            return await context.Role.ToListAsync();
        }

        public async Task<List<Department>> GetDepartments()
        {
            return await context.Department.ToListAsync();
        }

        public async Task<bool> Exist(long id)
        {
            return await context.Employee.AnyAsync( x => x.ID == id);
        }
        public async Task<Employee> UpdateEmployee(long id, Employee req)
        {
            var exist = await GetEmployeeAsync(id);
            if (exist != null)
            { 
                exist.FirstName = req.FirstName;
                exist.LastName = req.LastName;
                exist.Email = req.Email;
                exist.Address = req.Address;
                exist.DateOfBirth   = req.DateOfBirth;
                exist.Mobile= req.Mobile;
                exist.roleId = req.roleId;
                exist.deptId = req.deptId;
                context.SaveChanges();
                return exist;
            }
            return null;
        }

        public async Task<Employee> DeleteEmployee(long id)
        {
            var emp = await GetEmployeeAsync(id);
            if (emp != null)
            {
                context.Employee.Remove(emp);
                await context.SaveChangesAsync();
            }
            return null;
            
        }

        public async Task<Employee> CreateEmployee(Employee req)
        {
            var emp = await context.Employee.AddAsync(req);
            await context.SaveChangesAsync();
            return emp.Entity;
        }
    }
}
