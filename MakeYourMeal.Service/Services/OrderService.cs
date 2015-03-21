using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IOrderService
	{
		IEnumerable<Order> GetAllOrders();
		IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId);
		Order GetOrderById(int orderId);
		void AddOrderItemToOrder(int orderId, OrderItem orderItem);
		void RemoverOrderItemFromOrder(int orderId, int orderItemId);
		int GetCurrentOrderId(HttpContextBase context);
		void EmptyOrder(int orderId);
		void CreateNewOrder(Order newOrder);
		void UpdateOrder(Order order);
		void DeleteOrder(int orderId);
		void SaveOrder();
	}

	public class OrderService : IOrderService
	{
		private readonly IOrderRepository _orderRepository;
		private readonly IOrderItemService _orderItemService;
		public const string OrderSessionId = "OrderId";

		public OrderService(MakeYourMealEntities dbContext)
		{
			_orderRepository = new OrderRepository(dbContext);
			_orderItemService = new OrderItemService(dbContext);
		}

		/// <summary>
		/// During the application, there will always be a new order Id in the session.
		/// </summary>
		/// <returns></returns>
		public int GetCurrentOrderId(HttpContextBase context)
		{
			if (context.Session[OrderSessionId] == null)
            {
	                var newOrder = new Order();
					CreateNewOrder(newOrder);
                    context.Session[OrderSessionId] = newOrder.OrderId;
            }
            return Int32.Parse(context.Session[OrderSessionId].ToString());
		}
		
		public IEnumerable<Order> GetAllOrders()
		{
			return _orderRepository.GetAll();
		}

		public IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId)
		{
			var order = _orderRepository.GetById(orderId);
			return order.OrderItems.ToList();
		}

		public Order GetOrderById(int orderId)
		{
			return _orderRepository.GetById(orderId);
		}

		public void RemoverOrderItemFromOrder(int orderId, int orderItemId)
		{
			var order = GetOrderById(orderId);
			_orderItemService.DeleteOrderItem(orderItemId);
			UpdateOrder(order);
		}

		public void AddOrderItemToOrder(int orderId, OrderItem orderItem)
		{
			var order = GetOrderById(orderId);
			_orderItemService.AddNewOrderItem(orderItem);
			UpdateOrder(order);
		}

		public void EmptyOrder(int orderId)
		{
			var order = GetOrderById(orderId);
			foreach (var orderItem in order.OrderItems)
			{
				_orderItemService.DeleteOrderItem(orderItem.OrderItemId);
			}
			UpdateOrder(order);
		}

		public void CreateNewOrder(Order newOrder)
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
			var order = GetOrderById(orderId);
			_orderRepository.Delete(order);
			SaveOrder();
		}

		public void SaveOrder()
		{
			_orderRepository.Save();
		}
	}
}
