using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;

namespace AgroFile.Domain.Interfaces; 

public interface IYearManagementRepository
{
    Task<PaginedResult<YearManagement>> GetYearManagements(PaginationParams parameters);
    Task<Department> GetYearManagement(Guid id);
    Task<Department> CreateYearManagement(YearManagement yearManagement);
    Task<Department> UpdateYearManagement(YearManagement yearManagement);
    Task<bool> DeleteYearManagement(YearManagement yearManagement); 
}
