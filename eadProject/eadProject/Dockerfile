#See https://aka.ms/containerfastmode to understand how Visual Studio uses this Dockerfile to build your images for faster debugging.



## syntax=docker/dockerfile:1
#FROM mcr.microsoft.com/dotnet/sdk:7.0 AS build-env
#WORKDIR /app
## Copy csproj and restore as distinct layers
#COPY *.csproj ./
#RUN dotnet restore
## Copy everything else and build
#COPY ./ ./
#RUN dotnet publish -c Release -o out
## Build runtime image
#FROM mcr.microsoft.com/dotnet/aspnet:7.0
#WORKDIR /app
#COPY --from=build-env /app/out .
#ENTRYPOINT ["dotnet", "my-awesome-container-app.dll"]
#







FROM mcr.microsoft.com/dotnet/aspnet:6.0 AS base
WORKDIR /app
EXPOSE 80

FROM mcr.microsoft.com/dotnet/sdk:6.0 AS build
WORKDIR /src
COPY ["eadProject/eadProject.csproj", "eadProject/"]
RUN dotnet restore "eadProject/eadProject.csproj"
COPY . .
WORKDIR "/src/eadProject"
RUN dotnet build "eadProject.csproj" -c Release -o /app/build

FROM build AS publish
RUN dotnet publish "eadProject.csproj" -c Release -o /app/publish /p:UseAppHost=false

FROM base AS final
WORKDIR /app
COPY --from=publish /app/publish .
ENTRYPOINT ["dotnet", "eadProject.dll"]