using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using HatChat.Models;
using Microsoft.AspNetCore.SignalR;

namespace HatChat.Hubs
{
    public class ChatHub:Hub
    {
        public void SendMessage(ChatMessage message)
        {
            Clients.All.SendAsync("ReceivedMessage", message);
        }

        public void SignInUser(string username)
        {
            Clients.All.SendAsync("UserSignedIn", username);
        }
    }
}
