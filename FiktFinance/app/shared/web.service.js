
(function () {
    'use strict';
    function webService(webEndPoint, serviceRepository, $http) {
        var config = {};
        function getData() {
            var arr = 'името-на-контролерот/акцијата'; //currency/GetData;
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }
        var service = {
            getData: getData
        }
        return service;
    }
    angular.module('app.shared').factory('webService', webService);
    webService.$inject = ['webEndPoint', 'serviceRepository', '$http'];
}());