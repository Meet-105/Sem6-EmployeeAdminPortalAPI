
using AutoMapper;
using dm = EmployeeAdminPortalAPI.DomainModels;
using Dm = EmployeeAdminPortalAPI.DataModels;
using EmployeeAdminPortalAPI.Repos;
using Microsoft.AspNetCore.Mvc;
using EmployeeAdminPortalAPI.DataModels;

namespace EmployeeAdminPortalAPI.Controllers
{
    [ApiController]
    public class EmployeesController : Controller
    {
        private readonly IMapper mapper;
        private readonly IEmployeeRepository employeerepo;

        public EmployeesController(IEmployeeRepository employee, IMapper mapper) {
            this.mapper = mapper;
            this.employeerepo = employee;
        }
        [HttpGet]
        [Route("[controller]")]
        public async Task<IActionResult> GetAllEmployee()
        {
            var employees = await employeerepo.GetEmployees();
            
            return  Ok(mapper.Map<List<Employee>>(employees));
        }
        [HttpGet]
        [Route("[controller]/{id:long}"), ActionName("GetEmployeeAsync")]
        public async Task<IActionResult> GetEmployeeAsync([FromRoute] long id)
        {
            //Fetching
            var employee = await employeerepo.GetEmployeeAsync(id);
            if(employee == null)
            {
                return NotFound();
            }
            return Ok(mapper.Map<Employee>(employee));

        }
        [HttpPut]
        [Route("[controller]/{id:long}")]
        public async Task<IActionResult> UpdateEmployeeAysnc([FromRoute] long id, [FromBody] dm.UpdateEmployee req)
        {
            if(await employeerepo.Exist(id))
            {
                var n = await employeerepo.UpdateEmployee(id,mapper.Map<Dm.Employee>(req));
                if(n != null)
                {
                    return Ok(mapper.Map<dm.Employee>(n));
                }
            }
            
            return NotFound();
            
        }
        [HttpDelete]
        [Route("[controller]/{id:long}")]
        public async Task<IActionResult> DeleteEmployeeAsnc([FromRoute] long id)
        {
            if(await employeerepo.Exist(id))
            {
                var e = await employeerepo.DeleteEmployee(id);
                return Ok(mapper.Map<dm.Employee>(e));
            }
            return NotFound();
        }
        [HttpPost]
        [Route("[controller]/add")]
        public async Task<IActionResult> AddStudentAsync([FromBody] dm.AddEmpReq req)
        {

            var n = await employeerepo.CreateEmployee(mapper.Map<Dm.Employee>(req));
            return CreatedAtAction(nameof(GetEmployeeAsync), new {id = n.ID},
                mapper.Map<dm.Employee>(n));
        }
        
    }
}
