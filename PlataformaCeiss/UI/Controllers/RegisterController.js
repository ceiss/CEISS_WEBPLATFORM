(function () {
    'use strict';
    angular
        .module('Ceiss')
        .controller('RegisterController', controller);

    controller.$inject = ['$location', '$scope', '$http'];

    function controller($location, $scope, $http) {
        /* jshint validthis:true */

        $scope.NewStudent = {


        };
        $http.get('/api/GetCareers').then(
            function (r) {
                $scope.careers = r.data;
            }, function (r) {
            })

        activate();
        $scope.register = function () {
            $http.post('/api/Students/CreateStudent', $scope.NewStudent).then(() => {
                alert('Registro Exitoso');
            }, () => {
                alert('Ha ocurrido un error.');
            })
        }
        function activate() { }
    }
})();
