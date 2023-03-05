(function () {
    'use strict';

    angular
        .module('app')
        .factory('StudentService', Service);

    function Service($http, $localStorage, $rootScope) {
        var service = {};

        service.GetAllStudents = GetAllStudents;
        service.GetStudentById = GetStudentById;

        return service;

        function GetAllStudents(page, pageSize, searchString, callback) {
            $http.get($rootScope.linkApi + '/api/Student',
                {
                    headers: {
                        'Authorization': $http.defaults.headers.common.Authorization,
                        'Content-Type': 'application/json'
                    },
                    params: {
                        page: page,
                        pageSize: pageSize,
                        searchString: searchString,
                    }
                })
                .then(function (response) {

                    if (response.data) {

                        callback(response);
                    } else {

                        callback(false);
                    }
                })
                .catch(function (error) {
                    callback(error);
                });;
        }


        function GetStudentById(id, callback) {
            $http.get($rootScope.linkApi + '/api/Student/'+ id,
                {
                    headers: {
                        'Authorization': $http.defaults.headers.common.Authorization,
                        'Content-Type': 'application/json'
                    },
                })
                .then(function (response) {
                    if (response.data) {

                        callback(response);
                    } else {
                        callback(false);
                    }
                })
                .catch(function (error) {
                    callback(error);
                });;
        }

    
    }
})();