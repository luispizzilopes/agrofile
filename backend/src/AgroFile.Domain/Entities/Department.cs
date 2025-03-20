using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Messages;

namespace AgroFile.Domain.Entities;

public class Department : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty; 
    public ICollection<Employee>? Employees { get; set; }

    public Department() { }

    public Department(string name, string description)
    {
        if (string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesDepartmentAgroFileDomain.NameIsRequired);

        if (string.IsNullOrEmpty(description))
            throw new AgroFileDomainException(MessagesDepartmentAgroFileDomain.DescriptionIsRequired);

        Name = name;
        Description = description;
    }

    public static Department Create(string name, string description)
    {
        return new Department(name, description);
    }
}
