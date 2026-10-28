using CoreApi.Features.Projects.GetProjects;
using CoreApi.Features.Projects.GetProject;
using CoreApi.Features.Projects.CreateProject;
using CoreApi.Features.Projects.UpdateProject;
using CoreApi.Features.Projects.DeleteProject;

namespace CoreApi.Features.Projects;

public static class ProjectsEndpoints
{
    public static RouteGroupBuilder MapAllProjectsEndpoints(this IEndpointRouteBuilder endpoints)
    {
        RouteGroupBuilder group = endpoints.MapGroup("/api/projects").WithTags("Projects");

        group.MapGetProjectsEndpoint();
        group.MapGetProjectEndpoint();
        group.MapCreateProjectEndpoint();
        group.MapUpdateProjectEndpoint();
        group.MapDeleteProjectEndpoint();

        return group;
    }
}
