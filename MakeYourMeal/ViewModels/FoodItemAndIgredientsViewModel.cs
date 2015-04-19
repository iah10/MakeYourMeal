using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using MakeYourMeal.Data.Models;
using WebGrease;

namespace MakeYourMeal.ViewModels
{
	public class FoodItemAndIgredientsViewModel
	{

		public FoodItemAndIgredientsViewModel(FoodItem item, IEnumerable<Ingredient> ingredients)
		{
			this.Name = item.Name;
			this.CategoryName = item.CategoryName;
			this.ImagePath = item.ImagePath;
			this.Price = item.Price;
			this.Ingredients = ingredients;
			this.TotalCalories = item.TotalCalories;
		}

		public string Name { get; set; }

		[Display(Name = "Category")]
		public string CategoryName { get; set; }

		[Display(Name = "Total Calories")]
		public int TotalCalories { get; set; }

		public decimal? Price { get; set; }

		public string ImagePath { get; set; }

		public IEnumerable<Ingredient> Ingredients { get; set; } 

	}
}