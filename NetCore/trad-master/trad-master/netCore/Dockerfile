# https://hub.docker.com/_/microsoft-dotnet
FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY SoulsplitSolution/ .
RUN dotnet restore

WORKDIR "/src/Soulsplit.Api.ServiciosDistribuidos"
RUN dotnet build "Soulsplit.Api.ServiciosDistribuidos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Soulsplit.Api.ServiciosDistribuidos.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soulsplit.Api.ServiciosDistribuidos.dll"]
