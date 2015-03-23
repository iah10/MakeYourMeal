using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{
	public partial class Ingredient
	{
		public Ingredient()
		{
			FoodItemHasIngredients = new HashSet<FoodItemHasIngredient>();
			ExtraOrderItems = new HashSet<OrderItem>();
			WithoutOrderItems = new HashSet<OrderItem>();
		}

		[Key]
		public string Name { get; set; }

		public string ImagePath { get; set; }

		public decimal AdditionalCharge { get; set; }

		public virtual ICollection<FoodItemHasIngredient> FoodItemHasIngredients { get; set; }

		public virtual ICollection<OrderItem> ExtraOrderItems { get; set; }

		public virtual ICollection<OrderItem> WithoutOrderItems { get; set; }
	}
}
