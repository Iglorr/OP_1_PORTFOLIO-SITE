using CoreApi.Data;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Features.Projects.DeleteProject;

public static class DeleteProjectHandler
{
    public static async Task<IResult> DeleteProjectHandle(
        int id, PortfolioDBContext dbContext, CancellationToken cancellationToken)
    {
        var project = await dbContext.Projects
            .FirstOrDefaultAsync(project => project.Id == id, cancellationToken);

        if (project is null)
        {
            return TypedResults.NotFound();
        }

        dbContext.Projects.Remove(project);
        await dbContext.SaveChangesAsync(cancellationToken);

        return TypedResults.NoContent();
    }
}
