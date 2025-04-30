using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace EmployeeAPI_Back.Models
{
    public class Employee
    {
  
            [Key]
            public int Id { get; set; }

            [Required(ErrorMessage = "First name is required")]
            [MinLength(3, ErrorMessage = "First name must be at least 3 characters")]
            [MaxLength(12, ErrorMessage = "First name cannot exceed 12 characters")]
            public string FirstName { get; set; }

            [Required(ErrorMessage = "Last name is required")]
            [MinLength(4, ErrorMessage = "Last name must be at least 4 characters")]
            [MaxLength(30, ErrorMessage = "Last name cannot exceed 30 characters")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Email is required")]
            [EmailAddress(ErrorMessage = "Invalid email format")]
            [MaxLength(100, ErrorMessage = "Email cannot exceed 100 characters")]
            public string Email { get; set; }

            [MaxLength(100, ErrorMessage = "Position cannot exceed 100 characters")]
            public string? Position { get; set; }
        
    }
}

