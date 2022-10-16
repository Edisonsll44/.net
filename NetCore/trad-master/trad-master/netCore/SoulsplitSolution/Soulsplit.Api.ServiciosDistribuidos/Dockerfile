#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
# EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["Soulsplit.Api.ServiciosDistribuidos/Soulsplit.Api.ServiciosDistribuidos.csproj", "Soulsplit.Api.ServiciosDistribuidos/"]
COPY ["Soulsplit.Api.Email/Soulsplit.Api.Email.csproj", "Soulsplit.Api.Email/"]
COPY ["Soulsplit.Api.Contratos/Soulsplit.Api.Contratos.csproj", "Soulsplit.Api.Contratos/"]
COPY ["Soulsplit.Api.AccesoDatos.Contratos/Soulsplit.Api.AccesoDatos.Contratos.csproj", "Soulsplit.Api.AccesoDatos.Contratos/"]
COPY ["Soulsplit.Api.Utilitarios/Soulsplit.Api.Utilitarios.csproj", "Soulsplit.Api.Utilitarios/"]
COPY ["Soulsplit.Api.Dominio/Soulsplit.Api.ResolucionDependencia.csproj", "Soulsplit.Api.Dominio/"]
COPY ["Soulpslit.Api.AccesoDatos/Soulsplit.Api.AccesoDatos.csproj", "Soulpslit.Api.AccesoDatos/"]
COPY ["Soulsplit.Api.Aplicaciones/Soulsplit.Api.Aplicaciones.csproj", "Soulsplit.Api.Aplicaciones/"]
COPY ["Soulsplit.Api.Validaciones/Soulsplit.Api.Validaciones.csproj", "Soulsplit.Api.Validaciones/"]
RUN dotnet restore "Soulsplit.Api.ServiciosDistribuidos/Soulsplit.Api.ServiciosDistribuidos.csproj"
COPY . .
WORKDIR "/src/Soulsplit.Api.ServiciosDistribuidos"
RUN dotnet build "Soulsplit.Api.ServiciosDistribuidos.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Soulsplit.Api.ServiciosDistribuidos.csproj" -c Release -o /app/publish
FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Soulsplit.Api.ServiciosDistribuidos.dll"]
