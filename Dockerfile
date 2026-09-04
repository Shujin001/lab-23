# Place this file in the root of WebApp2ByChirag (Q2), next to the .slnx
FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
WORKDIR /src
COPY ["WebApp2ByChirag/WebApp2ByChirag.csproj", "WebApp2ByChirag/"]
RUN dotnet restore "WebApp2ByChirag/WebApp2ByChirag.csproj"
COPY . .
WORKDIR "/src/WebApp2ByChirag"
RUN dotnet build "WebApp2ByChirag.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WebApp2ByChirag.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WebApp2ByChirag.dll"]
