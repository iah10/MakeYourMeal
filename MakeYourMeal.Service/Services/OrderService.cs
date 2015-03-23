using System;
using System.Collections.Generic;
using System.Data.Entity;
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
		IEnumerable<Order> GetTodayCommitedOrders();
		IEnumerable<Order> GetTodayOrders();
		IEnumerable<OrderItem> GetOrderItemsForOrder(int orderId);
		Order GetOrderById(int orderId);
		int GetCurrentOrderId(HttpContextBase context);
		void AddToTotalCost(Order order, decimal quantity);
		void AddOrderItemToOrder(int orderId, OrderItem orderItem);
		void RemoverOrderItemFromOrder(int orderId, int orderItemId);
		void ChangeOrderState(Order order, string state);
		void CalculateTotalCost(Order order);
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
		private readonly IOrderStateService _orderStateService;
		public const string OrderSessionId = "OrderId";

		public OrderService(MakeYourMealEntities dbContext)
		{
			_orderStateService = new OrderStateService(dbContext);
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
				var newOrder = new Order { 
					State = OrderState.NEW_ORDER,
					OrderState = _orderStateService.GetStateForId(OrderState.NEW_ORDER)
				};
				CreateNewOrder(newOrder);
				context.Session[OrderSessionId] = newOrder.OrderId;
			}
			return Int32.Parse(context.Session[OrderSessionId].ToString());
		}

		public void AddToTotalCost(Order order, decimal quantity)
		{
			order.TotalCost += quantity;
			UpdateOrder(order);
		}

		public void ChangeOrderState(Order order, string state)
		{
			order.State = state;
			order.OrderState = _orderStateService.GetStateForId(state);
			UpdateOrder(order);
		}

		public void CalculateTotalCost(Order order)
		{
			decimal totalCost = 0;
			var allItems = order.OrderItems;
			foreach (var orderItem in allItems)
			{
				totalCost += orderItem.FoodItem.Price;
				totalCost += orderItem.ExtraIngredients.Sum(extraIng =>  extraIng.AdditionalCharge);
			}
			order.TotalCost = totalCost;
			UpdateOrder(order);
		}

		public IEnumerable<Order> GetAllOrders()
		{
			return _orderRepository.GetAll();
		}

		public IEnumerable<Order> GetTodayCommitedOrders()
		{
			return _orderRepository.GetMany(o => (!o.OrderState.State.Equals(OrderState.NEW_ORDER)
				&& DbFunctions.TruncateTime(o.OrderedAt) == DateTime.Today));
		}

		public IEnumerable<Order> GetTodayOrders()
		{
			return _orderRepository.GetMany(o => DbFunctions.TruncateTime(o.OrderedAt) == DateTime.Today);
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
			CalculateTotalCost(order);
		}

		public void AddOrderItemToOrder(int orderId, OrderItem orderItem)
		{
			var order = GetOrderById(orderId);
			_orderItemService.AddNewOrderItem(orderItem);
			AddToTotalCost(order, orderItem.FoodItem.Price);
		}

		public void EmptyOrder(int orderId)
		{
			var order = GetOrderById(orderId);
			foreach (var orderItem in order.OrderItems)
			{
				_orderItemService.DeleteOrderItem(orderItem.OrderItemId);
			}
			CalculateTotalCost(order);
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
