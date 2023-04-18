using System.Reflection;
using Core.Transfer.Constants;
using Microsoft.AspNetCore.Http;

namespace Core.Transfer;

public class DataListPagingModel
{
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
    
    public int CurrentPage { get; set; }
    
    public int PageSize { get; set; }
    
    public string? FilterBy { get; set; }
    
    public string? Filter { get; set; }

    public static ValueTask<DataListPagingModel?> BindAsync(HttpContext context,
        ParameterInfo parameter)
    {

        Enum.TryParse<SortDirection>(context.Request.Query[RoutingConstants.SortDirectionKey],
            ignoreCase: true, out var sortDirection);
        int.TryParse(context.Request.Query[RoutingConstants.CurrentPageKey], out var page);
        int.TryParse(context.Request.Query[RoutingConstants.PageCountKey], out var pageCount);
        page = page == 0 ? 1 : page;
        pageCount = page == 0 ? 6 : pageCount;
    
        var result = new DataListPagingModel
        {
            SortBy = context.Request.Query[RoutingConstants.SortByKey],
            SortDirection = sortDirection,
            CurrentPage = page,
            PageSize = pageCount,
            FilterBy = context.Request.Query[RoutingConstants.FilterByKey],
            Filter = context.Request.Query[RoutingConstants.FilterKey],
        };
    
        return ValueTask.FromResult<DataListPagingModel?>(result);
    }

    public string GetRoutingUrl(string baseUrl)
    {
        return  $"{baseUrl}?" +
                         $"{RoutingConstants.SortByKey}={this.SortBy}" +
                         $"&{RoutingConstants.SortDirectionKey}={this.SortDirection}" +
                         $"&{RoutingConstants.FilterByKey}={this.FilterBy}" +
                         $"&{RoutingConstants.FilterKey}={this.Filter}" +
                         $"&{RoutingConstants.PageCountKey}={this.PageSize}" +
                         $"&{RoutingConstants.CurrentPageKey}={this.CurrentPage}";
    }
}

public enum SortDirection
{
    Default,
    Asc,
    Desc
}