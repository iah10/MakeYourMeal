using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{
	public partial class OrderItem
	{
		public OrderItem()
		{
			ExtraIngredients = new HashSet<Ingredient>();
			Orders = new HashSet<Order>();
			WithoutIngredients = new HashSet<Ingredient>();
		}

		[Key]
		public int OrderItemId { get; set; }

		[Required]
		public string FoodItemName { get; set; }

		public virtual FoodItem FoodItem { get; set; }

		public virtual ICollection<Ingredient> ExtraIngredients { get; set; }

		public virtual ICollection<Order> Orders { get; set; }

		public virtual ICollection<Ingredient> WithoutIngredients { get; set; }
	}
}
