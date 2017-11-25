(function () {
    'use strict';
    angular
        .module('Ceiss')
        .factory('API', factory);

    factory.$inject = ['$http'];

    function factory($http) {
        var service = {
            Students: {
                getStudentsByFirstName: (name) => {
                    return $http.get('/api/getStudentsByFirstName/'+name);
                }
            },
            Careers: {
                GetCarreers: () => {
                    return $http({
                        Method: 'GET',
                        cache : true,

                    });
                }
            },
            Articles: {
                GetArticles: (page) => {
                    if (Number.isInteger(page)) {
                        return $http({
                            method: 'GET',
                            url: `/api/Articles/GetArticles/${page}`,
                            cache: true
                        });
                    } 
                }
            }
        };

        return service;

    }
})();