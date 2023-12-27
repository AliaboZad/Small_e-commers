using Microsoft.AspNetCore.SignalR;
using TestAPIAhmedElmohamdyCours.Models;

namespace Small_e_commers.Hubs
{
	public class ItemHub : Hub
	{
		public void BroadCoastItem (Items items)
		{
			Clients.All.SendAsync("ReceiveItems ", items);

		}

		// this message will be come from client 
		public void BroadCoastMessage(string message)
		{
			Clients.All.SendAsync("ReceiveMessage", message);
		}

	}
}
