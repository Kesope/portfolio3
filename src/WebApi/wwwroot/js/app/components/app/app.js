define(['knockout', 'postman', 'config', 'dataservice'], function (ko, postman, config, dataService) {
    return function () {
        var menuItems = [
            //{ title: config.menuItems.searchPost, component: 'search-post' },
            //{ title: config.menuItems.comments, component: 'comment-list'}, 
            { title: config.menuItems.posts, component: 'post-list' },
            { title: config.menuItems.history, component: 'history-list' }
        ];

        var searchString = ko.observable("");
        var searchResult = ko.observableArray([]);
        var view = ko.observable("default");

        var callback = function (data) {
            searchResult(data.result);
        };

        var searchPost = function () {
            dataService.getSearchResult(searchString, callback);
            view("searchresult");
        };

        var currentComponent = ko.observable();
        var selectedMenu = ko.observable();

        var selectMenu = function (menu) {
            selectedMenu(menu);
            currentComponent(menu.component);
        }

        var isSelected = function (menu) {
            return menu === selectedMenu();
        }

        postman.subscribe(config.events.changeMenu, function (title) {
            for (var i = 0; i < menuItems.length; i++) {
                if (menuItems[i].title === title) {
                    selectMenu(menuItems[i]);
                    break;
                }
            }
        });

        selectMenu(menuItems[0]);



        return {
            menuItems,
            currentComponent,
            selectMenu,
            isSelected,
            searchString,
            searchPost,
            searchResult,
            view

        }
    }
});