#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/core/aspnet:3.1-buster-slim AS base
WORKDIR /RetornaJurosApp
EXPOSE 80

FROM mcr.microsoft.com/dotnet/core/sdk:3.1-buster AS build
WORKDIR /src
COPY ["RetornaJurosApp/RetornaJurosApp/RetornaJurosApp.csproj", "RetornaJurosApp/"]
COPY ["RetornaJurosApp/RetornaJuros.Service/RetornaJuros.Servico.csproj", "RetornaJuros.Service/"]
COPY ["RetornaJurosApp/RetornaJuros.Domain/RetornaJuros.Dominio.csproj", "RetornaJuros.Domain/"]
RUN dotnet restore "RetornaJurosApp/RetornaJurosApp.csproj"
COPY . .
WORKDIR "/src/RetornaJurosApp/RetornaJurosApp"
RUN dotnet build "RetornaJurosApp.csproj" -c Release -o /RetornaJurosApp/build

FROM build AS publish
RUN dotnet publish "RetornaJurosApp.csproj" -c Release -o /RetornaJurosApp/publish

FROM base AS final
WORKDIR /RetornaJurosApp
EXPOSE 5000
ENV ASPNETCORE_URLS=http://*:5000
COPY --from=publish /RetornaJurosApp/publish .
ENTRYPOINT ["dotnet", "RetornaJurosApp.dll"]