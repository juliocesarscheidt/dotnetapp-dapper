# Dotnet App with Dapper

## Up and Running

```bash

docker-compose up -d mysql
docker-compose logs -f --tail 50 mysql

docker-compose up -d --build dotnetapi
docker-compose logs -f --tail 50 dotnetapi

```

## API

```bash

curl --silent -H "Content-type: application/json" -X GET "http://localhost:5000/api/message?page=0&size=50" | jq

curl --silent -H "Content-type: application/json" -X GET "http://localhost:5000/api/message/1" | jq


curl --silent -X POST "http://localhost:5000/api/message" -H "Content-type: application/json" --data-raw "{\"user_id\": 1, \"content\": \"Hello World\"}" | jq

curl --silent -X PUT "http://localhost:5000/api/message/1" -H "Content-type: application/json" --data-raw "{\"user_id\": 2, \"content\": \"Hello World 2\"}" | jq

curl --silent -H "Content-type: application/json" -X DELETE "http://localhost:5000/api/message/1" | jq

```
