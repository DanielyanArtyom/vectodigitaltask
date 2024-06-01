using ClassLibrary1.Interfaces;

namespace ClassLibrary1.DTO;

public class ImagesFilterRequest: IFilter
{
    public int PageSize { get; set; } = 2;
    public int PageNumber { get; set; } = 1;
}