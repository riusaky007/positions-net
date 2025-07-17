using Microsoft.EntityFrameworkCore;
using PositionsAPI.Data;
using PositionsAPI.Repositories;
using PositionsAPI.Services;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddControllers();

// Add DbContext
builder.Services.AddDbContext<PositionsDbContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
    // For testing/in-memory:
    // options.UseInMemoryDatabase("PositionsDb");
});

// Add repository and service layers
builder.Services.AddScoped<IPositionsRepository, PositionsRepository>();
builder.Services.AddScoped<IPositionsService, PositionsService>();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseAuthorization();
app.MapControllers();

app.Run();