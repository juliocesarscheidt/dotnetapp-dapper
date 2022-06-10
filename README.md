# Dotnet App with Dapper


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
<RuntimeIdentifiers>ubuntu.18.04-x64;win10-x64</RuntimeIdentifiers>



## instalar pacotes
dotnet restore



## run in development mode
SET ASPNETCORE_ENVIRONMENT=Development
SET ASPNETCORE_URLS=http://0.0.0.0:5000

export ASPNETCORE_ENVIRONMENT=Development
export ASPNETCORE_URLS=http://0.0.0.0:5000


dotnet run
dotnet run --configuration Debug



curl -X GET http://localhost:5000/api/message

curl -X GET http://localhost:5000/api/message/1

curl -X GET http://localhost:5000/api/message/count

curl -X POST http://localhost:5000/api/message -H "Content-type: application/json" --data-raw "{\"user_id\": 1, \"content\": \"Hello World\"}"

curl -X PUT http://localhost:5000/api/message/1 -H "Content-type: application/json" --data-raw "{\"user_id\": 2, \"content\": \"Hello World 2\"}"

curl -X DELETE http://localhost:5000/api/message/1



## build for prod
dotnet publish --configuration Release -r linux-x64

dotnet publish --configuration release -r win10-x64


dotnet build --configuration Release -r linux-x64

dotnet build --configuration Release -r win10-x64


export ASPNETCORE_ENVIRONMENT=Production
export ASPNETCORE_URLS=http://0.0.0.0:5000

SET ASPNETCORE_ENVIRONMENT=Production
SET ASPNETCORE_URLS=http://0.0.0.0:5000


## run built app
dotnet <app_assembly>.dll
dotnet bin/Release\netcoreapp2.1\win10-x64\Api.dll

dotnet bin\release\netcoreapp2.1\win10-x64\App.dll



