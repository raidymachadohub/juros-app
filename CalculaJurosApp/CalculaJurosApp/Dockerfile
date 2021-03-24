#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /CalculaJurosApp
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["CalculaJurosApp/CalculaJurosApp/CalculaJurosApp.csproj", "CalculaJurosApp/"]
COPY ["CalculaJurosApp/CalculaJuros.Servico/CalculaJuros.Servico.csproj", "CalculaJuros.Servico/"]
COPY ["CalculaJurosApp/CalculaJuros.Dominio/CalculaJuros.Dominio.csproj", "CalculaJuros.Dominio/"]
RUN dotnet restore "CalculaJurosApp/CalculaJurosApp.csproj"
COPY . .
WORKDIR "/src/CalculaJurosApp/CalculaJurosApp"
RUN dotnet build "CalculaJurosApp.csproj" -c Release -o /CalculaJurosApp/build

FROM build AS publish
RUN dotnet publish "CalculaJurosApp.csproj" -c Release -o /CalculaJurosApp/publish

FROM base AS final
WORKDIR /CalculaJurosApp
EXPOSE 5001
ENV ASPNETCORE_URLS=http://*:5001
COPY --from=publish /CalculaJurosApp/publish .
ENTRYPOINT ["dotnet", "CalculaJurosApp.dll"]