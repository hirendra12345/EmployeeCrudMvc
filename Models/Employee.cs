using System.ComponentModel.DataAnnotations;

namespace EmployeeCrudMvc.Models;

public class Employee
{
    public int Id { get; set; }

    [Required, StringLength(80)]
    [Display(Name = "First name")]
    public string FirstName { get; set; } = string.Empty;

    [Required, StringLength(80)]
    [Display(Name = "Last name")]
    public string LastName { get; set; } = string.Empty;

    [Required, EmailAddress, StringLength(150)]
    public string Email { get; set; } = string.Empty;

    [Required, StringLength(100)]
    public string Department { get; set; } = string.Empty;

    [Range(0, 100000000)]
    public decimal Salary { get; set; }

    [DataType(DataType.Date)]
    [Display(Name = "Joining date")]
    public DateTime JoiningDate { get; set; } = DateTime.Today;
}
