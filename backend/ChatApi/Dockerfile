# build image
FROM mcr.microsoft.com/dotnet/sdk:8.0 AS build
WORKDIR /source

COPY . .

RUN dotnet restore
RUN dotnet publish -c Release -o out

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:8.0
WORKDIR /app

COPY --from=build /source/out .

# non root user
USER $APP_UID

EXPOSE 8080

ENTRYPOINT ["dotnet", "ChatApi.dll"]
