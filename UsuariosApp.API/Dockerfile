#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UsuariosApp.API/UsuariosApp.API.csproj", "UsuariosApp.API/"]
COPY ["UsuariosApp.Application/UsuariosApp.Application.csproj", "UsuariosApp.Application/"]
COPY ["UsuariosApp.Domain/UsuariosApp.Domain.csproj", "UsuariosApp.Domain/"]
COPY ["UsuariosApp.Infra.Data/UsuariosApp.Infra.Data.csproj", "UsuariosApp.Infra.Data/"]
RUN dotnet restore "UsuariosApp.API/UsuariosApp.API.csproj"
COPY . .
WORKDIR "/src/UsuariosApp.API"
RUN dotnet build "UsuariosApp.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UsuariosApp.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UsuariosApp.API.dll"]