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
                debugger;
                $scope.careers = r.data;
            }, function (r) {
            })

        activate();
        $scope.register = function () {
            $http.post('/api/Students/CreateStudent', $scope.NewStudent).then(() => {
                debugger;
            }, () => {

                })
        }
        function activate() { }
    }
})();
