﻿const connection = new signalR.HubConnection(
    "/chathub", { logger: signalR.LogLevel.Information });

connection.on("ReceiveMessage", (user, message) => {
    const encodedMsg = user + " says " + message;
    const li = document.createElement("li");
    li.textContent = encodedMsg;
    document.getElementById("messagesList").appendChild(li);
});

document.getElementById("sendButton").addEventListener("click", event => {
    const user = "Nobody";
    const message = document.getElementById("messageInput").value;
    connection.send("SendMessage", user, message).catch(err => console.error);
    event.preventDefault();
});

connection.start().catch(err => console.error);