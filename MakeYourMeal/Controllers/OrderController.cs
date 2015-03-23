using System;
using System.Web.Mvc;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.Service.Services;
using MakeYourMeal.SignalR;
using MakeYourMeal.ViewModels;
using Microsoft.AspNet.SignalR;

namespace MakeYourMeal.Controllers
{
	//[Authorize]
	public class OrderController : Controller
	{
		/*---- Instance Variables ----*/

		private static readonly MakeYourMealEntities _context = new MakeYourMealEntities();
		private readonly IOrderService _orderService = new OrderService(_context);
		private readonly IOrderItemService _orderItemService = new OrderItemService(_context);
		private readonly IFoodItemService _foodItemService = new FoodItemService(_context);
		protected readonly Lazy<IHubContext> AdminHub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<AdminHub>());

		/*--------------------------*/

		// GET: Order
		public ActionResult Index()
		{
			var orders = _orderService.GetTodayCommitedOrders();
			return View(orders);
		}

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
			return Json(true, JsonRequestBehavior.AllowGet);
		}

		//Used by regular users
		public ActionResult MyOrder()
		{
			int currentOrderId = _orderService.GetCurrentOrderId(this.HttpContext);
			Order currentOrder = _orderService.GetOrderById(currentOrderId);
			OrderViewModel viewModel = GetOrderViewModelForOrder(currentOrder);
			return View(viewModel);
		}

		public ActionResult CommitOrder()
		{
			int currentOrderId = _orderService.GetCurrentOrderId(this.HttpContext);
			Order currentOrder = _orderService.GetOrderById(currentOrderId);
			_orderService.ChangeOrderState(currentOrder, OrderState.COMITED_STATE);
			AdminHub.Value.Clients.All.orderReceived();
			return RedirectToAction("Index", "FoodItems");
		}

		//used by cashier
		public ActionResult OrderDetails(int id)
		{
			Order currentOrder = _orderService.GetOrderById(id);
			OrderViewModel viewModel  = GetOrderViewModelForOrder(currentOrder);
			return View("OrderDetails",viewModel);
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
			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			Order cuurentOrder = _orderService.GetOrderById(orderId);
			_orderService.CalculateTotalCost(cuurentOrder);
			return RedirectToAction("Index");
		}

		public ActionResult RemoveIngredient(int orderItem, string ingName)
		{
			_orderItemService.RemoveIngredientForOrderItem(orderItem, ingName);
			return RedirectToAction("Index");
		}

		private OrderViewModel GetOrderViewModelForOrder(Order order)
		{
			OrderViewModel viewModel = new OrderViewModel
			{
				TableNumber = order.TableNumber,
				OrderItems = order.OrderItems,
				State = order.OrderState.State,
				OrderTime = order.OrderedAt,
				TotalCost = order.TotalCost
			};
			return viewModel;
		}
	}
}