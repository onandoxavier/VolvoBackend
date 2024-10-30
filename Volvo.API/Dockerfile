FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
WORKDIR /app
EXPOSE 8080

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /src
COPY Volvo.API/Volvo.API.csproj Volvo.API/
RUN dotnet restore "Volvo.API/Volvo.API.csproj"
COPY . .
WORKDIR "/src/Volvo.API"
RUN dotnet build "Volvo.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Volvo.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Volvo.API.dll"]
