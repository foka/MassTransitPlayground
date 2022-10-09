# PoC for point-to-point over pub-sub to scaled Subscriber 
In this example I publish a message once, run two instances of a subscriber app (with the same consumer/queue config). Result: only one subscriber instance gets/consumes a message (as expected).

## Run:
```
docker run -p 15672:15672 -p 5672:5672 --name mtrabbit masstransit/rabbitmq
dotnet run --project .\Publisher\
dotnet run --project .\Subscriber\
dotnet run --project .\Subscriber\ --urls=https://localhost:8002/
```
Open Publisher's swagger https://localhost:7000/swagger and send a message (`POST /Orders`).

*Broker UI on http://localhost:15672/ (guest / guest).*

## TIL
* Consumer needs `ConsumerDefinition`.
* Publisher/Subscriber contract/message must have equal full-name (namespace!).
