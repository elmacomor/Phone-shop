using Microsoft.AspNetCore.SignalR;

namespace MobitelShop.Helpers
{
    public class SignalRHub:Hub
    {
        public async Task PosaljiPoruku()
        {
            await Clients.All.SendAsync("Poruka");  
        }



    }
}
