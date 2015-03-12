using System.Collections.Generic;
using System.Data.Entity;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.DAL.Infrastructure
{
	/// <summary>
	/// The Database Initializer
	/// </summary>
	public class MakeYourMealDbInitializer : DropCreateDatabaseAlways<MakeYourMealEntities>
	{
		protected override void Seed(MakeYourMealEntities context)
		{
			//Create all the ingredients
			CreateIngredients(context);

			//create food categories
			CreateCategories(context);

			/*Create some food Items*/

			//Create the BigDeluxe Burger
			CreateBigDeluxe(context);

			context.Commit();
		}

		private void CreateCategories(MakeYourMealEntities context)
		{
			new List<Category>
            {
                new Category{CategoryName= Category.CHARBROILED_BURGERS},
                new Category{CategoryName= Category.CHICKEN},
                new Category{CategoryName=Category.SPECIALITIES},
				new Category{CategoryName=Category.SIDES},
				new Category{CategoryName=Category.DESSERTS},
				new Category{CategoryName=Category.BEVERAGES}
            }.ForEach(m => context.Categories.Add(m));
		}

		private void CreateBigDeluxe(MakeYourMealEntities context)
		{
			FoodItem burger = new FoodItem()
			{
				Name = "Big Deluxe",
				CategoryName = Category.CHARBROILED_BURGERS,
				ImagePath = "BigDeluxe.jpg",
				Price = new decimal(12.5)
			};

			context.FoodItems.Add(burger);

			//add items ingredients
			FoodItemHasIngredient bigDeluxeAndCrownBun = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Crown Bun",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndCrownBun);

			FoodItemHasIngredient bigDeluxeAndMayoUpper = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Mayonnaise",
				Quantity = 1,
				Position = 2
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndMayoUpper);

			FoodItemHasIngredient bigDeluxeAndKetchup = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Ketchup",
				Quantity = 1,
				Position = 3
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndKetchup);

			FoodItemHasIngredient bigDeluxeAndCheese = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Cheese",
				Quantity = 1,
				Position = 4
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndCheese);

			FoodItemHasIngredient bigDeluxeAndBeef = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Beef",
				Quantity = 1,
				Position = 5
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndBeef);

			FoodItemHasIngredient bigDeluxeAndOnion = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Onion",
				Quantity = 1,
				Position = 6
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndOnion);

			FoodItemHasIngredient bigDeluxeAndTomato = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Tomato",
				Quantity = 1,
				Position = 7
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndTomato);

			FoodItemHasIngredient bigDeluxeAndLettuce = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Lettuce",
				Quantity = 1,
				Position = 8
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndLettuce);

			FoodItemHasIngredient bigDeluxeAndPickles = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Pickles",
				Quantity = 1,
				Position = 9
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndPickles);

			FoodItemHasIngredient bigDeluxeAndMayoLower = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Mayonnaise",
				Quantity = 1,
				Position = 10
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndMayoLower);

			FoodItemHasIngredient bigDeluxeAndHeelBun = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Heel Bun",
				Quantity = 1,
				Position = 11
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndHeelBun);

		}

		private void CreateIngredients(MakeYourMealEntities context)
		{
			List<Ingredient> ingredients = new List<Ingredient>
			{
				new Ingredient()
				{
					Name = "Crown Bun",
					AdditionalCharge = new decimal(0),
					ImagePath = "CrownBun.jpg"
				},
				new Ingredient()
				{
					Name = "Heel Bun",
					AdditionalCharge = new decimal(0),
					ImagePath = "HeelBun.jpg"
				},
				new Ingredient()
				{
					Name = "Pickles",
					AdditionalCharge = new decimal(0),
					ImagePath = "Pickels.png"
				},
				new Ingredient()
				{
					Name = "Lettuce",
					AdditionalCharge = new decimal(0),
					ImagePath = "Lettuce.png"
				},
				new Ingredient()
				{
					Name = "Tomato",
					AdditionalCharge = new decimal(0),
					ImagePath = "Tomato.png"
				},
				new Ingredient()
				{
					Name = "Onion",
					AdditionalCharge = new decimal(0),
					ImagePath = "Onion.jpg"
				},
				new Ingredient()
				{
					Name = "Cheese",
					AdditionalCharge = new decimal(0),
					ImagePath = "Cheese.png"
				},
				new Ingredient()
				{
					Name = "Mayonnaise",
					AdditionalCharge = new decimal(0),
					ImagePath = "Mayonnaise.jpg"
				},
				new Ingredient()
				{
					Name = "Ketchup",
					AdditionalCharge = new decimal(0),
					ImagePath = "Ketchup.jpg"
				},
				new Ingredient()
				{
					Name = "Mustard",
					AdditionalCharge = new decimal(0),
					ImagePath = "Mustard.jpg"
				},
				new Ingredient()
				{
					Name = "Beef",
					AdditionalCharge = new decimal(1),
					ImagePath = "Beef.png"
				},
				new Ingredient()
				{
					Name = "Chicken Fillet",
					AdditionalCharge = new decimal(1),
					ImagePath = "ChickenFillet.jpg"
				},
				new Ingredient()
				{
					Name = "Grilled Chicken",
					AdditionalCharge = new decimal(1),
					ImagePath = "GrilledChicken.jpg"
				},
				new Ingredient()
				{
					Name = "Turkey",
					AdditionalCharge = new decimal(1),
					ImagePath = "Turkey.jpg"
				}
			};
			ingredients.ForEach(ing => context.Ingredients.Add(ing));
		}
	}
}
