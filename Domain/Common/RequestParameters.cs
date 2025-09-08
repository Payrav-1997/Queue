namespace Domain.Common;

public class RequestParameters
{
    public string? Query { get; set; }


    public int Page { get; set; } = 1;
    public int PerPage { get; set; } = 10;
}