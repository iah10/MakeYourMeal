using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MakeYourMeal.Data.Models
{
	public partial class FoodItemHasIngredient
	{
		[Key]
		public int Id { get; set; }

		[Required]
		[Column(Order = 0)]
		public string FoodItemName { get; set; }

		[Required]
		[Column(Order = 1)]
		public string IngredientName { get; set; }

		[Column(Order = 2)]
		public int Quantity { get; set; }

		[Column(Order = 3)]
		public int Position { get; set; }

		public virtual FoodItem FoodItem { get; set; }

		public virtual Ingredient Ingredient { get; set; }
	}
}
