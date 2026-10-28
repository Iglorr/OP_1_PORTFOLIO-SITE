namespace CoreApi.Features.Projects.GetProjects;

public static class GetProjectsEndpoint
{
    public static RouteHandlerBuilder MapGetProjectsEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapGet("", GetProjectsHandler.GetProjectsHandle)
            .WithName("GetProjects")
            .Produces<List<GetProjectsResponse>>(StatusCodes.Status200OK);
    }
}
