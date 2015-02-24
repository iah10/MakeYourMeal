using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{

	public partial class FoodItem
	{
		public FoodItem()
		{
			FoodItemHasIngredients = new HashSet<FoodItemHasIngredient>();
			OrderItems = new HashSet<OrderItem>();
		}

		[Key]
		public string Name { get; set; }

		[Required]
		public string CategoryName { get; set; }

		[Required]
		[Column(TypeName = "smallmoney")]
		public decimal? Price { get; set; }

		[Required]
		public string ImagePath { get; set; }

		public virtual Category Category { get; set; }

		public virtual ICollection<FoodItemHasIngredient> FoodItemHasIngredients { get; set; }

		public virtual ICollection<OrderItem> OrderItems { get; set; }
	}
}