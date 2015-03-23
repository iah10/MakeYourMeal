using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration.Conventions;

namespace MakeYourMeal.Data.Models
{
	public partial class OrderItem
	{
		public OrderItem()
		{
			ExtraIngredients = new HashSet<Ingredient>();
			WithoutIngredients = new HashSet<Ingredient>();
		}

		[Key]
		public int OrderItemId { get; set; }

		[Required]
		[ForeignKey("FoodItem")]
		public string FoodItemName { get; set; }

		[Required]
		[ForeignKey("Order")]
		public int OrderId { get; set; }

		public virtual FoodItem FoodItem { get; set; }

		public virtual ICollection<Ingredient> ExtraIngredients { get; set; }

		public virtual Order Order { get; set; }

		public virtual ICollection<Ingredient> WithoutIngredients { get; set; }
	}
}
