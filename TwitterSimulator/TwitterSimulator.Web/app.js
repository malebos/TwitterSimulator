(function () {
    'use strict';

    angular
        .module('app', ['ngRoute'])
        .config(config)
        .run(run);

    config.$inject = ['$routeProvider', '$locationProvider'];
    function config($routeProvider, $locationProvider) {
        $routeProvider
             
            .when('/home', {
                controller: 'HomeController',
                templateUrl: 'Views/TweeterFeeds.html',
                controllerAs: 'vm'
            })
            .otherwise({ redirectTo: '/home' });
    }

    run.$inject = ['$rootScope', '$location',  '$http'];
    function run($rootScope, $location, $http) {

        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            // redirect to home page if trying to access a restricted page
            var restrictedPage = $.inArray($location.path(), ['/index.html']) === -1;
            if (restrictedPage) {
                $location.path('/home');
            }
        });
    }

})();