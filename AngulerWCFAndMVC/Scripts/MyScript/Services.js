/// <reference path="../angular.min.js" />
/// <reference path="Modules.js" />  

//app.service("CRUD_AngularJs_RESTService", function ($http) {
//    //Create new record  
//    this.post = function (UserTable) {
//        var request = $http({
//            method: "post",
//            url: "http://localhost:61218/UserService.svc/AddNewUser",
//            data: UserTable
//        });
//        return request;
//    }

//    //Update the Record  
//    this.put = function (Id, UserTable) {
//        debugger;
//        var request = $http({
//            method: "put",
//            url: "http://localhost:61218/UserService.svc/UpdateUser",
//            data: UserTable
//        });
//        return request;
//    }

//    this.getAllUser = function () {
//        debugger;
//        return $http.get("http://localhost:61218/UserService.svc/GetAllUser");
//    };

//    //Get Single Records  
//    this.get = function (Id) {
//        //http://localhost:61218/UserService.svc
//        return $http.get("http://localhost:61218/UserService.svc/GetUserDetails/" + Id);
//    }

//    //Delete the Record  
//    this.delete = function (Id) {
//        var request = $http({
//            method: "delete",
//            url: "http://localhost:61218/UserService.svc/DeleteStudent/" + Id
//        });
//        return request;
//    }
//});



myApp.service("crudAJService", function ($http) {
    //get All Books
    debugger;
    this.getUsers = function () {
        return $http({
            url: "/Home/GetAllUser",
            method: "GET"
            //params: { number: 4, name: "angular" }
        });
    };

});