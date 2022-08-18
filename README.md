# Getting Started

## Project Structure

This solution was developed following the Clean Architecture software design directives.
[Clean Architecture](https://blog.cleancoder.com/uncle-bob/2012/08/13/the-clean-architecture.html)

├───Apps # Startup Projects  
│ ├───Onboarding.API  
│ │ ├───Controllers  
│ │ ├───Filters  
│ │ ├───Presenters  
│ └───Onboarding.Worker  
├───Common # Resource Projects  
│ ├───Onboarding.Application  
│ │ └───Requests  
│ ├───Onboarding.Domain  
│ │ ├───Entities  
│ │ ├───Enums  
│ │ ├───Exceptions   
│ └───Onboarding.Infrastructure  
│ ├───Migrations  
│ ├───Persistence  
│ └───Repository  
└───Tests # Unit Tests

## Dependencies

- Docker Desktop
- .NET Core CLI
- .NET Core EF Tool

## Build and Run

1. In project root run <code>dotnet restore Onboarding.sln</code>.

2. Set an env variable named OnboardingDB with this string:
   > Data Source=db,1433;Initial Catalog=OnboardingDB;Persist Security Info=true;TrustServerCertificate=true;User Id=sa;Password=Admin#1234;

3. In project root run docker <code>docker compose up -d</code> to build the containers.

4. Navigate to Common/Onboarding.Infrastructure and run: <br>
   <code>dotnet ef database update --startup-project ../../Apps/Onboarding.API/Onboarding.API.csproj</code>.

5. Open your browser and go to localhost:8080/, you should see the API Swagger Docs.
