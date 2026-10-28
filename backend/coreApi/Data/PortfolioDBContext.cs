using CoreApi.Domain;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Data;

public class PortfolioDBContext : DbContext
{
    public PortfolioDBContext(DbContextOptions<PortfolioDBContext> options) : base(options)
    {
    }

    public DbSet<Blogpost> Blogposts { get; set; }
    public DbSet<Project> Projects { get; set; }
}
