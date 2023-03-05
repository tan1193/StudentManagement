(function () {
    'use strict';

    angular
        .module('app')
        .factory('StudentService', Service);

    function Service($http, $localStorage, $rootScope) {
        var service = {};

        service.GetAllStudents = GetAllStudents;
        service.GetStudentById = GetStudentById;
        service.CreateStudent = CreateStudent;
        service.DeleteStudent = DeleteStudent;

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

        function CreateStudent(lastName, firstMidName, phone , callback) {
            $http.post($rootScope.linkApi + '/api/Student', { LastName: lastName, FirstMidName: firstMidName, Phone: phone } ,
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


        function DeleteStudent(id, callback) {
            $http.delete($rootScope.linkApi + '/api/Student/' + id, 
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