FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["WeatherSystem/WeatherSystem.csproj", "WeatherSystem/"]
RUN dotnet restore "WeatherSystem/WeatherSystem.csproj"
COPY . .
WORKDIR "/src/WeatherSystem"
RUN dotnet build "WeatherSystem.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "WeatherSystem.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "WeatherSystem.dll"]
