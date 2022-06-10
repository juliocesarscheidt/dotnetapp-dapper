# Dotnet App with Dapper

## Instructions

```bash

## adicionar a chave de assinatura do pacote da Microsoft lista de chaves confiaveis e adicionar o repositorio de pacotes
wget https://packages.microsoft.com/config/ubuntu/21.04/packages-microsoft-prod.deb -O packages-microsoft-prod.deb
sudo dpkg -i packages-microsoft-prod.deb
sudo rm -f packages-microsoft-prod.deb

## instalar dotnet sdk
sudo apt-get update; \
  sudo apt-get install -y apt-transport-https && \
  sudo apt-get update && \
  sudo apt-get install -y dotnet-sdk-6.0

## instalar dotnet runtime
sudo apt-get install -y dotnet-runtime-6.0



dotnet --list-runtimes
dotnet --list-sdks

dotnet new --list

## cria uma API
dotnet new webapi -n Api



## add dapper micro-ORM

> https://dapper-tutorial.net/dapper
> https://www.nuget.org/packages/Dapper

dotnet add package Dapper --version 2.0.123

dotnet add package Dapper.Contrib --version 2.0.78

dotnet add package MySql.Data --version 8.0.29



## editar arquivo <app_name>.csproj
<RuntimeIdentifiers>ubuntu.20.04-x64;win10-x64</RuntimeIdentifiers>



## instalar pacotes
dotnet restore
dotnet restore -r linux-x64


## run in development mode
SET ASPNETCORE_ENVIRONMENT=Development
SET ASPNETCORE_URLS=http://0.0.0.0:5000

export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_URLS=http://0.0.0.0:5000


dotnet run
dotnet run --configuration Debug



## build for prod
dotnet publish --configuration Release -r linux-x64
dotnet publish --configuration release -r linux-x64 --self-contained false --no-restore

dotnet publish --configuration release -r win10-x64



dotnet build --configuration Release -r linux-x64

dotnet build --configuration Release -r win10-x64


export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS=http://0.0.0.0:5000

SET ASPNETCORE_ENVIRONMENT=Production
SET ASPNETCORE_URLS=http://0.0.0.0:5000


## run built app
dotnet <app_assembly>.dll
dotnet bin\Release\net6.0\win10-x64\Api.dll

dotnet bin/release/net6.0/linux-x64/Api.dll

```
