using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Microsoft.AspNet.SignalR;

namespace MessagingServer.Models
{
    public class MessagingHub : Hub
    {
        public void Send(string email, string dateTime, string message)
        {
            Clients.All.Recive(email, dateTime, message);
        }
    }
}