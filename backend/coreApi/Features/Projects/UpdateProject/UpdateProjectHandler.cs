using CoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Features.Projects.UpdateProject;

public static class UpdateProjectHandler
{
    public static async Task<IResult> UpdateProjectHandle(
        int id, UpdateProjectRequest request,
        PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .FirstOrDefaultAsync(project => project.Id == id, cancellationToken);

        if (project is null)
        {
            return TypedResults.NotFound();
        }

        project.ProjectName = request.Name;
        project.ProjectText = request.Description;
        project.ProjectCategory = request.Category;
        project.GitHubUrl = request.GitHubUrl;
        project.ProjectImage = request.Image;
        project.ProjectAltText = request.AltText;

        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}
