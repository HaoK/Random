# SignalR CorsServer

This app is designed to allow different origin hosts to chat, see CorsClient.

This is done by configuring Cors in Startup.cs:
```
   // See ConfigureServices:
   services.AddCors(o => o.AddPolicy("All", b => b.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod().AllowCredentials())); 

   // See Configure:
   app.UseCors("All");
```