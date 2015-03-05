using System.Web.Mvc;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.Service.Services;
using MakeYourMeal.ViewModels;

namespace MakeYourMeal.Controllers
{
	//[Authorize]
    public class OrderController : Controller
    {

	    private static MakeYourMealEntities _context = new MakeYourMealEntities();
		private IOrderService _orderService = new OrderService(_context);
		private IOrderItemService _orderItemService = new OrderItemService(_context);
		private IFoodItemService _foodItemService = new FoodItemService(_context);
		 
        // GET: Order
        public ActionResult Index()
        {
            return View(_orderService.GetAllOrders());
        }

        // GET: Order/Details/5
        public ActionResult Details(int id)
        {
			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
	        Order currentOrder = _orderService.GetOrderById(orderId);
			OrderViewModel viewModel = new OrderViewModel
			{
				TableNumber = currentOrder.TableNumber,
				OrderItems = currentOrder.OrderItems,
				State = currentOrder.State,
				TotalCost = currentOrder.TotalCost
			};
			return View(viewModel);
        }

		/// <summary>
		/// When the user drags a food item to the plate. this method is invoked.
		/// We retrieve the food item name and create an order item and add it to the order
		/// </summary>
		/// <param name="id">Order Id</param>
		/// <returns></returns>
		public ActionResult AddOrderItem(string id)
		{
			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			FoodItem chosenFoodItem = _foodItemService.FindFoodItem(id);
			OrderItem newItem = new OrderItem
			{
				FoodItem = chosenFoodItem,
				FoodItemName = id,
				OrderId = orderId
			};
			_orderService.AddOrderItemToOrder(orderId, newItem);
			return RedirectToAction("Index");
		}

        // GET: Order/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Order/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Order/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Order/Delete/5
        public ActionResult DeleteOrderItem(int id)
        {
			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			_orderService.RemoverOrderItemFromOrder(orderId, id);
			return RedirectToAction("Index");
        }

	    public ActionResult AddExtraIngredient(int orderItem, string ingName)
	    {
		    _orderItemService.AddExtraIngredientForOrderItem(orderItem, ingName);
			return RedirectToAction("Index");
	    }

		public ActionResult RemoveIngredient(int orderItem, string ingName)
		{
			_orderItemService.RemoveIngredientForOrderItem(orderItem, ingName);
			return RedirectToAction("Index");
		}
    }
}
