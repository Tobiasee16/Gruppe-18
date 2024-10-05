# Use an official .NET runtime image as base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80

# Use a .NET SDK image to build the application
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyMvcApp.csproj", "./"]
RUN dotnet restore "./MyMvcApp.csproj"
COPY . .
RUN dotnet build "MyMvcApp.csproj" -c Release -o /app/build

# Publish the application
FROM build AS publish
RUN dotnet publish "MyMvcApp.csproj" -c Release -o /app/publish

# Use the SDK image again to run with hot reload (for development)
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS final
WORKDIR /app
COPY --from=publish /app/publish .  # Use published output /
EXPOSE 80

# Use dotnet watch for development
ENTRYPOINT ["dotnet", "watch", "run", "--urls", "http://0.0.0.0:80"]


