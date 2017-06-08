
(function () {
    'use strict';

    function ctrlDocumentType( $rootScope, $location, webService) {
        var vm = this;

        function activate() {
            getDocumentTypeData();
            
        }
        
        function getDocumentTypeData() {
            vm.promise = webService.getDocTypeData();
            vm.promise.then(function (response) {
                if (response.Status === 0) {
                    console.log("Server error");
                    //Туке се хендла еррор значи дека на сервер нешто се случило 
                }
                vm.docTypeCollection = response.documentTypeList;
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
            docTypeCollection: [],
    });
        //
        activate();
    }

    angular.module('app').controller('ctrlDocumentType', ctrlDocumentType);
    ctrlDocumentType.$inject = [ '$rootScope', '$location', 'webService'];
})()