using System;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;
using SignalRChattingApp.Models;

namespace SignalRChattingApp.Hubs
{
    public class ChatHub : Hub
    {

        public override async Task OnConnectedAsync()
        {
            var us = SignalRUserHandler.Users;

            if (!string.IsNullOrEmpty(Context.User.Identity.Name))
            {
                var user = new SignalRUser()
                {
                    Id = Context.ConnectionId,
                    UserName = Context.User.Identity.Name
                };

                SignalRUserHandler.Users.Add(user);
            }
            await base.OnConnectedAsync();
        }

        public override async Task OnDisconnectedAsync(Exception exception)
        {

            if (!string.IsNullOrEmpty(Context.User.Identity.Name))
            {
                var id = Context.ConnectionId;
                var user = SignalRUserHandler.Users.SingleOrDefault(c => c.Id == id);
                if (user != null)
                    SignalRUserHandler.Users.Remove(user);
            }
            await base.OnDisconnectedAsync(exception);
        }


        public async Task SendMessage(string user, string message)
        {
            await Clients.All.SendAsync("ReceiveMessage", user, message);
        }
    }
}