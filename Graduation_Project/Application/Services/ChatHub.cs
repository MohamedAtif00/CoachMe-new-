

using Microsoft.AspNetCore.SignalR;

namespace Graduation_Project.Application.Services
{
    public class ChatHub :Hub
    {
        public override async Task OnConnectedAsync()
        {
            Console.WriteLine("Client connected via WebSocket.");
            await Clients.All.SendAsync("ReceiveMessage", "ChatBot", "Welcome to the chat!");
            await base.OnConnectedAsync();
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }

    }
}
