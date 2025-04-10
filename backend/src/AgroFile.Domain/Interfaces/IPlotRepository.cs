using AgroFile.Domain.Common;
using AgroFile.Domain.Entities;
using AgroFile.Shared.Common;

namespace AgroFile.Domain.Interfaces; 

public interface IPlotRepository
{
    Task<PaginedResult<Plot>> GetPlots(PaginationParams parameters);
    Task<Department> GetPlot(Guid id);
    Task<Department> CreatePlot(Plot plot);
    Task<Department> UpdatePlot(Plot plot);
    Task<bool> DeletePlot(Plot plot); 
}
