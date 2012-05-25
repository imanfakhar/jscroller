/// <reference path="jquery-1.7.1.min.js" />

/**
* jScroller Plugin 0.1.4
*
* Copyright (c) 2012  Renato Saito (renato.saito at live.com)
*
* Dual licensed under the MIT and GPL licenses:
*   http://www.opensource.org/licenses/mit-license.php
*   http://www.gnu.org/licenses/gpl.html
*/

(function ($) {
    jQuery.fn.jScroller = function (store, parameters) {
        var defaults = {
            limit: 10,
            onSuccessCallback: function (row, container) { },
            onErrorCallback: function (thrownError) { alert('An error occurred while trying to retrive data from store'); },
            onTimeoutCallback: function () { },
            timeout: 6 * 1000,
            loadingButtonText: 'Loading...',
            loadMoreButtonText: 'Load more',
            fullListText: 'There is no more items to show',
            extraParams: null
        };
        var options = jQuery.extend(defaults, parameters);
        var list = jQuery(this),
            end = false,
            loadingByScroll = false;

        var ajaxParameters;

        if (options.extraParams == null) {
            ajaxParameters = {
                start: 0,
                limit: options.limit
            };
        }
        else {
            ajaxParameters = {
                start: 0,
                limit: options.limit,
                extraParams: options.extraParams
            };
        }

        list.html('');

        function loadItems() {
            preLoad();
            jQuery.ajax({
                url: store,
                type: "POST",
                data: ajaxParameters,
                timeout: options.timeout,
                success: function (response) {
                    list.find("#jscroll-loading").remove();
                    if (response.Success === false) {
                        options.onErrorCallback(list, response.Message);
                        return;
                    }
                    for (var i = 0; i < response.data.length; i++) {
                        if (end == false) {
                            options.onSuccessCallback(response.data[i], list);
                        }
                    }
                    if (loadingByScroll === false) {
                        if (end == false) {
                            list.append('<div class="row"><a class="badge jscroll-loadmore">' + options.loadMoreButtonText + '</a></div>');
                        }
                    }

                    ajaxParameters.start = ajaxParameters.start + options.limit;

                    if (ajaxParameters.start >= response.total) {
                        end = true;
                        list.find('#jscroll-fulllist').remove();
                        list.append('<div class="row" id="jscroll-fulllist"><a class="badge">' + options.fullListText + '</a></div>');
                    }
                },
                error: function (xhr, ajaxOptions, thrownError) {
                    if (thrownError == 'timeout') {
                        options.onTimeoutCallback();
                        options.timeout = options.timeout + (1 * 1000);
                        loadItems();
                    }
                    else {
                        options.onErrorCallback(thrownError);
                    }
                }
            });
        }
        function startHandleLoadMoreButton() {
            list.on("click", ".jscroll-loadmore", function () {
                loadItems();
                jQuery(this).parent("div").remove();
            });
        }
        function preLoad() {
            if (list.find("#jscroll-loading").length === 0) {
                list.find(".jscroll-loadmore").parent("div").remove();
                list.append('<a class="badge" id="jscroll-loading">' + options.loadingButtonText + '</a>');
            }
        }
        jQuery(window).scroll(function () {
            var window = jQuery(this);
            if (window.scrollTop() === jQuery(document).height() - window.height()) {
                if (end) {
                    return false;
                } else {
                    loadingByScroll = true;
                    loadItems();
                }
            }
            return false;
        });
        jQuery(document).ready(function () {
            startHandleLoadMoreButton();
            loadItems();
        });
    };
})(jQuery);