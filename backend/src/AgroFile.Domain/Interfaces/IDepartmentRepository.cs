using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Shared.Common;

namespace AgroFile.Domain.Interfaces; 

public interface IDepartmentRepository
{
    Task<PaginedResult<Department>> GetDepartments(PaginationParams parameters);
    Task<Department> GetDepartment(Guid id);
    Task<Department> CreateDepartment(Department department);
    Task<Department> UpdateDepartment(Department department);
    Task<bool> DeleteDepartment(Department department); 
}
