#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["AuctionSniper/AuctionSniper.WebApi/AuctionSniper.WebApi.csproj", "AuctionSniper/AuctionSniper.WebApi/"]
COPY ["AuctionSniper/AuctionSniper.Infrastructure.Persistence/AuctionSniper.Infrastructure.Persistence.csproj", "AuctionSniper/AuctionSniper.Infrastructure.Persistence/"]
COPY ["AuctionSniper/AuctionSniper.Application/AuctionSniper.Application.csproj", "AuctionSniper/AuctionSniper.Application/"]
COPY ["AuctionSniper/AuctionSniper.Domain/AuctionSniper.Domain.csproj", "AuctionSniper/AuctionSniper.Domain/"]
COPY ["AuctionSniper/AuctionSniper.Infrastructure.Shared/AuctionSniper.Infrastructure.Shared.csproj", "AuctionSniper/AuctionSniper.Infrastructure.Shared/"]
RUN dotnet restore "AuctionSniper/AuctionSniper.WebApi/AuctionSniper.WebApi.csproj"
COPY . .
WORKDIR "/src/AuctionSniper/AuctionSniper.WebApi"
RUN dotnet build "AuctionSniper.WebApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "AuctionSniper.WebApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "AuctionSniper.WebApi.dll"]