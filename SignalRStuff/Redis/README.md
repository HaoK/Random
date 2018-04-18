# SignalR + Redis

This sample depends on a redis instance, you can set one up on windows via https://github.com/MicrosoftArchive/redis.

By default this app expects Redis to be setup locally, but you can point redis someplace other than the default localhost port, 
via `AddSignalR().AddRedis(o => o.Options = StackExchange.Redis.ConfigurationOptions.Parse("<connectionString>"))`.

To see the redis messages:
 - run redis-cli monitor
 - Goto /Chat and type some messages and you should see something like:
```
"PUBLISH" "Redis.Hubs.ChatHub" "{\"Target\":\"SendMessage\",\"ExcludedIds\":null,\"Arguments\":[\"Someone\",\"hey\"]}"
```
 - You can copy that message and publish it via redis-cli and see the chat message show up in the browser as well.
