jscroller
=========

##jscroller - a customizable jquery infinite scroller plugin
 
####Parameters

1.	Name: limit
	Default value: 10
	Description: The quantity of items to retrieve each time you 'scroll' or click in 'load more' button.
 
2.	Name: onSuccessCallback  
	Default value: function (row, container) { }  
	Description: The function called when each row is returned.  
 
	The return object must hold some attributes like 'success', 'total', 'data', 'message'  
	Each data record is a row passed as parameter to your onSuccessCallback  
	The container is the list reference  
 
	Example: new { success = true, total = TOTAL_LENGTH, data = PARTIAL_ROWS, message = string.Empty };   
 
3.	Name: onErrorCallback  
	Default value: function (container, thrownError) { alert('An error occurred while trying to retrive data from store'); }  
	Description: The function called when a error is returned.  
 
4.	Name: onTimeoutCallback  
	Default value: function () { }  
	Description: The function called when a timeout occurs.
 
5.	Name: timeout
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
 
####Example
 
    var onSuccess = function (row, container) {
		container.append('<div>' + row.OrderNumber + '</div>'));
    }
 	
	$('#list').jScroller("/Orders/GetItems", {
        limit: 15,
        onSuccessCallback: onSuccess
    });

#####In ASP.NET MVC you could do something like:  
 
    [HttpPost]
    public JsonResult GetItems(int start, int limit)
    {
        var itemsLength = GetItems().Count();  
        var rows = GetItems().Skip(start).Take(limit).ToList();  
        var result = new { success = true, total = itemsLength, data = rows, message = string.Empty };  
        return Json(resultado);  
    }