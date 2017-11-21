(function () {
    'use strict';
    var context = angular.module('Ceiss', ['ngRoute']);
    context.config(function ($routeProvider) {
        $routeProvider
            .when("/registro",
            {
                templateUrl: '/UI/Templates/Register.html'
            })
            .otherwise({ redirectTo: '/404' });
    });
})();

var myApp = angular.module('', []);

myApp.controller('DoubleController', ['$scope', function ($scope) {
    $scope.double = function (value) { return value * 2; };
}]);
