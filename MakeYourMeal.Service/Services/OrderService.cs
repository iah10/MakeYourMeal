using System.Collections.Generic;
using System.Linq;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IOrderService
	{
		IEnumerable<Order> GetAllOrder();
		IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId);
		void AddNewOrder(Order newOrder);
		void UpdateOrder(Order order);
		void DeleteOrder(int orderId);
		void SaveOrder();
	}

	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;

		public OrderService()
		{
			_orderRepository = new OrderRepository();
		}

		public IEnumerable<Order> GetAllOrder()
		{
			_orderRepository.GetAll();
		}

		public IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId)
		{
			var order = _orderRepository.GetById(orderId);
			return order.OrderItems.ToList();
		}

		public void AddNewOrder(Order newOrder)
		{
			_orderRepository.Add(newOrder);
			SaveOrder();
		}

		public void UpdateOrder(Order order)
		{
			_orderRepository.Update(order);
			SaveOrder();
		}

		public void DeleteOrder(int orderId)
		{
			var order = _orderRepository.GetById(orderId);
			_orderRepository.Delete(order);
			SaveOrder();
		}

		public void SaveOrder()
		{
			_orderRepository.Save();
		}
	}
}
