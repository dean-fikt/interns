
(function () {
    'use strict';

    function serviceRepository($q, $http, $window) {
        function fnxRequest(fn) {
            return function () {
                var args = arguments;

                return fn.apply(fn, args).then(
                    function (result) {
                        return result.response;
                    },
                    function (result) {
                        return $q.reject(result.response);
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
    angular.module('app', []).factory('serviceRepository', serviceRepository);
    serviceRepository.$inject = ['$q', '$http', '$window'];
})();