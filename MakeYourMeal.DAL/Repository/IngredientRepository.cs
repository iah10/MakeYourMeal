using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	public class IngredientRepository : RepositoryBase<Ingredient>, IIngredientRepository
	{
		public IngredientRepository(MakeYourMealEntities dbContext)
			: base(dbContext)
		{
		}
	}
	public interface IIngredientRepository : IRepository<Ingredient>
	{
	}
}
