namespace CoreApi.Features.Projects.UpdateProject;

public static class UpdateProjectEndpoint
{
    public static RouteHandlerBuilder MapUpdateProjectEndpoint(this RouteGroupBuilder routeGroupBuilder)
    {
        return routeGroupBuilder
            .MapPut("/{id:int}", UpdateProjectHandler.UpdateProjectHandle)
            .WithName("UpdateProject")
            .Produces(StatusCodes.Status204NoContent)
            .Produces(StatusCodes.Status404NotFound)
            .ProducesValidationProblem();
    }
}
