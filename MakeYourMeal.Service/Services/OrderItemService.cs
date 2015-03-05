using System.Collections.Generic;
using System.Linq;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IOrderItemService
	{
		IEnumerable<OrderItem> GetAllOrderItems();
		IEnumerable<Ingredient> GetExtraIngredeintsForOrderItem(int orderItemId);
		IEnumerable<Ingredient> GetWithoutIngredeintsForOrderItem(int orderItemId);
		FoodItem GetFoodItemForOrderItem(int orderItemId);
		void AddExtraIngredientForOrderItem(int orderItemId, string ingName);
		void RemoveIngredientForOrderItem(int orderItemId, string ingName);
		void AddNewOrderItem(OrderItem newOrderItem);
		void UpdateOrderItem(OrderItem orderItem);
		void DeleteOrderItem(int orderItemId);
		void SaveOrderItem();
	}

	/// <summary>
	/// Order Item Service
	/// </summary>
	public class OrderItemService : IOrderItemService
	{
		private readonly IOrderItemRepository _orderItemRepository;
		private readonly IIngridientService _ingrdientService;

		public OrderItemService(MakeYourMealEntities dbContext)
		{
			_orderItemRepository = new OrderItemRepository(dbContext);
			_ingrdientService = new IngridientService(dbContext);
		}

		public IEnumerable<OrderItem> GetAllOrderItems()
		{
			var allOrderItems = _orderItemRepository.GetAll();
			return allOrderItems;
		}

		public IEnumerable<Ingredient> GetExtraIngredeintsForOrderItem(int orderItemId)
		{
			var orderItem = _orderItemRepository.Get(o => o.OrderItemId == orderItemId);
			return orderItem.ExtraIngredients.ToList();
		}

		public IEnumerable<Ingredient> GetWithoutIngredeintsForOrderItem(int orderItemId)
		{
			var orderItem = _orderItemRepository.Get(o => o.OrderItemId == orderItemId);
			return orderItem.WithoutIngredients.ToList();
		}

		public FoodItem GetFoodItemForOrderItem(int orderItemId)
		{
			var orderItem = _orderItemRepository.Get(o => o.OrderItemId == orderItemId);
			var foodItem = orderItem.FoodItem;
			return foodItem;
		}

		public void AddExtraIngredientForOrderItem(int orderItemId, string ingName)
		{
			var orderItem = _orderItemRepository.GetById(orderItemId);
			var ingredient = _ingrdientService.FindIngredient(ingName);
			orderItem.ExtraIngredients.Add(ingredient);
			SaveOrderItem();
		}

		public void RemoveIngredientForOrderItem(int orderItemId, string ingName)
		{
			var orderItem = _orderItemRepository.GetById(orderItemId);
			var ingredient = _ingrdientService.FindIngredient(ingName);
			orderItem.WithoutIngredients.Add(ingredient);
			SaveOrderItem();
		}

		public void AddNewOrderItem(OrderItem newOrderItem)
		{
			_orderItemRepository.Add(newOrderItem);
			SaveOrderItem();
		}

		public void UpdateOrderItem(OrderItem orderItem)
		{
			_orderItemRepository.Update(orderItem);
			SaveOrderItem();
		}

		public void DeleteOrderItem(int orderItemId)
		{
			_orderItemRepository.Delete(o => o.OrderItemId == orderItemId);
			SaveOrderItem();
		}

		public void SaveOrderItem()
		{
			_orderItemRepository.Save();
		}
	}
}
