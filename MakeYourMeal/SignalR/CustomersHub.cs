using System.Collections;
using Microsoft.AspNet.SignalR;
using Microsoft.AspNet.SignalR.Hubs;

namespace MakeYourMeal.SignalR
{
	[HubName("customersHub")]
	public class CustomersHub : Hub
	{
		private static readonly Hashtable UsersConIds = new Hashtable();

		public static string GetConnectionId(string tableNumber)
		{
			return UsersConIds[tableNumber] as string;
		}

		public object this[int value]
		{
			get { return UsersConIds[value]; }
		}

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