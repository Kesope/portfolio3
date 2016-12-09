define(['knockout', 'dataservice'], function (ko, dataService) {
        return function () {
            var posts = ko.observableArray([]);
              dataService.getPosts(function (data) {
                posts(data);
            });

            return {
                posts
                
            };
        };
    });