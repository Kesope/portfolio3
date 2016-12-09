define(['knockout', 'postman', 'config', 'toastr'], function (ko, postman, config, toastr) {
    return function (params) {
        var comment = ko.observable(params.comment);

        var submitComment = function () {
            postman.publish(config.events.submitComment, ko.toJS(comment));
            toastr.success("Successfully submitted!");
        }

        postman.subscribe(config.events.selectComment, function (c) {
            comment(c);
        });

        return {
            comment,
            submitComment
        };
    };
});
