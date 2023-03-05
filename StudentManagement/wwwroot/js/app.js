(function () {
    'use strict';
    angular
        .module('app', ['ui.router', 'ngMessages', 'ngStorage', 'ngAnimate', 'ngSanitize', 'ui.bootstrap'])
        .config(config)
        .run(run);

    function config($stateProvider, $urlRouterProvider, $locationProvider) {
       

        // enable HTML5 mode
        $locationProvider.html5Mode({
            enabled: true,
            requireBase: true
        });


        // default route
        $urlRouterProvider.otherwise('/');
       
        // app routes
        $stateProvider
            .state('home', {
                url: '/',
                controller: 'Home.IndexController',
                controllerAs: 'vm'
            })
            .state('login', {
                url: '/login',
                controller: 'Login.IndexController',
                controllerAs: 'vm'
            })
            .state('student', {
                url: '/student',
                controller: 'Student.IndexController',
                controllerAs: 'vm'
            });
    }

    function run($rootScope, $http, $location, $localStorage, $window ) {
        $rootScope.linkApi = 'https://localhost:7034'

        // keep user logged in after page refresh

        if ($localStorage.currentUser) {
            $http.defaults.headers.common.Authorization = 'Bearer ' + $localStorage.currentUser.token;
        }

        // redirect to login page if not logged in and trying to access a restricted page
        $rootScope.$on('$locationChangeStart', function (event, next, current) {
            var publicPages = ['/login'];
            var restrictedPage = publicPages.indexOf($location.path()) === -1;
            if (restrictedPage && !$localStorage.currentUser) {
                $window.location.href = '/login';
            } 
            else if ($window.location.href != next) {
                $window.location.href = next;
            }
        });

      
    }
})();