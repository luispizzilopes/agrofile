using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Messages;

namespace AgroFile.Domain.Entities;

public class YearManagement : BaseEntity
{
    public int Year { get; set; }
    public string Name { get; set; } = string.Empty;
    public DateTimeOffset StartDate { get; set; }
    public DateTimeOffset EndDate { get; set; }
    public bool Open { get; set; }

    public YearManagement() { }

    public YearManagement(int? year, string name, DateTimeOffset? startDate, DateTimeOffset? endDate, bool open)
    {
        if (year == null)
            throw new AgroFileDomainException(MessagesYearManagementAgroFileDomain.YearIsRequired); 

        if(string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesYearManagementAgroFileDomain.NameIsRequired);

        if (startDate == null)
            throw new AgroFileDomainException(MessagesYearManagementAgroFileDomain.StartDateIsRequired);

        if (endDate == null)
            throw new AgroFileDomainException(MessagesYearManagementAgroFileDomain.EndDateIsRequired);

        Year = (int)year;
        Name = name;
        StartDate = (DateTimeOffset)startDate;
        EndDate = (DateTimeOffset)endDate;
        Open = open;
    }

    public static YearManagement Create(int? year, string name, DateTimeOffset? startDate, DateTimeOffset? endDate, bool open)
    {
        return new YearManagement(year, name, startDate, endDate, open); 
    }
}
