FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 5001

ENV ASPNETCORE_URLS=http://+:5001

USER app
FROM --platform=$BUILDPLATFORM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG configuration=Release
WORKDIR /src
COPY ["CustomerPortalFrontend/CustomerPortalFrontend.csproj", "CustomerPortalFrontend/"]
RUN dotnet restore "CustomerPortalFrontend/CustomerPortalFrontend.csproj"
COPY . .
WORKDIR "/src/CustomerPortalFrontend"
RUN dotnet build "CustomerPortalFrontend.csproj" -c $configuration -o /app/build

FROM build AS publish
ARG configuration=Release
RUN dotnet publish "CustomerPortalFrontend.csproj" -c $configuration -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "CustomerPortalFrontend.dll"]
