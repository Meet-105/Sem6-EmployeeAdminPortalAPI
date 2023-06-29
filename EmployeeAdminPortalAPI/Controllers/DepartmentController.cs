using AutoMapper;
using EmployeeAdminPortalAPI.DomainModels;
using EmployeeAdminPortalAPI.Repos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortalAPI.Controllers
{
    public class DepartmentController : Controller
    {
        private IEmployeeRepository employeerepo;
        private IMapper mapper;

        public DepartmentController(IEmployeeRepository employeeRepo, IMapper mapper)
        {
            this.employeerepo = employeeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllDepartments()
        {
            var deptlist = await employeerepo.GetDepartments();
            if (deptlist == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Department>>(deptlist));
        }
        //[HttpPut]

    }
}
