using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MakeYourMeal.Data.Models
{
	public class Category
	{
		public const string CHARBROILED_BURGERS = "Charbroiled Burgers";
		public const string CHICKEN = "Chicken";
		public const string SPECIALITIES = "Specialities";
		public const string SIDES = "Sides";
		public const string DESSERTS = "Desserts";
		public const string BEVERAGES = "Beverages";

		public Category()
		{
			FoodItems = new HashSet<FoodItem>();
		}

		[Key]
		public string CategoryName { get; set; }

		public virtual ICollection<FoodItem> FoodItems { get; set; }
	}
}
