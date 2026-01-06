# Use the official .NET SDK image to build the app
FROM mcr.microsoft.com/dotnet/sdk:9.0 AS build
WORKDIR /src

# Copy csproj files and restore dependencies
COPY ["ForgeFolio/ForgeFolio.csproj", "ForgeFolio/"]
COPY ["ForgeFolio.Core/ForgeFolio.Core.csproj", "ForgeFolio.Core/"]
COPY ["ForgeFolio.Infrastructure/ForgeFolio.Infrastructure.csproj", "ForgeFolio.Infrastructure/"]
RUN dotnet restore "ForgeFolio/ForgeFolio.csproj"

# Copy the rest of the files and build the app
COPY . .
WORKDIR "/src/ForgeFolio"
RUN dotnet build "ForgeFolio.csproj" -c Release -o /app/build

# Publish the app
FROM build AS publish
RUN dotnet publish "ForgeFolio.csproj" -c Release -o /app/publish

# Use the official ASP.NET Core runtime image
FROM mcr.microsoft.com/dotnet/aspnet:9.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ForgeFolio.dll"]
