#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:5.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:5.0 AS build
WORKDIR /src
COPY ["DCSS_8536_API/DCSS_8536_API.csproj", "DCSS_8536_API/"]
RUN dotnet restore "DCSS_8536_API/DCSS_8536_API.csproj"
COPY . .
WORKDIR "/src/DCSS_8536_API"
RUN dotnet build "DCSS_8536_API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "DCSS_8536_API.csproj" -c Release -o /app/publish

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "DCSS_8536_API.dll"]