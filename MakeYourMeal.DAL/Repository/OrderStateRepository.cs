using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{

	public class OrderStateRepository : RepositoryBase<OrderState>, IOrderStateRepository
	{
		public OrderStateRepository(MakeYourMealEntities dbContext)
			: base(dbContext)
		{
		}
	}

	public interface IOrderStateRepository : IRepository<OrderState>
	{
	}
}
