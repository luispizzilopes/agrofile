using AgroFile.Domain.Entities.Base;

namespace AgroFile.Domain.Entities;

public class Employee : BaseEntity
{
    public string FirstName { get; set; } = string.Empty;
    public string? MiddleName { get; set; }
    public string LastName { get; set; } = string.Empty;
    public DateTimeOffset? BirthdayDate { get; set; }
    public string IndividualRegistration { get; set; } = string.Empty; 
    public decimal Wage { get; set; }
    public string Email { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Address { get; set; } = string.Empty;
    public string JobTitle { get; set; } = string.Empty;
    public DateTimeOffset HireDate { get; set; }
    public DateTimeOffset? TerminationDate { get; set; }
    public bool IsActive { get; set; }
    public Guid DepartmentId { get; set; }
    public Department? Department { get; set; }
    public Guid? ManagerId { get; set; }
    public Employee? Manager { get; set; }
}