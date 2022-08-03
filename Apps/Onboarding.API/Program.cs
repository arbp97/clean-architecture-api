using Onboarding.API.Presenters;
using Onboarding.API.Presenters.Handlers;
using Onboarding.API.Filters;
using Onboarding.Infrastructure;
using Onboarding.Application;
using FluentValidation;
using Microsoft.Data.SqlClient;

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

builder.Services.AddScoped<IPresenter, Presenter>();

builder.Services.AddApplicationServices();
builder.Services.AddInfrastructureServices(builder.Configuration);

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
