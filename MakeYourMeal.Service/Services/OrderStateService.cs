using System.Collections.Generic;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IOrderStateService
	{
		IEnumerable<OrderState> GetAllOrderStates();
		OrderState GetStateForId(string orderState);
	}
	public class OrderStateService: IOrderStateService
	{
		private readonly IOrderStateRepository _orderStateRepository;

		public OrderStateService(MakeYourMealEntities dbcontext)
		{
			_orderStateRepository =  new OrderStateRepository(dbcontext);
		}

		public IEnumerable<OrderState> GetAllOrderStates()
		{
			return _orderStateRepository.GetAll();
		}

		public OrderState GetStateForId(string orderState)
		{
			return _orderStateRepository.GetById(orderState);
		}
	}
}
