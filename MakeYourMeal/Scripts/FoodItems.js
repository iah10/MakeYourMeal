$(function () {

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
});