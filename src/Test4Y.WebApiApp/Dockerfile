# syntax=docker/dockerfile:1

# See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY . .
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet restore /ignoreprojectextensions:.dcproj

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
WORKDIR /src/src/Test4Y.WebApiApp
RUN --mount=type=cache,id=nuget,target=/root/.nuget/packages \
    dotnet publish -c $BUILD_CONFIGURATION -o /app --no-restore /p:UseAppHost=false

FROM build AS test
ARG BUILD_CONFIGURATION=Release
ENV BUILD_CONFIGURATION=$BUILD_CONFIGURATION
WORKDIR /src/tests/Test4Y.WebApiApp.UnitTests
ENTRYPOINT ["sh", "-c", "dotnet test -c $BUILD_CONFIGURATION -l trx"]

FROM base AS final
WORKDIR /app
COPY --from=publish /app .
ENTRYPOINT ["dotnet", "Test4Y.WebApiApp.dll"]
