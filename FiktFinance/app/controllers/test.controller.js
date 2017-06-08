
(function () {
    'use strict';

    function testController( $rootScope, $location) {
        var vm = this;

        function activate() {
            vm.locationsCollection.push({ Id: 1, Name: 'Document 1' });
            vm.locationsCollection.push({ Id: 1, Name: 'Document 2' });
        }
        
        //function getProjectTasks() {
        //    vm.promise = webService.getData();
        //    vm.promise.then(function (response) {
        //        if (response.Status === 0) {
        //            //Туке се хендла еррор значи дека на сервер нешто се случило погрешно
        //            return;
        //        }
        //        var result = response.Data; //Дата треба да истиот (и по име) објект што го враќате од сервер 
        //        //ресулт го користите за да прикажите податоци на вјуто. Ако враќате ареј свртете го во луп и потоа прикажете тоа што треба
        //    }, function () {
        //        //Тука се хендла ако пукни риквестот приме 404 или 500
        //    });
        //}

        angular.extend(vm, {
            //getProjectTasks: getProjectTasks,
            //promise: null,
            selectedDocType: null,
            locationsCollection: []
        });
        //
        activate();
    }

    angular.module('app').controller('testController', testController);
    testController.$inject = [ '$rootScope', '$location'];
})()