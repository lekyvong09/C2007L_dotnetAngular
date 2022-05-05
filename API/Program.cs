using API.dao;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Helpers;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AnyConnectionName")));

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MyAutoMapper));

/**
 * Declare Service for injection
 */
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

/// Manage error 404
app.UseStatusCodePagesWithReExecute("/errors/{0}");

app.UseHttpsRedirection();

/// config to serve static image content
app.UseStaticFiles();

app.UseAuthorization();

app.MapControllers();

/// Seeding data
AppDbInitializer.Seed(app);

app.Run();
