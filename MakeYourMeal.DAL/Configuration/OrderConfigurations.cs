using System.ComponentModel.DataAnnotations.Schema;
using System.Data.Entity.ModelConfiguration;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Configuration
{
	/// <summary>
	/// Order Configurations
	/// </summary>
	public class OrderConfigurations : EntityTypeConfiguration<Order>
	{
		/// <summary>
		/// The Constructor
		/// </summary>
		public OrderConfigurations()
		{
			Property(o => o.OrderId).HasDatabaseGeneratedOption(DatabaseGeneratedOption.None);
			Property(o => o.OrderedAt).IsRequired().HasColumnType("datetime");
			Property(o => o.TotalCost).IsRequired().HasColumnType("smallmoney");

			//Each Order has many ExtraOrderItems
			HasMany(e => e.OrderItems)
				.WithMany(e => e.Orders)
				.Map(m => m.ToTable("OrderHasOrderItems").MapLeftKey("OrderId").MapRightKey("OrderItemId"));
		}
	}
}
