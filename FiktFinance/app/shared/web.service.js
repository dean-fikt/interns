
(function () {
    'use strict';
    function webService(webEndPoint, serviceRepository, $http) {
        var config = {};
        function getData() {
            var arr = '/currency/GetData'; //currency/GetData;
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }
        var service = {
            getData: getData
        }
        return service;
    }
    angular.module('app', []).factory('webService', webService);
    webService.$inject = ['webEndPoint', 'serviceRepository', '$http'];
}());