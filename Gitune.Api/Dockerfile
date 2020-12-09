#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0-buster-slim AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0-buster-slim AS build
WORKDIR /src
COPY ["Gitune.Api/Gitune.Api.csproj", "Gitune.Api/"]
RUN dotnet restore "Gitune.Api/Gitune.Api.csproj"
COPY . .
WORKDIR "/src/Gitune.Api"
RUN dotnet build "Gitune.Api.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "Gitune.Api.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "Gitune.Api.dll"]