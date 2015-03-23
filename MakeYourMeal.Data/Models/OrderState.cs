using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeYourMeal.Data.Models
{
	public partial class OrderState
	{
		public const string READY_STATE = "Ready";
		public const string CLOSED_STATE = "Closed";
		public const string COMITED_STATE = "Commited";
		public const string NEW_ORDER = "New";

		public OrderState()
		{
			Orders = new HashSet<Order>();
		}

		[Key]
		public string State { get; set; }

		public virtual ICollection<Order> Orders { get; set; }
	}
}
