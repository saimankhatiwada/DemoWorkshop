FROM mcr.microsoft.com/dotnet/aspnet:8.0 AS base
USER app
WORKDIR /app
EXPOSE 5000

FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
ARG BUILD_CONFIGURATION=Release
WORKDIR /src
COPY ["src/Todo.Api/Todo.Api.csproj", "src/Todo.Api/"]
COPY ["src/Todo.Data/Todo.Data.csproj", "src/Todo.Data/"]
RUN dotnet restore "./src/Todo.Api/./Todo.Api.csproj"
COPY . .
WORKDIR "/src/src/Todo.Api"
RUN dotnet build "./Todo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/build

FROM build AS publish
ARG BUILD_CONFIGURATION=Release
RUN dotnet publish "./Todo.Api.csproj" -c $BUILD_CONFIGURATION -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Todo.Api.dll"]