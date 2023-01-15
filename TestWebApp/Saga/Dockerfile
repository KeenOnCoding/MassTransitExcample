FROM mcr.microsoft.com/dotnet/runtime:7.0 AS base
WORKDIR /app

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["Saga/Saga.csproj", "Saga/"]
COPY ["Contracts/Contracts.csproj", "Contracts/"]
RUN dotnet restore "Saga/Saga.csproj"
COPY . .
WORKDIR "/src/Saga"
RUN dotnet build "Saga.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Saga.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Saga.dll"]