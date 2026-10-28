using CoreApi.Data;
using CoreApi.Features.Blogposts;
using CoreApi.Features.Projects;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PortfolioDBContext>(options =>
    options.UseSqlServer(
        builder.Configuration.GetConnectionString("PortfolioDB")));

builder.Services.AddOpenApi();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddValidation();

var app = builder.Build();

app.MapAllBlogpostsEndpoints();
app.MapAllProjectsEndpoints();

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
