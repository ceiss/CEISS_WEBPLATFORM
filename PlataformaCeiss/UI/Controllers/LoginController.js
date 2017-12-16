(function () {
    'use strict';
    angular
        .module('Ceiss')
        .controller('LoginController', controller);

    controller.$inject = ['$location', '$scope', '$http'];

    function controller($location, $scope, $http) {
        $scope.test = function () {
            $http.get('/api/Students/test');
        }
        $scope.login = function () {
            $http.post('/api/Students/Login', {
                email: $scope.email,
                password: $scope.password

            }).then((r) => {
                var token = r.data;
                $http.defaults.headers.common.Authorization = token;

            }, () => {
                alert('Ha ocurrido un error.');
            })
        }
    }
})();
