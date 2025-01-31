namespace EmployeeAdminPortal.Models
{
    public class EmployeeDto
    {
        

            public Guid Id { get; set; }


            public required string Name { get; set; }

            public required string Email { get; set; } = string.Empty;


            public string Phone { get; set; } = string.Empty;

            public Decimal Salary { get; set; }


        
    }
}
