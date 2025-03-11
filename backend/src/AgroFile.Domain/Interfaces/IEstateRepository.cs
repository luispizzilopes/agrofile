using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;

namespace AgroFile.Domain.Interfaces; 

public interface IEstateRepository
{
    Task<PaginedResult<Estate>> GetEstates(PaginationParams parameters);
    Task<Department> GetEstate(Guid id);
    Task<Department> CreateEstate(Estate estate);
    Task<Department> UpdateEstate(Estate estate);
    Task<bool> DeleteEstate(Estate estate); 
}
