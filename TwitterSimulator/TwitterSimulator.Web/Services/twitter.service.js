(function () {
    'use strict';

    angular.module('app').factory('TwitterService', TwitterService);

    TwitterService.$inject = ['$http'];
    function TwitterService($http) {
        var service = {};

        service.GetTweets = GetTweets;

        return service;

        function GetTweets() {
            return $http.get("http://localhost/TwitterSimulator/WebApi/GetTweets").then(handleSuccess, handleError);//handleError('Error getting all tweets'));
          }

        function handleSuccess(response) {
           
            return response.data;
        }

        function handleError(response) {
            return response.data.message + ' '  +  response.data.exceptionMessage;
        }
    }

})();