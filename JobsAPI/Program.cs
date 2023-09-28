using JobsAPI.Persistence;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

var connectionsString = builder.Configuration.GetConnectionString("sqlserver-local");
builder.Services.AddDbContext<JobsDbContext>(options =>
{
    //options.UseInMemoryDatabase("JobsDb");
    options.UseSqlServer(connectionsString);
});

builder.Services.AddControllers();

builder.Services.AddHealthChecks();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.MapControllers();

app.UseHealthChecks("/status");

app.Run();