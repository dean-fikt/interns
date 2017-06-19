
(function () {
    'use strict';
    function webService(webEndPoint, serviceRepository, $http) {
        var config = {};

        function setUserData(u) {
            var arr = 'users/AddUser';
            data: u;
            return serviceRepository.post([webEndPoint.baseUrl, arr].join(''), u);
        }

        function getCustomerData() {
            var arr = 'customer/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

        function getDocTypeData() {
            var arr = 'documentType/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

        function getItemCategoryData() {
            var arr = 'itemCategory/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

        function getItemsData() {
            var arr = 'items/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

        function getPaymentMethodData() {
            var arr = 'paymentMethod/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

        function getCurrencyData() {
            var arr = 'currency/GetData';
            return serviceRepository.get([webEndPoint.baseUrl, arr].join(''), config);
        }

       

        var service = {
            getDocTypeData: getDocTypeData,
            getCustomerData: getCustomerData,
            getItemCategoryData: getItemCategoryData,
            getItemsData: getItemsData,
            getPaymentMethodData: getPaymentMethodData,
            getCurrencyData: getCurrencyData,
        }
        return service;
    }
    angular.module('app.shared').factory('webService', webService);
    webService.$inject = ['webEndPoint', 'serviceRepository', '$http'];
}());