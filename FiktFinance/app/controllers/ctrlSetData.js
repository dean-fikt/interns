
(function () {
    'use strict';

    function ctrlSetData($rootScope, $location, webService) {
        var vm = this;

        function activate() {
            setUserData();
        }

        function setUserData() {
            var u = {
                FirstName: selectedFirstName,
                LastName: selectedLastName,
                email: selectedemail,
                password: selectedpassword
            };

            vm.promise = webService.setUserData(u);

        }

            angular.extend(vm, {
            promise: null,          
            selectedFirstName: null,
            selectedLastName: null,
            selectedemail: null,
            selectedpassword:null,
                            
        });
        //
        activate();
    }

    angular.module('app').controller('ctrlSetData', ctrlSetData);
    ctrlSetData.$inject = ['$rootScope', '$location', 'webService'];
})()