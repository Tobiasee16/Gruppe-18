# Bruk et offisielt .NET runtime image som base
FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 80
# Bruk et .NET SDK image til å bygge applikasjonen
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY ["MyMvcApp.csproj", "./"]
RUN dotnet restore "./MyMvcApp.csproj"
COPY . .
WORKDIR "/src"
RUN dotnet build "MyMvcApp.csproj" -c Release -o /app/build
# Publiser applikasjonen
FROM build AS publish
RUN dotnet publish "MyMvcApp.csproj" -c Release -o /app/publish
# Bruk runtime-bildet til å kjøre applikasjonen
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "MyMvcApp.dll"]


