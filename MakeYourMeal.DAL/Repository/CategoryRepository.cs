using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	public class CategoryRepository : RepositoryBase<Category>, ICategoryRepository
	{
		public CategoryRepository(MakeYourMealEntities dbContext)
			: base(dbContext)
		{
		}
	}
	public interface ICategoryRepository : IRepository<Category>
	{
	}
}
