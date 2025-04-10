namespace AgroFile.Shared.Common;

public class PaginationParams
{
    public int PageNumber { get; set; } = 1;
    public int PageSize { get; set; } = 10;

    public int MaxSize { get; set; } = 50;

    public int FinalSize => PageSize > MaxSize ? MaxSize : PageSize;

}
