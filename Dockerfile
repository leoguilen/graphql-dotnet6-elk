FROM mcr.microsoft.com/dotnet/aspnet:6.0-alpine AS base
WORKDIR /app

RUN adduser -u 5678 --disabled-password --gecos "" appuser && chown -R appuser /app
USER appuser

FROM mcr.microsoft.com/dotnet/sdk:6.0-alpine AS build
WORKDIR /src
COPY ["../src/Transactions.Query.Api/Transactions.Query.Api.csproj", "src/Transactions.Query.Api/"]
COPY ["../src/Transactions.Query.Core/Transactions.Query.Core.csproj", "src/Transactions.Query.Core/"]
COPY ["../src/Transactions.Query.Infrastructure.Data/Transactions.Query.Infrastructure.Data.csproj", "src/Transactions.Query.Infrastructure.Data/"]
RUN dotnet restore "src/Transactions.Query.Api/Transactions.Query.Api.csproj"
COPY . .
WORKDIR "/src/src/Transactions.Query.Api"
RUN dotnet build "Transactions.Query.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Transactions.Query.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .

EXPOSE 80
EXPOSE 443

# # Performance monitoring tool
# ENV PATH="$PATH:/root/.dotnet/tools"
# RUN dotnet tool install --global dotnet-counters

ENTRYPOINT ["dotnet", "Transactions.Query.Api.dll"]