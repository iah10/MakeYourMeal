using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{
	public partial class OrderItem
	{
		public OrderItem()
		{
			Ingredients = new HashSet<Ingredient>();
			Orders = new HashSet<Order>();
			Ingredients1 = new HashSet<Ingredient>();
		}

		[DatabaseGenerated(DatabaseGeneratedOption.None)]
		public int OrderItemId { get; set; }

		[Required]
		public string FoodItemName { get; set; }

		public virtual FoodItem FoodItem { get; set; }

		public virtual ICollection<Ingredient> Ingredients { get; set; }

		public virtual ICollection<Order> Orders { get; set; }

		public virtual ICollection<Ingredient> Ingredients1 { get; set; }
	}
}
