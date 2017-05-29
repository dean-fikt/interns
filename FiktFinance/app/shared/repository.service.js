
(function () {
    'use strict';

    function serviceRepository($q, $http, $window) {
        function fnxRequest(fn) {
            return function () {
                var args = arguments;

                return fn.apply(fn, args).then(
                    function (result) {
                        return result.data;
                    },
                    function (result) {
                        return $q.reject(result.data);
                    });
            };
        }
        function post(url, data) {
            return $.ajax({
                url: url,
                type: "POST",
                data: data
            });
        }
        return {
            get: fnxRequest($http.get),
            post: post,
            delete: fnxRequest($http.delete)
        };
    }
    angular.module('app.shared').factory('serviceRepository', serviceRepository);
    serviceRepository.$inject = ['$q', '$http', '$window'];
})();