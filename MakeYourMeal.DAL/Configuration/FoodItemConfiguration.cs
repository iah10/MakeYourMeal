using System.Data.Entity.ModelConfiguration;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Configuration
{
	/// <summary>
	/// Food Item Configuration
	/// </summary>
	public class FoodItemConfiguration : EntityTypeConfiguration<FoodItem>
	{
		/// <summary>
		/// The Constructor
		/// </summary>
		public FoodItemConfiguration()
		{
			//this.HasKey(f => f.Name);
			//Property(f => f.Name).IsRequired().HasMaxLength(30);
			//Property(f => f.Category).IsRequired().HasMaxLength(30);
			//Property(f => f.Price).HasColumnType("smallmoney");
			//Property(f => f.ImagePath).IsRequired().HasMaxLength(100);

			////foreign keys
			//HasMany(e => e.FoodItemHasIngredients)
			//	.WithRequired(e => e.FoodItemName)
			//	.HasForeignKey(e => e.FoodItem)
			//	.WillCascadeOnDelete(false);

			//HasMany(e => e.ExtraOrderItems)
			//	.WithRequired(e => e.FoodItem)
			//	.WillCascadeOnDelete(false);
		}
	}
}
