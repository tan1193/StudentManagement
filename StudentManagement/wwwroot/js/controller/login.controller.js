(function () {
    'use strict';

    angular
        .module('app')
        .controller('Login.IndexController', Controller);

    function Controller($scope, $location, AuthenticationService, $window) {
   
        $scope.loading = false;
        $scope.error = '';


        initController();

        function initController() {
          
        };


        $scope.btnLoginClick = function () {
            if (this.form.$valid) {
                $scope.loading = true;
                AuthenticationService.Login(this.vm.username, this.vm.password, function (result) {
                    if (result === true) {
                        setTimeout(function () {
                            $window.location.href = '/'
                        }, 300);
                      
                    } else {
                        $scope.error = 'Username or password is incorrect';
                        $scope.loading = false;
                    }
                });
            }
        }
    }
})();