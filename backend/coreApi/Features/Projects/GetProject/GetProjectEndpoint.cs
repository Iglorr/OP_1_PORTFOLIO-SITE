namespace CoreApi.Features.Projects.GetProject;

public static class GetProjectEndpoint
{
    public static RouteHandlerBuilder MapGetProjectEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapGet("/{id:int}", GetProjectHandler.GetProjectHandle)
            .WithName("GetProject")
            .Produces<GetProjectResponse>(StatusCodes.Status200OK)
            .Produces(StatusCodes.Status404NotFound);
    }
}
