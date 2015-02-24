using System.Data.Entity.ModelConfiguration;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Configuration
{
	public class FoodItemHasIngredientsConfiguration : EntityTypeConfiguration<FoodItemHasIngredient>
	{
		public FoodItemHasIngredientsConfiguration()
		{
			//Property(fi => fi.FoodItem).IsRequired().HasMaxLength(30).HasColumnOrder(0);
			//Property(fi => fi.FoodItem).IsRequired().HasMaxLength(30).HasColumnOrder(1);
			//Property(fi => fi.Quantity).IsRequired().HasColumnOrder(2);

		}
	}
}
