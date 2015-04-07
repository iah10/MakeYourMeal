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
	self.pageSize = 5;
    self.currentPage = ko.observable(1);
    self.Orders = ko.observableArray([]);
    self.lastorder = 0 ; 
    self.lastPage = Math.ceil(self.lastorder / self.pageSize);


    self.currentTransactions = ko.computed(function () {
        var startIndex = (self.currentPage() - 1) * self.pageSize;
        var endIndex = startIndex + self.pageSize;
        return self.Orders.slice(startIndex, endIndex);
    });

	self.details = function (order) {
	    var url = "OrderDetails/" + order.OrderId;
	    window.document.location = url;
	}
	self.nextPage = function () {
	    self.currentPage(self.currentPage() + 1);
	};
	self.previousPage = function () {
	    self.currentPage(self.currentPage() - 1);
	};
};

var viewModel;
$(function () {

	//init
	viewModel = new CartApp.Page();
	var hub = $.connection.adminHub;

	//let knouckout do it's magic
	ko.applyBindings(viewModel);

	//order receivied 
	hub.client.orderReceived = function (order) {
		toastr.info("New order received!");
		viewModel.Orders.unshift(new CartApp.Order(order));
	}

	//start real time connection
	$.connection.hub.start();

	//fill the table
	$.get("/Order/GetTodayCommitedOrders", function (items) {
		$.each(items, function (idx, item) {
		    viewModel.Orders.unshift(new CartApp.Order(item));
		});
	}, "json");
});