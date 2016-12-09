define(['knockout', 'dataservice'], function (ko, dataService) {
    return function () {
        var comments = ko.observableArray([]);
       

        dataService.getComments(function (data) {
            comments(data);
        });

        return {
            comments
           
        };
    };
});
