using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.SignalR;

namespace CollabTextEditor
{
    public class TextHub : Hub
    {
        private static Dictionary<string, string> connectionsNgroup = new Dictionary<string, string>();

       
        public async Task BroadcastText(string text)
        {
            
            
                await Clients.All.SendAsync("ReceiveText", text);
            
        }

      
    }
}