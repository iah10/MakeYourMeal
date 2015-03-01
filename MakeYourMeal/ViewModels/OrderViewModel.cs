using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using MakeYourMeal.Data.Models;

namespace MakeYourMeal.ViewModels
{
	public class OrderViewModel
	{
		//public OrderViewModel(int tableNumber, decimal totalCost, int state, IEnumerable<OrderItem> orderItems)
		//{
		//	TableNumber = tableNumber;
		//	OrderTime = DateTime.Now;
		//	TotalCost = totalCost;
		//	State = state;
		//	OrderItems = orderItems;
		//}

		public int TableNumber { get; set; }

		public DateTime OrderTime { get; set; }

		public decimal TotalCost { get; set; }

		public int State { get; set; }

		public  IEnumerable<OrderItem> OrderItems { get; set; }
	}
}