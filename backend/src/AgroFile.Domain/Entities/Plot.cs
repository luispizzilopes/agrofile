using AgroFile.Domain.Common;
using AgroFile.Domain.Exceptions;
using AgroFile.Domain.Exceptions.Messages;

namespace AgroFile.Domain.Entities;

public class Plot : BaseEntity
{
    public string UniqueIdentifier { get; set; } = string.Empty;
    public string Name { get; set; } = string.Empty; 
    public decimal Area { get; set; }
    public int SoilType { get; set; }
    public Guid EstateId { get; set; }
    public Estate? Estate { get; set; }

    public Plot() { }

    public Plot(string uniqueIdentifier, string name, decimal? area, int? soilType, Guid? estateId)
    {
        if (string.IsNullOrEmpty(uniqueIdentifier))
            throw new AgroFileDomainException(MessagesPlotAgroFileException.UniqueIdentifierIsRequired);

        if (string.IsNullOrEmpty(name))
            throw new AgroFileDomainException(MessagesPlotAgroFileException.NameIsRequired);

        if (area == null)
            throw new AgroFileDomainException(MessagesPlotAgroFileException.AreaIsRequired);

        if (soilType == null)
            throw new AgroFileDomainException(MessagesPlotAgroFileException.SoilTypeIsRequired);

        if (estateId == null)
            throw new AgroFileDomainException(MessagesPlotAgroFileException.EstateIsRequired);

        UniqueIdentifier = uniqueIdentifier;
        Name = name;
        Area = (decimal)area;
        SoilType = (int)soilType;
        EstateId = (Guid)estateId;
    }

    public static Plot Create(string uniqueIdentifier, string name, decimal? area, int? soilType, Guid? estateId)
    {
        return new Plot(uniqueIdentifier, name, area, soilType, estateId); 
    }
}