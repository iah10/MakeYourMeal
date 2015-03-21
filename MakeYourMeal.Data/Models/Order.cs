using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{
	public partial class Order
	{
		public Order()
		{
			OrderItems = new HashSet<OrderItem>();
			OrderedAt = DateTime.Now;
		}

		[Key]
		public int OrderId { get; set; }

		
		public DateTime OrderedAt { get; set; }

		public int TableNumber { get; set; }

		public decimal TotalCost { get; set; }

		public int State { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; }
	}
}
