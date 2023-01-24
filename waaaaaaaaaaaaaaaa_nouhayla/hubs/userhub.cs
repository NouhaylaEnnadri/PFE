using Microsoft.AspNetCore.SignalR;

namespace waaaaaaaaaaaaaaaa_nouhayla.hubs
{
    public class userhub : Hub
    {
        public static int TotalViews { get; set;  } = 0 ;
        public static int TotalUsers { get; set; } = 0;

        //creating a methode that will be invoked every time a page loads or reloads : 

        public override Task OnConnectedAsync()
        {
            TotalUsers++;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnConnectedAsync();
        }

        public override Task OnDisconnectedAsync(Exception? exception)
        {
            TotalUsers--;
            Clients.All.SendAsync("updateTotalUsers", TotalUsers).GetAwaiter().GetResult();
            return base.OnDisconnectedAsync(exception);
        }
        public async Task <String> NewWindowLoaded()
        {
        TotalViews++;
        await Clients.All.SendAsync("update" , TotalViews); //update ill be in the client side of the application
            return $"Total views is {TotalViews}";
        }


    }
}
