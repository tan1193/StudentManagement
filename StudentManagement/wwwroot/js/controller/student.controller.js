(function () {
    'use strict';

    angular
        .module('app')
        .controller('Student.IndexController', Controller);

    function Controller($scope, $location, StudentService, $window) {
        $scope.Students = []
        $scope.Student = {};

        $scope.searchString = ''
       
        $scope.filteredStudents = []
            , $scope.currentPage = 1
            , $scope.numPerPage = 10
            , $scope.maxSize = 5
            , $scope.totalRow = 10;

        $scope.btnSearchClick = function () {
            StudentService.GetAllStudents($scope.currentPage, 10, $scope.searchString, function (result) {
                if (result.data) {
                    $scope.Students = result.data.students;
                    $scope.totalRow = result.data.totalRow;
                    console.log($scope.Students);
                }
            });
        }

        $scope.btnSearchClick();


        $scope.GetStudentById = function (id) {
            StudentService.GetStudentById(id, function (result) {
                if (result.data) {
                    $scope.Student = result.data;
                }
            });
        }



        $scope.pageChanged = function () {
            $scope.btnSearchClick();
        };
    }
})();