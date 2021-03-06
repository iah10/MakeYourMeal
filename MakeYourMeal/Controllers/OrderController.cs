﻿using System;
using System.Linq;
using System.Web.Mvc;
using MakeYourMeal.Data.Models;
using MakeYourMeal.DAL.Infrastructure;
using MakeYourMeal.Service.Services;
using MakeYourMeal.SignalR;
using MakeYourMeal.ViewModels;
using Microsoft.AspNet.SignalR;
using System.Collections.Generic;

namespace MakeYourMeal.Controllers
{
	//[Authorize]
	public class OrderController : Controller
	{
		/*---- Instance Variables ----*/

		private static readonly MakeYourMealEntities _context = new MakeYourMealEntities();
		private readonly IOrderService _orderService = new OrderService(_context);
		private readonly IIngridientService _ingredientService = new IngredientService(_context);
		private readonly IOrderItemService _orderItemService = new OrderItemService(_context);
		private readonly IFoodItemService _foodItemService = new FoodItemService(_context);
		protected readonly Lazy<IHubContext> AdminHub = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<AdminHub>());
		protected readonly Lazy<IHubContext> CustomersHubb = new Lazy<IHubContext>(() => GlobalHost.ConnectionManager.GetHubContext<CustomersHub>());

		/*--------------------------*/

		// GET: Order
		public ActionResult Index()
		{
			return View();
		}

		public ActionResult GetTodayCommitedOrders()
		{
			var orders = _orderService.GetTodayCommitedOrders();
			return Json(
				from o in orders
				select new
				{
					OrderId = o.OrderId,
					TableNumber = o.TableNumber,
					OrderTime = o.OrderedAt.ToString("HH:mm tt"),
					TotalCost = o.TotalCost,
					State = o.OrderState.State
				}, JsonRequestBehavior.AllowGet);
		}

        public ActionResult CallAdmin()
        {
            var tableNumber = OrderService.GetCurrentTableNumber(this.HttpContext);
			AdminHub.Value.Clients.All.callReceived(tableNumber);
            return Json(true, JsonRequestBehavior.AllowGet);
        }

		public ActionResult AddOrderItem(string id)
		{
			var ing = Request.Form;
			string extras = String.Empty;
			string without = String.Empty;

			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			OrderItem newItem = new OrderItem
			{
				FoodItemName = id,
				FoodItem = _foodItemService.FindFoodItem(id),
				OrderId = orderId,

			};

			if (ing != null)
			{
				foreach (string key in ing.AllKeys)
				{
					if (key.Equals("extras[]"))
					{
						extras = Request.Form[key];
						string [] array = extras.Split(',');
						foreach (string ingredient in array)
						{
							newItem.ExtraIngredients.Add(_ingredientService.FindIngredient(ingredient));
						}
					}
					else if(key.Equals("without[]"))
					{
						without = Request.Form[key];
						string[] array = without.Split(',');
						foreach (string ingredient in array)
						{
							newItem.WithoutIngredients.Add(_ingredientService.FindIngredient(ingredient));
						}
					}
				}
			}

			_orderService.AddOrderItemToOrder(orderId, newItem);
			return Json(true, JsonRequestBehavior.AllowGet);
		}

		//Used by regular users
		public ActionResult MyOrder()
		{
			int currentTableNumber = OrderService.GetCurrentTableNumber(this.HttpContext);
			var orders = _orderService.GetNewOrCommitedOrdersForTableNum(currentTableNumber);
			ViewBag.TableNumber = currentTableNumber;
			return View(orders);
		}

		public ActionResult CommitCurrentOrder()
		{
			var orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			var order = _orderService.GetOrderById(orderId);
			_orderService.CommitOrder(this.HttpContext);
			AdminHub.Value.Clients.All.orderReceived(new
			{
				OrderId = order.OrderId,
				TableNumber = order.TableNumber,
				OrderTime = order.OrderedAt.ToString("HH:mm tt"),
				TotalCost = order.TotalCost,
				State = order.OrderState.State
			});
			return RedirectToAction("Index", "FoodItems");
		}

		public ActionResult OrderReady(int id)
		{
			Order currentOrder = _orderService.GetOrderById(id);
			_orderService.ChangeOrderState(currentOrder, OrderState.READY_STATE);
			//look up table connection Id
			string connectionId = CustomersHub.GetConnectionId(currentOrder.TableNumber + "");
			CustomersHubb.Value.Clients.Client(connectionId).orderStateChanged(OrderState.READY_STATE);
			return RedirectToAction("Index");
		}

		public ActionResult OrderClosed(int id)
		{
			Order currentOrder = _orderService.GetOrderById(id);
			_orderService.ChangeOrderState(currentOrder, OrderState.CLOSED_STATE);
			return RedirectToAction("Index");
		}

		//used by cashier
		public ActionResult OrderDetails(int id)
		{
			Order currentOrder = _orderService.GetOrderById(id);
			OrderViewModel viewModel = GetOrderViewModelForOrder(currentOrder);
			return View(viewModel);
		}

		// GET: Order/Delete/5
		public ActionResult DeleteOrderItem(int id)
		{
			int orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			var newPrice = _orderService.RemoverOrderItemFromOrder(orderId, id);
			return Json(newPrice, JsonRequestBehavior.AllowGet);
		}

		public ActionResult GetCountOfCurrentOrder()
		{
			var orderId = _orderService.GetCurrentOrderId(this.HttpContext);
			int count = _orderService.GetOrderItemsCount(orderId);
			return Json(count, JsonRequestBehavior.AllowGet);
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