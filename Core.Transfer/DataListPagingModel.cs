using System.Reflection;
using System.Text;
using Core.Transfer.Constants;
using Core.Transfer.Filtering;
using Microsoft.AspNetCore.Http;

namespace Core.Transfer;

public class DataListPagingModel
{
    public string? SortBy { get; set; }
    public SortDirection SortDirection { get; set; }
    
    public int CurrentPage { get; set; }
    
    public int PageSize { get; set; }

    public Filter? Filter { get; set; }

    public static ValueTask<DataListPagingModel?> BindAsync(HttpContext context,
        ParameterInfo parameter)
    {
        //todo redo to grpc
        Enum.TryParse<SortDirection>(context.Request.Query[RoutingConstants.SortDirectionKey],
            ignoreCase: true, out var sortDirection);
        int.TryParse(context.Request.Query[RoutingConstants.CurrentPageKey], out var page);
        int.TryParse(context.Request.Query[RoutingConstants.PageCountKey], out var pageCount);
        page = page == 0 ? 1 : page;
        pageCount = page == 0 ? 6 : pageCount;

        // string[] labels = context.Request.Query[RoutingConstants.FilterLabelsValueKey];
        HashSet<string> labels = context.Request.Query[RoutingConstants.FilterLabelsValueKey].ToHashSet();
    
        var result = new DataListPagingModel
        {
            SortBy = context.Request.Query[RoutingConstants.SortByKey],
            SortDirection = sortDirection,
            CurrentPage = page,
            PageSize = pageCount,
            Filter = new Filter()
            {
                StringValue = context.Request.Query[RoutingConstants.FilterStringValueKey],
                Labels = labels
            }
        };
    
        return ValueTask.FromResult<DataListPagingModel?>(result);
    }

    public string GetRoutingUrl(string baseUrl)
    {
        //todo redo to grpc

        var fitrstPartUrl = $"{baseUrl}?" +
                            $"{RoutingConstants.SortByKey}={this.SortBy}" +
                            $"&{RoutingConstants.SortDirectionKey}={this.SortDirection}" +
                            $"&{RoutingConstants.FilterStringValueKey}={this.Filter.StringValue}" +
                            $"&{RoutingConstants.PageCountKey}={this.PageSize}" +
                            $"&{RoutingConstants.CurrentPageKey}={this.CurrentPage}";

        
        if (this.Filter != null && this.Filter.Labels != null && this.Filter.Labels.Any())
        {
            var sb = new StringBuilder(fitrstPartUrl);
            foreach (var filterLabel in this.Filter.Labels)
            {
                sb.Append($"&{RoutingConstants.FilterLabelsValueKey}={filterLabel}");
            }

            fitrstPartUrl = sb.ToString();
        }

        return fitrstPartUrl;
    }
}

public enum SortDirection
{
    Default,
    Asc,
    Desc
}