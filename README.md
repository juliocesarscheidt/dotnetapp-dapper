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

curl -X GET "http://localhost:5000/api/message"

curl -X GET "http://localhost:5000/api/message/1"

curl -X GET "http://localhost:5000/api/message/count"

curl -X POST "http://localhost:5000/api/message" -H "Content-type: application/json" --data-raw "{\"user_id\": 1, \"content\": \"Hello World\"}"

curl -X PUT "http://localhost:5000/api/message/1" -H "Content-type: application/json" --data-raw "{\"user_id\": 2, \"content\": \"Hello World 2\"}"

curl -X DELETE "http://localhost:5000/api/message/1"

```
