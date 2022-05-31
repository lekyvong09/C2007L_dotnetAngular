using API.dao;
using API.Data;
using Microsoft.EntityFrameworkCore;
using API.Helpers;
using API.Middleware;
using Microsoft.AspNetCore.Mvc;
using API.Exceptions;
using StackExchange.Redis;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("AnyConnectionName")));
builder.Services.AddSingleton<IConnectionMultiplexer>(c =>
{
    var configuration = ConfigurationOptions.Parse(builder.Configuration.GetConnectionString("Redis"), true);
    return ConnectionMultiplexer.Connect(configuration);
});

builder.Services.AddControllers();
/// for validate input error messages. Config option for controller attribute [ApiController]
builder.Services.Configure<ApiBehaviorOptions>(options =>
{
    options.InvalidModelStateResponseFactory = actionContext =>
    {
        var errors = actionContext.ModelState
            .Where(e => e.Value.Errors.Count > 0)
            .SelectMany(x => x.Value.Errors)
            .Select(x => x.ErrorMessage);

        var response = new ValidateInputErrorResponse(400)
        {
            Errors = errors
        };
        return new BadRequestObjectResult(response);
    };
});

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MyAutoMapper));

/**
 * Configure CORS policy
 */
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyHeader().AllowAnyMethod().WithOrigins("https://localhost:4200");
    });
});

/**
 * Declare Service for injection
 */
builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
builder.Services.AddScoped<IBasketRepository, BasketRepository>();


var app = builder.Build();

app.UseMiddleware<ExceptionMiddleware>();

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

app.UseCors();

app.UseAuthorization();

app.MapControllers();

/// Seeding data
AppDbInitializer.Seed(app);

app.Run();
