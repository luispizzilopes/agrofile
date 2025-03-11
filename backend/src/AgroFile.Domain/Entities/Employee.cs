using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Exceptions.Messages;

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

    public Employee() { }

    public Employee(
        string firstName, 
        string? middleName, 
        string lastName, 
        DateTimeOffset? birthdayDate, 
        string individualRegistration, 
        decimal? wage, 
        string email, 
        string phoneNumber, 
        string address, 
        string jobTitle, 
        DateTimeOffset? hireDate, 
        DateTimeOffset? terminationDate, 
        bool? isActive, 
        Guid? departmentId, 
        Guid? managerId)
    {
        if (string.IsNullOrEmpty(firstName))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.FirstNameIsRequired); 

        if(string.IsNullOrEmpty(lastName))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.LastNameIsRequired);

        if (string.IsNullOrEmpty(individualRegistration))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.IndividualRegistrationIsRequired);

        if (string.IsNullOrEmpty(email))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.EmailIsRequired);

        if (string.IsNullOrEmpty(phoneNumber))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.PhoneNumberIsRequired);

        if (string.IsNullOrEmpty(address))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.AddressNumberIsRequired);

        if (string.IsNullOrEmpty(jobTitle))
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.JobTitleNumberIsRequired);

        if (wage == null)
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.WageIsRequired);

        if (hireDate == null)
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.HireDateIsRequired);

        if (isActive == null)
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.ActiveIsRequired);

        if (departmentId == null)
            throw new AgroFileDomainException(MessagesEmployeeAgroFileDomain.DepartmentIdIsRequired);

        FirstName = firstName;
        MiddleName = middleName;
        LastName = lastName;
        BirthdayDate = birthdayDate;
        IndividualRegistration = individualRegistration;
        Wage = (decimal)wage;
        Email = email;
        PhoneNumber = phoneNumber;
        Address = address;
        JobTitle = jobTitle;
        HireDate = (DateTimeOffset)hireDate;
        TerminationDate = terminationDate;
        IsActive = (bool)isActive;
        DepartmentId = (Guid)departmentId;
        ManagerId = managerId;
    }

    public static Employee Create(
        string firstName,
        string? middleName,
        string lastName,
        DateTimeOffset? birthdayDate,
        string individualRegistration,
        decimal? wage,
        string email,
        string phoneNumber,
        string address,
        string jobTitle,
        DateTimeOffset? hireDate,
        DateTimeOffset? terminationDate,
        bool? isActive,
        Guid? departmentId,
        Guid? managerId)
    {
        return new Employee(firstName, middleName, lastName, birthdayDate, individualRegistration, wage, email, phoneNumber, address, jobTitle, hireDate, terminationDate, isActive, departmentId, managerId);
    }
}