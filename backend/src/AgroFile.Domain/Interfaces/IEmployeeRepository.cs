using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;

namespace AgroFile.Domain.Interfaces; 

public interface IEmployeeRepository
{
    Task<PaginedResult<Employee>> GetEmployees(PaginationParams parameters);
    Task<Department> GetEmployee(Guid id);
    Task<Department> CreateEmployee(Employee employee);
    Task<Department> UpdateEmployee(Employee employee);
    Task<bool> DeleteEmployee(Employee employee); 
}
