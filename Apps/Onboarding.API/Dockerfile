FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
#ENV ASPNETCORE_URLS=https://+:5006;http://+:5005
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
COPY ["Apps/Onboarding.API/Onboarding.API.csproj", "Apps/Onboarding.API/"]
COPY ["Common/Onboarding.Infrastructure/Onboarding.Infrastructure.csproj", "Common/Onboarding.Infrastructure/"]
COPY ["Common/Onboarding.Application/Onboarding.Application.csproj", "Common/Onboarding.Application/"]
COPY ["Common/Onboarding.Domain/Onboarding.Domain.csproj", "Common/Onboarding.Domain/"]
RUN dotnet restore "Apps/Onboarding.API/Onboarding.API.csproj"
COPY . .
WORKDIR "/Apps/Onboarding.API"
RUN dotnet build "Onboarding.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Onboarding.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Onboarding.API.dll"]