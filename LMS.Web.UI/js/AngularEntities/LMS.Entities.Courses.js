/// <reference path="../DTO/LMS.Entitybase.DTO.js" />
/// <reference path="LMS.AngularBuilder.js" />
lmsApp.controller('coursesController', ['$scope', 'lmsDataService', 'lmsGlobalService', '$routeParams', function ($scope, lmsDataService, lmsGlobalService, $routeParams) {
    $scope.Courses = [];
    $scope.Modules = [];
    $scope.Module = {};
    $scope.isSuccess = true;
    $scope.IsNewRecord = 1;
    $scope.ids = {};
    $scope.id = '';
    $scope.selectedModuleID = window.location.pathname.replace('/course/index/', '');
    $scope.selectedFunction = '';
    $scope.videoUrl = 'https://www.youtube.com/v/psgjh9jFyMs?fs=1&amp;autoplay=1';

    var APIURL = '/lmsapi/CourseAPI/';

    GetAllModules();
    GetAllCourses();

    $scope.loadFunctions = function (functionName) {
        $scope.selectedFunction = functionName;
    }

    $scope.loadVideos = function (vURL) {
        lmsGlobalService.ShowVideoBox($scope.videoUrl);
    }

    $scope.clear = function () {
        $scope.IsNewRecord = 1;
        $scope._id = '';
        $scope.Name = "";
        $scope.Description = "";
        $scope.ModuleID = "";
        $scope.CreatedBy = 0;
        $scope.CreatedOn = new Date();
        $scope.ModifiedBy = 0;
        $scope.ModifiedOn = new Date();
        $scope.IsActive = true;
    }
    $scope.showDescription = function (message) {
        lmsGlobalService.ShowFancyMessage('Course Description', message);
    };
    $scope.deleteCourse = function () {
        $scope.ids[0] = $scope.id;
        var promisePost = lmsDataService.DeleteItemFromRepository(APIURL + 'DeleteCourse', $scope.ids);
        promisePost.then(function (ack) {
            if (ack.data.Success) {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                GetAllCourses();
                $.fancybox.close();
            }
            else {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
            }
        });
    };
    $scope.saveCourse = function () {
        var Course = {
            _id: $scope._id,
            Name: $scope.Name,
            Description: $scope.Description,
            ModuleID: $scope.Module._id,
            CreatedBy: $scope.CreatedBy,
            CreatedOn: $scope.CreatedOn,
            ModifiedBy: $scope.ModifiedBy,
            ModifiedOn: $scope.ModifiedOn,
            IsActive: $scope.IsActive
        };
        //If the flag is 1 the it si new record
        if ($scope.IsNewRecord === 1) {
            if (Course.ModuleID == null) {
                lmsGlobalService.ShowMessageBox('alert', 'Select Module');
                return;
            }
            if (Course.Name == null) {
                lmsGlobalService.ShowMessageBox('alert', 'Enter Course Name');
                return;
            }
            var promisePost = lmsDataService.PostDataToRepository(APIURL + 'AddCourse', Course);
            promisePost.then(function (ack) {
                if (ack.data.Success) {
                    lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                    GetAllCourses();
                    $.fancybox.close();
                }
                else {
                    lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
                }
            });
        }
    };
    function GetAllCourses() {
        var getCoursesData = lmsDataService.GetAllDataFromRepository(APIURL + 'GetAllCourses');
        getCoursesData.then(function (ack) {
            if (ack.data.Success) {
                $scope.Courses = ack.data.Entities;
            }
            else {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
            }
        },
        function () {
            lmsGlobalService.ShowMessageBox('alert', 'Error Getting Data');
        });
    };
    function GetAllModules() {
        var getModulesData = lmsDataService.GetAllDataFromRepository('/lmsapi/ModulesAPI/GetAllModules');
        getModulesData.then(function (ack) {
            if (ack.data.Success) {
                $scope.Modules = ack.data.Entities;
            }
            else {
                lmsGlobalService.ShowMessageBox('alert', ack.data.Message);
            }
        },
        function () {
            lmsGlobalService.ShowMessageBox('alert', 'Error Getting Data');
        });
    };
}]);