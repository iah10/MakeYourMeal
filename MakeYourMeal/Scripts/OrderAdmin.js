var CartApp = CartApp || {};

CartApp.Order = function (item)
{
	var self = this;
	self.OrderId = item.OrderId;
	self.TableNumber = item.TableNumber;
	self.OrderTime = item.OrderTime;
	self.TotalCost = item.TotalCost;
	self.State = item.State;
};

CartApp.Page = function () {
	var self = this;
	self.Orders = ko.observableArray([]);
};

var viewModel;
$(function () {

	//init
	viewModel = new CartApp.Page();
	var hub = $.connection.adminHub;

	//let knouckout do it's magic
	ko.applyBindings(viewModel);

	//order receivied 
	hub.client.orderReceived = function () {
		toastr.info("New order received!");
	}

	//start real time connection
	$.connection.hub.start();

	//fill the table
	$.get("/Order/GetTodayCommitedOrders", function (items) {
		$.each(items, function (idx, item) {
			console.log(item);
			viewModel.Orders.push(new CartApp.Order(item));
		});
	}, "json");

});