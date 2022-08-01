FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["Apps/Onboarding.Worker/Onboarding.Worker.csproj", "Apps/Onboarding.Worker/"]
COPY ["Common/Onboarding.Infrastructure/Onboarding.Infrastructure.csproj", "Common/Onboarding.Infrastructure/"]
COPY ["Common/Onboarding.Application/Onboarding.Application.csproj", "Common/Onboarding.Application/"]
COPY ["Common/Onboarding.Domain/Onboarding.Domain.csproj", "Common/Onboarding.Domain/"]
RUN dotnet restore "Apps/Onboarding.Worker/Onboarding.Worker.csproj"
COPY . .
WORKDIR "/Apps/Onboarding.Worker"
RUN dotnet build "Onboarding.Worker.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.Worker.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding.Worker.dll"]