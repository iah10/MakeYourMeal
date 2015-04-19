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

			//create Order States
			CreateOrderStates(context);

			/*Create some food Items*/

			CreateBigDeluxe(context);

			CreateChickenFillet(context);

			CreateOrangeJuice(context);

			CreateAppleJuice(context);

			CreateCherryShake(context);

			CreateFries(context);

			context.Commit();
		}

		private void CreateOrderStates(MakeYourMealEntities context)
		{
			new List<OrderState>
			{
				new OrderState{State = OrderState.NEW_ORDER},
				new OrderState{State = OrderState.COMITED_STATE},
				new OrderState{State = OrderState.READY_STATE},
				new OrderState{State = OrderState.CLOSED_STATE}
			}.ForEach(os => context.OrderStates.Add(os));
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

		private void CreateChickenFillet(MakeYourMealEntities context)
		{
			FoodItem cf = new FoodItem()
			{
				Name = "Chicken Fillet",
				CategoryName = Category.CHICKEN,
				TotalCalories = 340,
				ImagePath = "ChickenFilletBurger.png",
				Price = new decimal(11.5)
			};

			context.FoodItems.Add(cf);

			//add items ingredients
			FoodItemHasIngredient chickenFilletAndCrownBun = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Crown Bun",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndCrownBun);

			FoodItemHasIngredient chickenFilletAndMayoUpper = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Mayonnaise",
				Quantity = 1,
				Position = 2
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndMayoUpper);

			FoodItemHasIngredient chickenFilletAndChickenFillet = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Chicken Fillet",
				Quantity = 1,
				Position = 3
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndChickenFillet);

			FoodItemHasIngredient chickenFilletAndLettuce = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Lettuce",
				Quantity = 1,
				Position = 4
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndLettuce);

			FoodItemHasIngredient chickenFilletAndLowerMayo = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Mayonnaise",
				Quantity = 1,
				Position = 5
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndLowerMayo);

			FoodItemHasIngredient chickenFilletAndHeelBun = new FoodItemHasIngredient()
			{
				FoodItemName = "Chicken Fillet",
				IngredientName = "Heel Bun",
				Quantity = 1,
				Position = 6
			};
			context.FoodItemHasIngredients.Add(chickenFilletAndHeelBun);

		}

		private void CreateBigDeluxe(MakeYourMealEntities context)
		{
			FoodItem bk = new FoodItem()
			{
				Name = "Big Deluxe",
				CategoryName = Category.CHARBROILED_BURGERS,
				ImagePath = "BigDeluxe.png",
				TotalCalories = 440,
				Price = new decimal(12.5)
			};

			context.FoodItems.Add(bk);

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

			FoodItemHasIngredient bigDeluxeAndCheese = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Cheese",
				Quantity = 1,
				Position = 3
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndCheese);

			FoodItemHasIngredient bigDeluxeAndBeef = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Beef",
				Quantity = 1,
				Position = 4
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndBeef);

			FoodItemHasIngredient bigDeluxeAndOnion = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Onion",
				Quantity = 1,
				Position = 5
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndOnion);

			FoodItemHasIngredient bigDeluxeAndTomato = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Tomato",
				Quantity = 1,
				Position = 6
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndTomato);

			FoodItemHasIngredient bigDeluxeAndLettuce = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Lettuce",
				Quantity = 1,
				Position = 7
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndLettuce);

			FoodItemHasIngredient bigDeluxeAndPickles = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Pickles",
				Quantity = 1,
				Position = 8
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndPickles);

			FoodItemHasIngredient bigDeluxeAndMayoLower = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Mayonnaise",
				Quantity = 1,
				Position = 9
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndMayoLower);

			FoodItemHasIngredient bigDeluxeAndHeelBun = new FoodItemHasIngredient()
			{
				FoodItemName = "Big Deluxe",
				IngredientName = "Heel Bun",
				Quantity = 1,
				Position = 10
			};
			context.FoodItemHasIngredients.Add(bigDeluxeAndHeelBun);
		}

		private void CreateAppleJuice(MakeYourMealEntities context)
		{
			FoodItem applejuice = new FoodItem()
			{
				Name = "Apple Juice",
				CategoryName = Category.BEVERAGES,
				TotalCalories = 120,
				ImagePath = "apple-juice.png",
				Price = new decimal(4)
			};

			context.FoodItems.Add(applejuice);

			//add items ingredients
			FoodItemHasIngredient applejuiceR = new FoodItemHasIngredient()
			{
				FoodItemName = "Apple Juice",
				IngredientName = "Apple",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(applejuiceR);
		}

		private void CreateOrangeJuice(MakeYourMealEntities context)
		{
			FoodItem orangejuice = new FoodItem()
			{
				Name = "Orange Juice",
				CategoryName = Category.BEVERAGES,
				TotalCalories = 110,
				ImagePath = "orange-juice.png",
				Price = new decimal(4)
			};

			context.FoodItems.Add(orangejuice);

			//add items ingredients
			FoodItemHasIngredient orangejuiceR = new FoodItemHasIngredient()
			{
				FoodItemName = "Orange Juice",
				IngredientName = "Orange",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(orangejuiceR);
		}

		private void CreateCherryShake(MakeYourMealEntities context)
		{
			FoodItem cherryshake = new FoodItem()
			{
				Name = "Cherry Shake",
				CategoryName = Category.DESSERTS,
				TotalCalories = 240,
				ImagePath = "cherry-shake.png",
				Price = new decimal(8)
			};

			context.FoodItems.Add(cherryshake);

			//add items ingredients
			FoodItemHasIngredient cherryshakeR = new FoodItemHasIngredient()
			{
				FoodItemName = "Cherry Shake",
				IngredientName = "Cherry",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(cherryshakeR);
		}

		private void CreateFries(MakeYourMealEntities context)
		{
			FoodItem fries = new FoodItem()
			{
				Name = "Fries",
				CategoryName = Category.SIDES,
				ImagePath = "Fries.png",
				Price = new decimal(5)
			};

			context.FoodItems.Add(fries);

			//add items ingredients
			FoodItemHasIngredient friesR = new FoodItemHasIngredient()
			{
				FoodItemName = "Fries",
				IngredientName = "Potato",
				Quantity = 1,
				Position = 1
			};
			context.FoodItemHasIngredients.Add(friesR);
		}

		private void CreateIngredients(MakeYourMealEntities context)
		{
			List<Ingredient> ingredients = new List<Ingredient>
			{
				new Ingredient()
				{
					Name = "Crown Bun",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "CrownBun.png"
				},
				new Ingredient()
				{
					Name = "Heel Bun",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "HeelBun.png"
				},
				new Ingredient()
				{
					Name = "Pickles",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Pickles.png"
				},
				new Ingredient()
				{
					Name = "Lettuce",
					AdditionalCharge = new decimal(1),
					IsRemovable = true,
					ImagePath = "Lettuce.png"
				},
				new Ingredient()
				{
					Name = "Tomato",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Tomato.png"
				},
				new Ingredient()
				{
					Name = "Onion",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Onion.png"
				},
				new Ingredient()
				{
					Name = "Cheese",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Cheese.png"
				},
				new Ingredient()
				{
					Name = "Mayonnaise",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Mayonnaise.png"
				},
				new Ingredient()
				{
					Name = "Ketchup",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Ketchup.png"
				},
				new Ingredient()
				{
					Name = "Mustard",
					AdditionalCharge = new decimal(0),
					IsRemovable = true,
					ImagePath = "Mustard.jpg"
				},
				new Ingredient()
				{
					Name = "Beef",
					AdditionalCharge = new decimal(1),
					IsRemovable = true,
					ImagePath = "Beef.png"
				},
				new Ingredient()
				{
					Name = "Chicken Fillet",
					AdditionalCharge = new decimal(1),
					IsRemovable = true,
					ImagePath = "ChickenFillet.png"
				},
				new Ingredient()
				{
					Name = "Grilled Chicken",
					AdditionalCharge = new decimal(1),
					IsRemovable = false,
					ImagePath = "GrilledChicken.png"
				},
				new Ingredient()
				{
					Name = "Turkey",
					AdditionalCharge = new decimal(1),
					IsRemovable = true,
					ImagePath = "Turkey.jpg"
				},
				new Ingredient()
				{
					Name = "Apple",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "apple-juice.png"
				},
				new Ingredient()
				{
					Name = "Orange",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "orange-juice.png"
				},
				new Ingredient()
				{
					Name = "Cherry",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "cherry-shake.png"
				},
				new Ingredient()
				{
					Name = "Potato",
					AdditionalCharge = new decimal(0),
					IsRemovable = false,
					ImagePath = "Fries.png"
				}
			};
			ingredients.ForEach(ing => context.Ingredients.Add(ing));
		}
	}
}