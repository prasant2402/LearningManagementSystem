/// <reference path="../DTO/LMS.Entitybase.DTO.js" />
/// <reference path="LMS.AngularBuilder.js" />
lmsApp.controller('modulesController', ['$scope', 'lmsDataService', 'lmsGlobalService', function ($scope, lmsDataService, lmsGlobalService) {
    $scope.Modules = [];
    $scope.message = 'Test Message';
    $scope.isSuccess = true;
    $scope.IsNewRecord = 1;
    $scope.ids = {};
    $scope.id = '';

    var APIURL = '/lmsapi/ModulesAPI/';

    GetAllModules();

    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope._id = '';
        $scope.Name = "";
        $scope.Description = "";
        $scope.Image = "";
        $scope.CreatedBy = 0;
        $scope.CreatedOn = new Date();
        $scope.ModifiedBy = 0;
        $scope.ModifiedOn = new Date();
        $scope.IsActive = true;
    }
    $scope.loadCreateNewLayer = function () {
        lmsGlobalService.ShowFancyBox('#divCreateNewModule');
    };
    $scope.showDescription = function (message) {
        lmsGlobalService.ShowFancyMessage('Module Description', message);
    };
    $scope.deleteModule = function () {
        $scope.ids[0] = $scope.id;
        var promisePost = lmsDataService.DeleteItemFromRepository(APIURL + 'DeleteModule', $scope.ids);
        promisePost.then(function (ack) {
            if (ack.data.Success) {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                GetAllModules();
                $.fancybox.close();
            }
            else {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
            }
        });
    };
    $scope.saveModule = function () {
        var Module = {
            _id: $scope._id,
            Name: $scope.Name,
            Description: $scope.Description,
            Image: $scope.Image,
            CreatedBy: $scope.CreatedBy,
            CreatedOn: $scope.CreatedOn,
            ModifiedBy: $scope.ModifiedBy,
            ModifiedOn: $scope.ModifiedOn,
            IsActive: $scope.IsActive
        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            var promisePost = lmsDataService.PostDataToRepository(APIURL + 'AddModule', Module);
            promisePost.then(function (ack) {
                if (ack.data.Success) {
                    lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                    GetAllModules();
                    $.fancybox.close();
                }
                else {
                    lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                }
            });
        }
    };


    function GetAllModules() {
        var getModulesData = lmsDataService.GetAllDataFromRepository(APIURL + 'GetAllModules');
        getModulesData.then(function (ack) {
            if (ack.data.Success) {
                $scope.Modules = ack.data.Entities;
            }
            else
            {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
            }
        },
        function () {
            lmsGlobalService.ShowMessageBox('alert', 'Error Getting Data');
        });
    }
}]);