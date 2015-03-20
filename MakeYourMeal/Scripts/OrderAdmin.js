$(function() {

	var orderHub = $.connection.orderHub;
	orderHub.client.orderReceived = function() {
		alert("It Worked on Admin");
	}
	$.connection.hub.start();
});