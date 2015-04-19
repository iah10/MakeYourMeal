var NotiApp = NotiApp || {};

NotiApp.Noti = function (item) {
	var self = this;
	self.numberOfNoti = ko.observable(0);
};
var viewModel;

$(function () {

	//init knoukcout
	toastr.options.preventDuplicates = true;
	viewModel = new NotiApp.Noti();

	//let knouckout do it's magic
	ko.applyBindings(viewModel, document.getElementById("#nav"));

	//load menu
	var trigger = $('.hamburger'),
			isClosed = true;

	$('#wrapper').toggleClass('toggled');

	function hamburgerCross() {

		if (isClosed) {
			trigger.removeClass('is-open');
			trigger.addClass('is-closed');
			isClosed = false;
		} else {
			trigger.removeClass('is-closed');
			trigger.addClass('is-open');
			isClosed = true;
		}
	}

	id = "drag-container";
	trigger.click(function () {
		hamburgerCross();
	});

	$('[data-toggle="offcanvas"]').click(function () {
		$('#wrapper').toggleClass('toggled');
	});

	//start hub
	var hub = $.connection.customersHub;

	//order receivied 
	hub.client.orderStateChanged = function (state) {
		toastr.info("Your Order Is Now " + state);
	}

	//start real time connection
	$.connection.hub.start().done(function () {
		hub.server.registerConId(window.tableNumber);
	});

	//some events
	$(".updatePage").click(function () {
		//$(this).parent().parent().parent().toggleClass("open", "!important");
		//get the category id
		var id = $(this).attr("id");
		var url = "/FoodItems/Details/" + id;
		// Perform the ajax call
		$.post(url,
			function (data) {
				//Fill div with results
				$("#plate").html(data);
			});
	});

	//get the orderItems count
	$.get("/Order/GetCountOfCurrentOrder", function (count) {
		viewModel.numberOfNoti(count);
	}, "json");

	$("#callWaiter").click(function () {
		$.get("/Order/CallAdmin", function (request) {
				toastr.info("We Are Coming To Help !");
	    }, "json");
	});
});