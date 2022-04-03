#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["src/CNAB.Importer.API/CNAB.Importer.API.csproj", "src/CNAB.Importer.API/"]

RUN dotnet restore "src/CNAB.Importer.API/CNAB.Importer.API.csproj"
COPY . .
WORKDIR "/src/src/CNAB.Importer.API"
RUN dotnet build "CNAB.Importer.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "CNAB.Importer.API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CNAB.Importer.API.dll"]