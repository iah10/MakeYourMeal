using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	/// <summary>
	/// The Order Item Repository
	/// </summary>
	public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
	{
		public OrderItemRepository(MakeYourMealEntities dbContext)
			: base(dbContext)
		{

		}
	}
	public interface IOrderItemRepository : IRepository<OrderItem>
	{
	}
}
