using Microsoft.AspNetCore.SignalR;

namespace SignalRHubsSample.Hubs;

public class ChatHub : Hub
{
    public async Task SendMessage(IAsyncEnumerable<string> data, string text)
    {
        await foreach (var x in data)
        {
            await Clients.Caller.SendAsync("ReceiveMessage", x);
        }
    }


}
