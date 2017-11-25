(function () {
    'use strict';
    var context = angular.module('Ceiss', ['ngRoute']);
    context.config(function ($routeProvider, $locationProvider) {
        $routeProvider
            .when("/register",
            {
                templateUrl: '/UI/Templates/Register.html'
            })
            .when("/",
            {
                templateUrl: '/UI/Templates/Home.html'
            })
            .when("/login",
            {
                templateUrl: '/UI/Templates/Login.html'
            })
            .otherwise({ redirectTo: '/404' });
        $locationProvider.html5Mode(true);
    });
})();

var myApp = angular.module('', []);

myApp.controller('DoubleController', ['$scope', function ($scope) {
    $scope.double = function (value) { return value * 2; };
}]);
