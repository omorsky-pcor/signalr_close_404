using Microsoft.AspNetCore.SignalR;

namespace SignalRHubsSample.Hubs;

public class ChatHub : Hub
{
    public void SendMessage(string text)
    {
    }


}
