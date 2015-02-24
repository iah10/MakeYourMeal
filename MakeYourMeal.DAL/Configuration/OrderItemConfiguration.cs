using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Configuration
{
	public class OrderItemConfiguration : EntityTypeConfiguration<OrderItem>
	{
		/// <summary>
		/// The Constructor
		/// </summary>
		public OrderItemConfiguration()
        {
            Property(o => o.FoodItemName).IsRequired().HasMaxLength(30);
			Property(o => o.OrderItemId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
        }
	}
}
