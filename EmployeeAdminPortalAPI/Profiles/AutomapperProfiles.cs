using AutoMapper;
using EmployeeAdminPortalAPI.DataModels;
using Dms = EmployeeAdminPortalAPI.DomainModels;

namespace EmployeeAdminPortalAPI.Profiles
{
    public class AutomapperProfiles : Profile
    {
        public AutomapperProfiles()
        {
            CreateMap<Dms.UpdateEmployee, Employee>().ReverseMap();
            CreateMap<Dms.AddEmpReq, Employee>().ReverseMap();
            CreateMap<Employee, Dms.Employee>().ReverseMap();
            CreateMap<Department, Dms.Department>().ReverseMap();
            CreateMap<Role, Dms.Role>().ReverseMap();
            CreateMap<Department, Dms.Department>().ReverseMap();

            //CreateMap<Dms.UpdateEmployee, Employee>().ReverseMap().ForMember(65)
            //CreateMap<Dms.AddEmpReq, Employee>().ReverseMap().AfterMap(78)
        }
    }
}
