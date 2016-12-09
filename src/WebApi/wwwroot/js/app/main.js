
(function (undefined) {

    require.config({
        baseUrl: "js",
        paths: {
            "jquery": "lib/jquery/dist/jquery.min",
            "knockout": "lib/knockout/dist/knockout",
            "text": "lib/requirejs-text/text",
            "bootstrap": "lib/bootstrap/dist/js/bootstrap.min",
            "toastr": "lib/toastr/toastr.min",

            "dataservice": "app/services/dataService",
            "postman": "app/services/postman",
            "config": "app/config"
        },
        shim: {
            "bootstrap": { "deps": ['jquery'] }
        }
    });

    require(['knockout'], function (ko) {
        ko.components.register("my-app", {
            viewModel: { require: 'app/components/app/app' },
            template: { require: 'text!app/components/app/appView.html' }
        });

        ko.components.register("comment-list", {
            viewModel: { require: 'app/components/comment/commentList' },
            template: { require: 'text!app/components/comment/commentListView.html' }
        });

        ko.components.register("comment-details", {
            viewModel: { require: 'app/components/comment/commentDetails' },
            template: { require: 'text!app/components/comment/commentDetailsView.html' }
        });

        ko.components.register("post-list", {
            viewModel: { require: 'app/components/post/postList' },
            template: { require: 'text!app/components/post/postListView.html' }
        });
        ko.components.register("history-list", {
            viewModel: { require: 'app/components/history/historyList' },
            template: { require: 'text!app/components/history/historyListView.html' }
        });

       /*ko.components.register("search-post", {
            viewModel: { require: 'app/components/search/search' },
            template: { require: 'text!app/components/search/searchView.html' }
        });*/
    });

    require(['knockout'], function (ko) {
        ko.applyBindings();
    });

})();