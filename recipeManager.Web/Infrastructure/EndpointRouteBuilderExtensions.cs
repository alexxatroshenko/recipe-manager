using System.Diagnostics.CodeAnalysis;

namespace recipe_manager.Infrastructure;

public static class EndpointRouteBuilderExtensions
{
    public static RouteHandlerBuilder MapGet(this IEndpointRouteBuilder builder, Delegate handler)
    {
        return builder.MapGet(handler.Method.Name, handler);
    }

    public static RouteHandlerBuilder MapPost(this IEndpointRouteBuilder builder, Delegate handler)
    {
        return builder.MapPost(handler.Method.Name, handler);
    }

    public static RouteHandlerBuilder MapPut(this IEndpointRouteBuilder builder, Delegate handler)
    {
        return builder.MapPut(handler.Method.Name, handler);
    }

    public static RouteHandlerBuilder MapDelete(this IEndpointRouteBuilder builder, Delegate handler)
    {
        return builder.MapDelete(handler.Method.Name, handler);
    }
}