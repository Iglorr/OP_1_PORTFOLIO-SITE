using CoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Features.Projects.GetProjects;

public static class GetProjectsHandler
{
    public static async Task<IResult> GetProjectsHandle(
        PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var projects = await dbContext.Projects
            .Select(project => new GetProjectsResponse(
                project.Id, project.ProjectName, project.ProjectText,
                project.ProjectCategory, project.GitHubUrl, project.Date,
                project.ProjectImage, project.ProjectAltText))
            .AsNoTracking()
            .ToListAsync(cancellationToken);

        return TypedResults.Ok(projects);
    }
}
