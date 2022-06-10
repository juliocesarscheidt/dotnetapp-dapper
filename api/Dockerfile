# https://github.com/dotnet/dotnet-docker/blob/main/samples/aspnetapp/Dockerfile.ubuntu-x64

FROM mcr.microsoft.com/dotnet/sdk:6.0-focal AS build

WORKDIR /source

# copy csproj and restore as distinct layers
# COPY *.sln .
COPY *.csproj .
RUN dotnet restore -r linux-x64

# copy everything else and build app
COPY . .
RUN dotnet publish -c release -o /app -r linux-x64 --self-contained false --no-restore

# final stage/image
FROM mcr.microsoft.com/dotnet/aspnet:6.0-focal-amd64

WORKDIR /app
COPY --from=build /app /app

EXPOSE 5000
EXPOSE 5001

ENTRYPOINT ["dotnet", "/app/Api.dll"]
