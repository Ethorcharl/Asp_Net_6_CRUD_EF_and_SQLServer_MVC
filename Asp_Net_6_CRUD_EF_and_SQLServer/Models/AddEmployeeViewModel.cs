namespace Asp_Net_6_CRUD_EF_and_SQLServer.Models
{
    public class AddEmployeeViewModel
    {
        public string Name { get; set; } = string.Empty;
        public string Email { get; set; } = string.Empty;
        public long Salary { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Department { get; set; } = string.Empty;
    }
}
