
(function () {
    'use strict';

    function ctrlDocumentType( $rootScope, $location, webService) {
        var vm = this;

        function activate() {
            getDocumentTypeData();
            getCustomerData();
            getCategoryData();
            getCurrencyData();
            getPaymentMethodData();
            getItemsData();    
        }

        function getCurrencyData() {
            vm.promise = webService.getCurrencyData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                }
                vm.currencyCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }

        function getPaymentMethodData() {
            vm.promise = webService.getPaymentMethodData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                }
                vm.payMethodCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }
        
        function getDocumentTypeData() {
            vm.promise = webService.getDocTypeData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                    //Туке се хендла еррор значи дека на сервер нешто се случило 
                }
                vm.docTypeCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }

        function getCustomerData() {
            vm.promise = webService.getCustomerData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                }
                vm.customerCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }

        function getCategoryData() {
            vm.promise = webService.getItemCategoryData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                }
                vm.itemCategoryCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }

        function getItemsData() {
            vm.promise = webService.getItemsData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                }
                vm.itemsCollection = response;
            }, function () {
                $timeout(function () {
                    ngToast.create({
                        className: 'danger',
                        content: $translate.instant('RequestFailed')
                    });
                }, 0);
            });
        }

        
        

        angular.extend(vm, {
            promise: null,
            selectedDocType: null,
            selectedCustomer: null,
            selectedItemCategory: null,
            selectedItem: null,
            selectedPayMethdod: null,
            selectedCurrency: null,
            itemsCollection: [],
            itemCategoryCollection: [],
            docTypeCollection: [],
            customerCollection: [],
            payMethodCollection: [],
            currencyCollection: [],
    });
        //
        activate();
    }

    angular.module('app').controller('ctrlDocumentType', ctrlDocumentType);
    ctrlDocumentType.$inject = [ '$rootScope', '$location', 'webService'];
})()