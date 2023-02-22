#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.

FROM mcr.microsoft.com/dotnet/aspnet:7.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build
WORKDIR /src
COPY ["LoginApi/LoginApi.csproj", "LoginApi/"]
RUN dotnet restore "LoginApi/LoginApi.csproj"
COPY . .
WORKDIR "/src/LoginApi"
RUN dotnet build "LoginApi.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "LoginApi.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "LoginApi.dll"]

#FROM mcr.microsoft.com/dotnet/sdk:7.0 as build-env
#WORKDIR /src
#COPY . .
#RUN dotnet restore
#RUN dotnet publish -c Release -o /publish
#
#FROM mcr.microsoft.com/dotnet/aspnet:7.0 as runtime
#WORKDIR /publish
#COPY --from=build-env /publish .
#EXPOSE 80
#ENTRYPOINT ["dotnet", "LoginApi.dll"]