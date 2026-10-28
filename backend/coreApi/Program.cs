using CoreApi.Data;
using CoreApi.Features.Blogposts;
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

if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.Run();
