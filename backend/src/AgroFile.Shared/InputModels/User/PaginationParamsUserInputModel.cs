using AgroFile.Shared.Common;
using System.ComponentModel.DataAnnotations;

namespace AgroFile.Shared.InputModels.User;

public class PaginationParamsUserInputModel : PaginationParams
{
    [MaxLength(100)]
    public string? UserName { get; set; }

    public bool? Active { get; set; }
}
