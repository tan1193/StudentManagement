(function () {
    'use strict';

    angular
        .module('app')
        .controller('Student.IndexController', Controller);

    function Controller($scope, $location, StudentService, $window) {
        $scope.Students = []
        $scope.Student = {
            lastName: '',
            firstMidName: '',
            phone: '',
        };

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
                } else {
                    $scope.totalRow = 0;
                }
            });
        }

        $scope.btnSearchClick();

        $scope.GetStudentById = function (id) {
            StudentService.GetStudentById(id, function (result) {
                if (result.data) {
                    $scope.Student = result.data;
                } else {
                    alert('User not found');

                    setTimeout(function () {
                        $window.location.href = '/Student'
                    }, 300);
                }
            });
        }



        $scope.CreateStudent = function () {
            if (!$scope.Student.lastName) {
                alert("Last Name is required");
            }
            if (!$scope.Student.firstMidName) {
                alert("First Mid Name is required");
            }
            if (!$scope.Student.phone) {
                alert("Phone is required");
            }

            StudentService.CreateStudent($scope.Student.lastName, $scope.Student.firstMidName, $scope.Student.phone, function (result) {
                if (result.data) {
                    alert('Success');

                    setTimeout(function () {
                        $window.location.href = '/Student'
                    }, 300);
                } 
            });
        }


        $scope.DeleteStudent = function (id) {
            if (confirm("Are you sure?")) {
                StudentService.DeleteStudent(id, function (result) {
                    if (result.data) {
                        alert('Success');

                        setTimeout(function () {
                            $scope.btnSearchClick();
                        }, 300);
                    }
                });
            } 
        }


        $scope.InitCreate = function (id) {
            $scope.Student = {
                lastName: '',
                firstMidName: '',
                phone: '',
            };
        }



        $scope.pageChanged = function () {
            $scope.btnSearchClick();
        };
    }
})();