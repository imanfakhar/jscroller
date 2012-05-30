jScroller
=========

##jScroller - A lightweight infinite-scroller jQuery plug-in
##current version: 0.1.7

###now available @ NuGet https://nuget.org/packages/jScroller

####New features

1.	Now you can pass extra parameters to an endpoint through the parameter 'extraParams'

2.	Now you can auto-increase the timeOut value every time a timeOut ocurrs.
	To activate this you need to pass the parameters: 'retryOnTimeOut' and 'autoIncreaseTimeOut'

####Parameters

1.	Name: numberOfRowsToRetrieve
	Default value: 10
	Description: The quantity of items to retrieve each time you 'scroll' or click in 'load more' button.
 
2.	Name: onSuccessCallback  
	Default value: function (row, container) { }  
	Description: The function called when each row is returned.  
 
	The return object must hold some attributes like 'success', 'total', 'data', 'message'  
	Each data record is a row passed as parameter to your onSuccessCallback  
	The container is the list reference  

####Example	
	return new { success = true, total = TOTAL_LENGTH, data = ROWS, message = string.Empty }; 
#### 
 
3.	Name: onErrorCallback  
	Default value: function (container, thrownError) { alert('An error occurred while trying to retrive data from store'); }  
	Description: The function called when a error is returned.  
 
4.	Name: onTimeOutCallback  
	Default value: function () { }  
	Description: The function called when a timeout occurs.
 
5.	Name: timeOut
	Default value: 3000ms
	Description: The timeout value in milliseconds
 
6.	Name: loadingButtonText
	Default value: 'Loading...'
	Description: self explanatory
 
7.	Name: loadMoreButtonText
	Default value: 'Load more'
	Description: self explanatory
 	
8.	Name: fullListText
	Default value: 'There is no more items to show'
	Description: The message added if you reach the end of the list.

9.	Name: ajaxType
	Default value: 'POST'
	Description: The type of ajax 'GET' or 'POST'
	
10. Name: autoIncreaseTimeOut
	Default value: 1000
	Description: If retryOnTimeOut is active, when a timeOut ocurrs the value of timeOut will auto-increase

11. retryOnTimeOut
	Default value: false
	Description: self explanatory
 
####Example
 
    var onSuccess = function (row, container) {
		container.append('<div>' + row.OrderNumber + '</div>'));
    }
 	
	$('#list').jScroller("/Orders/GetItems", {
        numberOfRowsToRetrieve: 15,
        onSuccessCallback: onSuccess
    });
 
#####In ASP.NET MVC you may do something like:  

	[HttpPost]
	public JsonResult GetItems(int start, int numberOfRowsToRetrieve)
	{
		var itemsLength = GetItems().Count();
		var rows = GetItems().Skip(start).Take(numberOfRowsToRetrieve).ToList();
		var result = new { success = true, total = itemsLength, data = rows, message = string.Empty };
		return Json(result);
	}