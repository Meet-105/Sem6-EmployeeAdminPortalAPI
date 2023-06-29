namespace EmployeeAdminPortalAPI.DomainModels
{
    public class UpdateEmployee
    {
        public long ID { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string? Email { get; set; } = string.Empty;
        public long? Mobile { get; set; }
        public string? Address { get; set; }
        public long roleId { get; set; }
        public long deptId { get; set;}
    }
}
