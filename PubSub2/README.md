# Two subscribers need different queues
This is similar to [PubSub](../PubSub/README.md), but we have two different subscriber apps (different namespaces) with the same message contract. Result: both subscribers get a message.

I believe that you can do it better, without a `BuildServiceProvider()` call but for now it's what worked for me in this PoC 🤷🏻‍♂️.


## Run:
```
docker start mtrabbit
dotnet run --project .\Publisher\
dotnet run --project .\Subscriber1\
dotnet run --project .\Subscriber2\
```
Open Publisher's swagger https://localhost:7000/swagger and send a message (`POST /Orders`).

*Broker UI on http://localhost:15672/ (guest / guest).*
