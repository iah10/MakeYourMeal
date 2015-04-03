using System.Collections;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MakeYourMeal.SignalR
{
	[HubName("adminHub")]
	public class AdminHub : Hub
	{
		private static readonly Hashtable UsersConIds = new Hashtable();

		public void RegisterConId(string tableNum)
		{
			bool alreadyExists = false;
			if (UsersConIds.Count == 0)
			{
				UsersConIds.Add(tableNum, Context.ConnectionId);
			}
			else
			{
				foreach (string key in UsersConIds.Keys)
				{
					if (key == tableNum)
					{
						UsersConIds[key] = Context.ConnectionId;
						alreadyExists = true;
						break;
					}
				}
				if (!alreadyExists)
				{
					UsersConIds.Add(tableNum, Context.ConnectionId);
				}
			}
		}
	}
}