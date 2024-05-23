namespace SignalRTest;

using Microsoft.AspNetCore.SignalR;

public class MessageHub : Hub<IMessage>
{
    public async Task SendMessage(string message)
    {
        await Clients.All.SendMessage(message);
    }
}