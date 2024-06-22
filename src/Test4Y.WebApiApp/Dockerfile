# syntax=docker/dockerfile:1

# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    --mount=type=bind,source=src/Test4Y.Core/Test4Y.Core.csproj,target=Test4Y.Core/Test4Y.Core.csproj \
    --mount=type=bind,source=src/Test4Y.Infrastructure/Test4Y.Infrastructure.csproj,target=Test4Y.Infrastructure/Test4Y.Infrastructure.csproj \
    --mount=type=bind,source=src/Test4Y.WebApiApp/Test4Y.WebApiApp.csproj,target=Test4Y.WebApiApp/Test4Y.WebApiApp.csproj \
    dotnet restore ./Test4Y.WebApiApp/Test4Y.WebApiApp.csproj
COPY src .
WORKDIR /src/Test4Y.WebApiApp
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet build -c $BUILD_CONFIGURATION -o /app/build --no-restore

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c $BUILD_CONFIGURATION -o /app/publish --no-restore /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Test4Y.WebApiApp.dll"]
