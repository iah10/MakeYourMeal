using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	/// <summary>
	/// Order Repository
	/// </summary>
	public class OrderRepository : RepositoryBase<Order>, IOrderRepository
	{
		public OrderRepository(MakeYourMealEntities dbContext) :base(dbContext)
		{
		
		}

	}

	public interface IOrderRepository : IRepository<Order>
	{
	
	}
}
