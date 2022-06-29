#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:3.1 AS base
WORKDIR /app

ENV ASPNETCORE_ENVIRONMENT=Development
EXPOSE $PORT

FROM mcr.microsoft.com/dotnet/sdk:3.1 AS build
WORKDIR /src
COPY ["parafarmacia/app.db", "parafarmacia/"]
COPY ["parafarmacia/parafarmacia.csproj", "parafarmacia/"]
RUN dotnet restore "parafarmacia/parafarmacia.csproj"
COPY . .
WORKDIR "/src/parafarmacia"
RUN dotnet build "parafarmacia.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "parafarmacia.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=build /src/parafarmacia/app.db .
COPY --from=publish /app/publish .
CMD ASPNETCORE_URLS=http://*:$PORT dotnet parafarmacia.dll
