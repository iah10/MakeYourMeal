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
		}

		[Key]
		public int OrderId { get; set; }

		[Required]
		[MaxLength(8)]
		[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
		public byte[] OrderedAt { get; set; }

		public int TableNumber { get; set; }

		public decimal TotalCost { get; set; }

		public int State { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; }
	}
}
