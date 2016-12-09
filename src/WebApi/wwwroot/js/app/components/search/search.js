//define(['knockout', 'dataservice'], function (ko, dataService) {
//    return function () {
//        var searchString = ko.observable("");
//        var searchResult = ko.observableArray([]);
//        var view = ko.observable("default");

//        var callback = function (data) {
//            searchResult(data.result);
//        };
        
//        var searchPost = function () {
//            dataService.getSearchResult(searchString, callback);
//            view("searchresult");
//        };

//        return {
//            searchString,
//            searchPost,
//            searchResult,
//            view
//        };
//    };
//});