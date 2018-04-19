# SignalR CorsClient

This app is designed to target the CorsServer app from a different origin host.

Its hardcoding `new signalR.HubConnection("http://localhost:51111/hubs/chat")` in `Index.cshtml` to demonstrate being able to talk to a signalr server on a different host.