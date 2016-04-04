/// <reference path="~/Scripts/angular.min.js" />
var lmsApp = angular.module('lmsApp', ['ngRoute']);

lmsApp.factory('lmsDataService', ['$http', function ($http) {
    var lmsDataService = {
        GetAllDataFromRepository: function (URL) {
            return $http.get(URL);
        },
        GetDataFromRepository: function (URL, inputParameter) {
            var request = $http({
                method: "get",
                url: URL,
                data: inputParameter
            });
            return request;
        },
        PostDataToRepository: function (URL, inputParameter) {
            var request = $http({
                method: "post",
                url: URL,
                data: inputParameter
            });
            return request;
        },
        DeleteItemFromRepository: function (URL, ids) {
            var request = $http({
                method: "get",
                url: URL,
                data: { 'ids': ids }
            });
            return request;
        }
    };
    return lmsDataService;
}]).factory('lmsGlobalService', function () {
    var lmsGlobalService = {
        ShowMessageBox: function (title, message) {
            $.jGrowl(message, {
                position: 'top-right',
                life: 5000,
                easing: 'swing'
            });
        },
        ShowFancyBox: function (layerID) {
            $.fancybox({
                'content': $(layerID).html(),
                'Width': 'auto',
                'openEffect': 'elastic',
                'closeEffect': 'elastic',
                'openSpeed': 'slow',
                'closeSpeed': 'slow'
            });
        },
        ShowVideoBox:function(vURL){
            $.fancybox({
                'href': vURL,
                'type': 'swf',
                'minWidth': '400',
                'minHeight': '600',
                'openEffect': 'elastic',
                'closeEffect': 'elastic',
                'openSpeed': 'slow',
                'closeSpeed': 'slow',
                'titleShow': 'true',
                'title': 'Course Video',
                'autoScale': 'true'
            });
        },
        ShowFancyMessage: function (title, message) {
            $.fancybox({
                'content': message,
                'minWidth': '300',
                'openEffect': 'elastic',
                'closeEffect': 'elastic',
                'openSpeed': 'slow',
                'closeSpeed': 'slow',
                'titleShow': 'true',
                'title': title,
                'autoScale': 'true'
            });
        }
    };
    return lmsGlobalService;
}).directive('fancybox', function ($compile) {
    return {
        restrict: 'A',
        replace: false,
        link: function ($scope, element, attrs) {
            $scope.open_fancybox = function () {
                var el = angular.element(element.html()),
                compiled = $compile(el);
                $.fancybox.open(el);
                compiled($scope);
            };
        }
    };
}).directive('deletefancybox', function ($compile) {
    return {
        restrict: 'A',
        replace: false,
        link: function ($scope, element, attrs) {
            $scope.delete_fancybox = function (id) {
                $scope.id = id;
                var el = angular.element(element.html()),
                compiled = $compile(el);
                $.fancybox.open(el);
                compiled($scope);
            };
        }
    };
});