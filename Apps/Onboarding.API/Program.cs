using Onboarding.API.Presenters;
using Onboarding.API.Presenters.Handlers;
using Onboarding.API.Filters;
using Onboarding.Infrastructure;
using Onboarding.Application;
using FluentValidation;
using Microsoft.Data.SqlClient;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers(
    options =>
        options.Filters.Add(
            new ApiExceptionFilterAttribute(
                new Dictionary<Type, IExceptionHandler>
                {
                    { typeof(ValidationException), new ValidationExceptionHandler() },
                    { typeof(SqlException), new SqlExceptionHandler() }
                }
            )
        )
);

builder.Services.AddTransient<IPresenter, Presenter>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.SwaggerDoc(
        "v1",
        new OpenApiInfo
        {
            Version = "v1",
            Title = "Andreani Onboarding API",
            Description = "An ASP.NET Core Web API using Clean Architecture.",
            Contact = new OpenApiContact
            {
                Name = "Alan Blangille",
                Url = new Uri("https://arbp97.github.io"),
                Email = "ablanguille@andreani.com"
            }
        }
    );
});

var app = builder.Build();

// Add Swagger Documentation
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "andreani-onboarding-api");
        options.RoutePrefix = string.Empty;
    });
}

// Configure the HTTP request pipeline.

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
