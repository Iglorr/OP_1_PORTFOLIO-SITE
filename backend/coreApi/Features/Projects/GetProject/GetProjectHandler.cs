using CoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Features.Projects.GetProject;

public static class GetProjectHandler
{
    public static async Task<IResult> GetProjectHandle(
        int id, PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .Where(project => project.Id == id)
            .Select(project => new GetProjectResponse(
                project.Id, project.ProjectName, project.ProjectText,
                project.ProjectCategory, project.GitHubUrl, project.Date,
                project.ProjectImage, project.ProjectAltText))
            .AsNoTracking()
            .FirstOrDefaultAsync(cancellationToken);

        return project is null ? TypedResults.NotFound() : TypedResults.Ok(project);
    }
}
