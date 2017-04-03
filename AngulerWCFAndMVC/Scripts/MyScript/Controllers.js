/// <reference path="../angular.min.js" />  
/// <reference path="Modules.js" />  
/// <reference path="Services.js" />  

//app.controller("CRUD_AngularJs_RESTController", function ($scope, CRUD_AngularJs_RESTService) {

//    $scope.OperType = 1;
//    //1 Mean New Entry  

//    GetAllRecords();
//    //To Get All Records  
//    function GetAllRecords() {
//        debugger;
//        //getAllUser = function () {
//        //    debugger;
//        //    return $http.get("http://localhost:61218/UserService.svc/GetAllUser");
//        //};

//        var promiseGet = $http.get("http://localhost:61218/UserService.svc/GetAllUser");
//        promiseGet.then(function (pl) { $scope.Users = pl.data },
//              function (errorPl) {
//                  $log.error('Some Error in Getting Records.', errorPl);
//              });
//    }

//    //To Clear all input controls.  
//    function ClearModels() {
//        $scope.OperType = 1;
//        $scope.Id = "";
//        $scope.Name = "";
//        $scope.Address = "";
//        $scope.City = "";
//    }

//    //To Create new record and Edit an existing Record.  
//    $scope.save = function () {
//        var User = {
//            Name: $scope.Name,
//            Address: $scope.Address,
//            City: $scope.City
//        };
//        if ($scope.OperType === 1) {
//            var promisePost = CRUD_AngularJs_RESTService.post(User);
//            promisePost.then(function (pl) {
//                $scope.Id = pl.data.Id;
//                GetAllRecords();

//                ClearModels();
//            }, function (err) {
//                console.log("Some error Occured" + err);
//            });
//        } else {
//            //Edit the record      
//            debugger;
//            User.Id = $scope.Id;
//            var promisePut = CRUD_AngularJs_RESTService.put($scope.Id, User);
//            promisePut.then(function (pl) {
//                $scope.Message = "Users Updated Successfuly";
//                GetAllRecords();
//                ClearModels();
//            }, function (err) {
//                console.log("Some Error Occured." + err);
//            });
//        }
//    };

//    //To Get Student Detail on the Base of Student ID  
//    $scope.get = function (User) {
//        var promiseGetSingle = CRUD_AngularJs_RESTService.get(User.Id);
//        promiseGetSingle.then(function (pl) {
//            var res = pl.data;
//            $scope.Id = res.Id;
//            $scope.Name = res.Name;
//            $scope.Address = res.Address;
//            $scope.City = res.City;
//            $scope.OperType = 0;
//        },
//                  function (errorPl) {
//                      console.log('Some Error in Getting Details', errorPl);
//                  });
//    }

//    //To Delete Record  
//    $scope.delete = function (User) {
//        var promiseDelete = CRUD_AngularJs_RESTService.delete(User.Id);
//        promiseDelete.then(function (pl) {
//            $scope.Message = "Student Deleted Successfuly";
//            GetAllRecords();
//            ClearModels();
//        }, function (err) {
//            console.log("Some Error Occured." + err);
//        });
//    }
//});


myApp.controller('myController', function ($scope, crudAJService) {
    GetAllUsers();
    //To Get all book records
    function GetAllUsers() {
        debugger;
        var getUsersData = crudAJService.getUsers();
        getUsersData.then(function (Users) {
            $scope.Users = Users.data;
        }, function () {
            alert('Error in getting Users records');
        });
    }
});