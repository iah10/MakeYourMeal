using System.EnterpriseServices;
using System.Linq;
using System.Net;
using System.Web.Mvc;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.Service.Services;
using MakeYourMeal.ViewModels;

namespace MakeYourMeal.Controllers
{
	public class FoodItemsController : Controller
	{
		/*---- Instance Variables ----*/

		private static MakeYourMealEntities _context = new MakeYourMealEntities();
		private readonly IFoodItemService _foodItemService = new FoodItemService(_context);
		private readonly ICategoryService _categoryService = new CategoryService(_context);

		/*---------------------------*/

		// GET: FoodItems
		public ActionResult Index()
		{
			ViewBag.TableNumber = OrderService.GetCurrentTableNumber(this.HttpContext);
			var categories = _categoryService.GetAllCategories();
			return View(categories);
		}


		// GET: FoodItems/Details/name
		public ActionResult Details(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var foodItem = _foodItemService.FindFoodItem(id);
			if (foodItem == null)
			{
				return HttpNotFound();
			}
			var ingredientsForFoodItem = _foodItemService.GetIngredientsForFoodItem(foodItem.Name);
			var foodItemVm = new FoodItemAndIgredientsViewModel(foodItem, ingredientsForFoodItem);
			return PartialView("_Details", foodItemVm);
		}

		// GET: FoodItems/Create
		public ActionResult Create()
		{
			return View();
		}

		// POST: FoodItems/Create
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Create([Bind(Include = "Name,Category,Price,ImagePath")] FoodItem foodItem)
		{
			if (ModelState.IsValid)
			{
				_foodItemService.AddNewFoodItem(foodItem);
				return RedirectToAction("Index");
			}

			return View(foodItem);
		}

		// GET: FoodItems/Edit/name
		public ActionResult Edit(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var foodItem = _foodItemService.FindFoodItem(id);
			if (foodItem == null)
			{
				return HttpNotFound();
			}
			return View(foodItem);
		}

		// POST: FoodItems/Edit/5
		[HttpPost]
		[ValidateAntiForgeryToken]
		public ActionResult Edit([Bind(Include = "Name,CategoryName,Price,ImagePath")] FoodItem foodItem)
		{
			if (ModelState.IsValid)
			{
				_foodItemService.UpdateFoodItem(foodItem);
				return RedirectToAction("Index");
			}
			return View(foodItem);
		}

		// GET: FoodItems/Delete/name
		public ActionResult Delete(string id)
		{
			if (id == null)
			{
				return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
			}
			var foodItem = _foodItemService.FindFoodItem(id);
			if (foodItem == null)
			{
				return HttpNotFound();
			}
			return View(foodItem);
		}

		// POST: FoodItems/Delete/name
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public ActionResult DeleteConfirmed(string id)
		{
			var foodItem = _foodItemService.FindFoodItem(id);
			_foodItemService.DeleteFoodItem(id);
			return RedirectToAction("Index");
		}

		public ActionResult GetAllFoodItemsForCategory(string category)
		{
			var foodItems = _foodItemService.GetFoodItemsForCategory(category);
			return PartialView("_FoodItems", foodItems);
		}
	}
}