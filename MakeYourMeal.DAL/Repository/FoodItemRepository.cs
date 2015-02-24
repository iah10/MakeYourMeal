using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	/// <summary>
	/// The Food Item Repository
	/// </summary>
	public class FoodItemRepository : RepositoryBase<FoodItem>, IFoodItemRepository
	{
		public FoodItemRepository(): base(new MakeYourMealEntities())
		{
		}
	}
	public interface IFoodItemRepository : IRepository<FoodItem>
	{
	}
}
