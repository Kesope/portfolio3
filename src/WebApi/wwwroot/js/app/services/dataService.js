define(['jquery'], function ($) {
    

    var getComments = function (callback) {
        var url = "api/comments";
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getPosts = function (callback) {
        var url = "api/posts";
        $.getJSON(url, function (data) {
            callback(data);
        });
    }

    var getSearchResult = function (searchString,callback) {
        
        $.getJSON("http://localhost:15616/api/search?=" + searchString(), function (data) {
            callback(data);
        });
    }

    return {
        getComments,
        getPosts,
        getSearchResult
    };
});




        