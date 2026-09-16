FROM mcr.microsoft.com/dotnet/aspnet:10.0 AS base
USER $APP_UID
WORKDIR /app
EXPOSE 8888

FROM mcr.microsoft.com/dotnet/sdk:10.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src

COPY ["ENGIE.UnitCommitment.Web/ENGIE.UnitCommitment.Web.csproj", "ENGIE.UnitCommitment.Web/"]
RUN dotnet restore "ENGIE.UnitCommitment.Web/ENGIE.UnitCommitment.Web.csproj"

COPY . .

WORKDIR "/src/ENGIE.UnitCommitment.Web"
RUN dotnet build "./ENGIE.UnitCommitment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./ENGIE.UnitCommitment.Web.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "ENGIE.UnitCommitment.Web.dll"]
