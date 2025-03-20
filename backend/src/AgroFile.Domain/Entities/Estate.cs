using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Messages;

namespace AgroFile.Domain.Entities;

public class Estate : BaseEntity
{
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public string? Address { get; set; } 
    public string? City { get; set; } 
    public string? State { get; set; } 
    public string? Coutry { get; set; } 

    public IEnumerable<Plot>? Plots { get; set; }

    public Estate() { }

    public Estate(string name, string description, string? address, string? city, string? state, string? coutry)
    {
        if (string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesEstateAgroFileDomain.NameIsRequired);

        if (string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesEstateAgroFileDomain.DescriptionIsRequired); 

        Name = name;
        Description = description;
        Address = address;
        City = city;
        State = state;
        Coutry = coutry;
    }

    public static Estate Create(string name, string description, string? address, string? city, string? state, string? coutry)
    {
        return new Estate(name, description, address, city, state, coutry); 
    }
}
