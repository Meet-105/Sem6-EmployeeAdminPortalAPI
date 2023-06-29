using AutoMapper;
using EmployeeAdminPortalAPI.DomainModels;
using EmployeeAdminPortalAPI.Repos;
using Microsoft.AspNetCore.Mvc;

namespace EmployeeAdminPortalAPI.Controllers
{
    public class RoleController : Controller
    {
        private IEmployeeRepository employeerepo;
        private IMapper mapper;

        public RoleController(IEmployeeRepository employeeRepo, IMapper mapper) {
            this.employeerepo = employeeRepo;
            this.mapper = mapper;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllRoles()
        {
            var rolelist = await employeerepo.GetRoles();
            if(rolelist == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<List<Role>>(rolelist));
        }
        //[HttpPut]
        
    }
}
