using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;

namespace MakeYourMeal.DAL.Repository
{
	/// <summary>
	/// The Order Item Repository
	/// </summary>
	public class OrderItemRepository : RepositoryBase<OrderItem>, IOrderItemRepository
	{
		public OrderItemRepository()
			: base(new MakeYourMealEntities())
		{

		}
	}
	public interface IOrderItemRepository : IRepository<OrderItem>
	{
	}
}
