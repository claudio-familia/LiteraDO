#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:6 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:6 AS build
WORKDIR /src
COPY ["LiteraDO/LiteraDO.csproj", "LiteraDO/"]
COPY ["LiteraDO.Common/LiteraDO.Common.csproj", "LiteraDO.Common/"]
COPY ["LiteraDO.DataAccess/LiteraDO.DataAccess.csproj", "LiteraDO.DataAccess/"]
COPY ["LiteraDO.Domain/LiteraDO.Domain.csproj", "LiteraDO.Domain/"]
COPY ["LiteraDO.BusinessLogic/LiteraDO.BusinessLogic.csproj", "LiteraDO.BusinessLogic/"]
RUN dotnet restore "LiteraDO/LiteraDO.csproj"
COPY . .
WORKDIR "/src/LiteraDO"
RUN dotnet build "LiteraDO.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LiteraDO.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

CMD ASPNETCORE_URLS=http://*:$PORT dotnet LiteraDO.dll