using System;
using System.Collections.Generic;
using System.Linq;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.DAL.Repository;

namespace MakeYourMeal.Service.Services
{
	public interface IFoodItemService
	{
		IEnumerable<FoodItem> GetAllFoodItems();
		IEnumerable<FoodItem> GetFoodItemsForCategory(string category);
		FoodItem FindFoodItem(string foodItemName);
		IEnumerable<Ingredient> GetIngredientsForFoodItem(string fooItemName);
		void AddNewFoodItem(FoodItem newFoodItem);
		void UpdateFoodItem(FoodItem foodItem);
		void DeleteFoodItem(string foodItemName);
		void AddIngredientToFoodItem(string foodItemName, Ingredient ingredient);
		void SaveFoodItem();
	}

	public class FoodItemService : IFoodItemService
	{
		private readonly IFoodItemRepository _foodItemRepository;

		public FoodItemService(MakeYourMealEntities dbContext)
		{
			_foodItemRepository = new FoodItemRepository(dbContext);
		}
		public IEnumerable<FoodItem> GetAllFoodItems()
		{
			var allFoodItems = _foodItemRepository.GetAll();
			return allFoodItems;
		}

		public IEnumerable<FoodItem> GetFoodItemsForCategory(string category)
		{
			var foodItems = _foodItemRepository.GetMany(f => f.CategoryName == category);
			return foodItems;
		}

		public FoodItem FindFoodItem(string foodItemName)
		{
			var item = _foodItemRepository.GetById(foodItemName);
			return item;
		}

		public IEnumerable<Ingredient> GetIngredientsForFoodItem(string foodItemName)
		{
			var item = FindFoodItem(foodItemName);
			var ingredients = item.FoodItemHasIngredients;
			var sortedIng = sortIngredients(ingredients);
			return sortedIng;
		}

		private IEnumerable<Ingredient> sortIngredients(ICollection<FoodItemHasIngredient> foodItemHasIngredients)
		{
			SortedList<Int32, Ingredient> ingredients = new SortedList<Int32, Ingredient>();
			foreach (var fHasIng in foodItemHasIngredients)
			{
				ingredients.Add(fHasIng.Position, fHasIng.Ingredient);
			}
			return ingredients.Values;
		}

		public void AddNewFoodItem(FoodItem newFoodItem)
		{
			_foodItemRepository.Add(newFoodItem);
			SaveFoodItem();
		}

		public void UpdateFoodItem(FoodItem newFoodItem)
		{
			_foodItemRepository.Update(newFoodItem);
			SaveFoodItem();
		}

		public void DeleteFoodItem(string foodItemName)
		{
			var foodItem = _foodItemRepository.GetById(foodItemName);
			_foodItemRepository.Delete(foodItem);
			SaveFoodItem();
		}

		public void AddIngredientToFoodItem(string foodItemName, Ingredient ingredient)
		{
			var foodItem = _foodItemRepository.GetById(foodItemName);
			foodItem.FoodItemHasIngredients.Add(new FoodItemHasIngredient
			{
				FoodItemName = foodItemName,
				IngredientName = ingredient.Name
			});
			UpdateFoodItem(foodItem);
		}

		public void SaveFoodItem()
		{
			_foodItemRepository.Save();
		}
	}
}