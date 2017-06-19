(function () {
    'use strict';
    function ctrlSetDataNew($rootScope, $location, webService) {
        var vm = this;
        $rootScope.selectedFirstName = "";
        $rootScope.selectedLastName = "";
        $rootScope.selectedemail = "";
        $rootScope.selectedpassword = "";
        var u = {
            FirstName: $rootScope.selectedFirstName,
            LastName: $rootScope.selectedLastName,
            email: $rootScope.selectedemail,
            password: $rootScope.selectedpassword
        };

        $rootScope.submit = function () {
            vm.promise = webService.setUserData(u);
            vm.promise.then(function () {
                console.log("Something");
            })
        }
    }
    angular.module('app').controller('ctrlSetDataNew', ctrlSetDataNew);
    ctrlSetDataNew.$inject = ['$rootScope', '$location', 'webService'];
})()