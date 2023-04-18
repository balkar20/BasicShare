using System.Reflection;
using Microsoft.AspNetCore.Http;

namespace Core.Transfer;

public class DataListPagingModel
{
    public string? SortBy { get; init; }
    public SortDirection SortDirection { get; init; }
    
    public int CurrentPage { get; init; } = 1;
    
    public int PageCount { get; init; } = 1;
    
    public string FilterBy { get; init; }
    
    public string Filter { get; init; }

    public static ValueTask<DataListPagingModel?> BindAsync(HttpContext context,
        ParameterInfo parameter)
    {
        const string sortByKey = "sortBy";
        const string sortDirectionKey = "sortDir";
        const string currentPageKey = "page";
        const string pageCountKey = "pageCount";
        const string filterByKey = "filterBy";
        const string filterKey = "filter";
    
        Enum.TryParse<SortDirection>(context.Request.Query[sortDirectionKey],
            ignoreCase: true, out var sortDirection);
        int.TryParse(context.Request.Query[currentPageKey], out var page);
        int.TryParse(context.Request.Query[pageCountKey], out var pageCount);
        page = page == 0 ? 1 : page;
        pageCount = page == 0 ? 6 : pageCount;
    
        var result = new DataListPagingModel
        {
            SortBy = context.Request.Query[sortByKey],
            SortDirection = sortDirection,
            CurrentPage = page,
            PageCount = pageCount,
            FilterBy = context.Request.Query[filterByKey],
            Filter = context.Request.Query[filterKey],
        };
    
        return ValueTask.FromResult<DataListPagingModel?>(result);
    }
}

public enum SortDirection
{
    Default,
    Asc,
    Desc
}