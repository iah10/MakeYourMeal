using System.Data.Entity;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Infrastructure
{
	/// <summary>
	/// The Database Context of the Application
	/// </summary>
	public class MakeYourMealEntities : DbContext
	{
		/// <summary>
		/// The Constructor
		/// </summary>
		public MakeYourMealEntities()
			: base("MakeYourMealEntities")
		{

		}

		public DbSet<FoodItem> FoodItems { get; set; }
		public DbSet<Category> Categories { get; set; }
		public DbSet<Ingredient> Ingredients { get; set; }
		public DbSet<Order> Orders { get; set; }
		public DbSet<OrderItem> OrderItems { get; set; }
		public DbSet<FoodItemHasIngredient> FoodItemHasIngredients { get; set; }

		/// <summary>
		/// Save the changes to the Database
		/// </summary>
		public virtual void Commit()
		{
			SaveChanges();
		}

		/// <summary>
		/// Configure the Models when creating the database
		/// </summary>
		/// <param name="modelBuilder"></param>
		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			base.OnModelCreating(modelBuilder);

			modelBuilder.Entity<FoodItemHasIngredient>()
				.Property(e => e.FoodItemName)
				.IsVariableLength();

			modelBuilder.Entity<FoodItemHasIngredient>()
				.Property(e => e.IngredientName)
				.IsVariableLength();

			modelBuilder.Entity<FoodItemHasIngredient>()
				.Property(e => e.Position)
				.IsOptional();

			modelBuilder.Entity<FoodItem>()
				.Property(e => e.Name)
				.IsVariableLength();

			modelBuilder.Entity<FoodItem>()
				.Property(e => e.Price)
				.HasPrecision(10, 4);

			modelBuilder.Entity<FoodItem>()
				.Property(e => e.ImagePath)
				.IsVariableLength();

			modelBuilder.Entity<FoodItem>()
				.HasMany(e => e.FoodItemHasIngredients)
				.WithRequired(e => e.FoodItem)
				.HasForeignKey(f =>f.FoodItemName)
				.WillCascadeOnDelete(true);

			modelBuilder.Entity<FoodItem>()
				.HasMany(e => e.OrderItems)
				.WithRequired(e => e.FoodItem)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Category>()
				.HasMany<FoodItem>(c => c.FoodItems)
				.WithRequired(f => f.Category)
				.HasForeignKey(f => f.CategoryName)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Ingredient>()
				.Property(e => e.Name)
				.IsVariableLength();

			modelBuilder.Entity<Ingredient>()
				.Property(e => e.ImagePath)
				.IsVariableLength();

			modelBuilder.Entity<Ingredient>()
				.Property(e => e.AdditionalCharge)
				.HasPrecision(10, 4);

			modelBuilder.Entity<Ingredient>()
				.HasMany(e => e.FoodItemHasIngredients)
				.WithRequired(e => e.Ingredient)
				.HasForeignKey(e => e.IngredientName)
				.WillCascadeOnDelete(false);

			modelBuilder.Entity<Ingredient>()
				.HasMany(e => e.ExtraOrderItems)
				.WithMany(e => e.ExtraIngredients)
				.Map(m => m.ToTable("ExtraIngredients").MapLeftKey("ExtraIngredients_Name").MapRightKey("ExtraOrderItems_OrderItemId"));

			modelBuilder.Entity<Ingredient>()
				.HasMany(e => e.WithoutOrderItems)
				.WithMany(e => e.WithoutIngredients)
				.Map(m => m.ToTable("WithoutIngredients").MapLeftKey("WithoutIngredients_Name").MapRightKey("WithoutOrderItems_OrderItemId"));

			modelBuilder.Entity<OrderItem>()
				.Property(e => e.FoodItemName)
				.IsVariableLength();

			modelBuilder.Entity<Order>()
				.Property(e => e.OrderedAt)
				.IsVariableLength();

			modelBuilder.Entity<Order>()
				.Property(e => e.TotalCost)
				.HasPrecision(10, 4);

			modelBuilder.Entity<Order>()
				.HasMany(e => e.OrderItems)
				.WithMany(e => e.Orders)
				.Map(m => m.ToTable("OrderHasOrderItems").MapLeftKey("Orders_OrderId").MapRightKey("OrderItems_OrderItemId"));
		}
	}
}