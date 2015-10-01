(function () {
    'use strict';

    angular.module('app').controller('HomeController', HomeController);
    HomeController.$inject = ['TwitterService'];

    function HomeController(TwitterService) {
        var vm = this;
        vm.UserTweets = [];
        vm.Error = '';

        vm.GetTweets = GetTweets;

        initController();

        function initController() {
            GetTweets();
        }

        function GetTweets() {

            TwitterService.GetTweets()
                .then(function (results) {
                    
                    if($.isArray(results))
                    {
                        vm.UserTweets = results;
                    }
                    else
                    {
                        vm.Error = results;
                    }
                });
         };
    }

})();