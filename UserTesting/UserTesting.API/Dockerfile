#See https://aka.ms/customizecontainer to learn how to customize your debug container and how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80
EXPOSE 443

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["UserTesting.API/UserTesting.API.csproj", "UserTesting.API/"]
COPY ["UserTesting.DAL/UserTesting.DAL.csproj", "UserTesting.DAL/"]
COPY ["UserTesting.BLL/UserTesting.BLL.csproj", "UserTesting.BLL/"]
RUN dotnet restore "UserTesting.API/UserTesting.API.csproj"
COPY . .
WORKDIR "/src/UserTesting.API"
RUN dotnet build "UserTesting.API.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "UserTesting.API.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "UserTesting.API.dll"]