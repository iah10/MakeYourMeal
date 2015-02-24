using System.Data.Entity.ModelConfiguration;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Configuration
{
	/// <summary>
	/// IngredientName Configuration
	/// </summary>
	public class IngredientConfiguration : EntityTypeConfiguration<Ingredient>
	{
		public IngredientConfiguration()
		{
			Property(i => i.Name).IsRequired().HasMaxLength(30);
			Property(i => i.ImagePath).IsRequired().HasMaxLength(100);
			Property(i => i.AdditionalCharge).IsRequired().HasColumnType("smallmoney");

			//foreign keys
			//HasMany(e => e.FoodItemHasIngredients)
			//	.WithRequired(e => e.IngredientName)
			//	.HasForeignKey(e => e.IngredientName)
			//	.WillCascadeOnDelete(false);

			//HasMany(e => e.ExtraOrderItems)
			//	.WithMany(e => e.ExtraIngredients)
			//	.Map(m => m.ToTable("ExtraIngredients").MapLeftKey("IngredientName").MapRightKey("OrderItemId"));

			//HasMany(e => e.WithoutOrderItems)
			//	.WithMany(e => e.WithoutIngredients)
			//	.Map(m => m.ToTable("WithoutIngredients").MapLeftKey("IngredientName").MapRightKey("OrderItemId"));
		}
	}
}
