using EmployeeAdminPortalAPI.DataModels;


namespace EmployeeAdminPortalAPI.Repos
{
    public interface IEmployeeRepository
    {
        Task<List<Employee>> GetEmployees();
        Task<Employee> GetEmployeeAsync(long id);

        Task<List<Role>> GetRoles();

        Task<List<Department>> GetDepartments();

        Task<bool> Exist(long id);

        Task<Employee> UpdateEmployee(long id, Employee req);

        Task<Employee> DeleteEmployee(long id);

        Task<Employee> CreateEmployee(Employee req);
    }

    
}
