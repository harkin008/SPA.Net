var logCtrl = angular.module('loginController', [])

logCtrl.controller('loginCtr', function ($scope, $http, $httpParamSerializerJQLike) {
    $scope.showLogin = false;
    //{

   
        $scope.submitLogin = function () {
            var loginData = {
                username: $scope.tbUserName,
                password: $scope.tbPassword
            }
            //console.log(loginData)

            $http.post("login", loginData,
             { useDefaultXhrHeader: false}
         
             ).success(function (data) {
                 debugger;
                 if (data == 'invalid user login') {
                     $scope.loginDet = false;
                 }
                 else if (data == 'success') {
                     $scope.loginDet = true;
                 }
                
             }). error(function () {
             })
        }
   // }

        $scope.regNewUser = function () {
           
            //var elmt = angular.element(document.querySelector('#regForm'));

            //elmt.removeClass('hideDiv');
            $scope.showLogin = true;
           
           
          //  $scope.hideClass = "animate-leave";
            //$scope.setClass = "animate-enter";
        }

        $scope.backToLogin = function () {
            $scope.showLogin = false;
           // $scope.setClass = "animate-leave";
           // $scope.hideClass = " animate-enter";
           
            //var elmt = angular.element(document.querySelector('#regForm'));

            //elmt.addClass('hideDiv');
        }

        $scope.submitRegister = function () {
            var regDetails = {
                firstName: $scope.tbFirstName,
                lastName: $scope.tbLastName,
                userName: $scope.tbRegUserName,
                email: $scope.tbEmail,
                password: $scope.tbRegPassword,
                confirmPass: $scope.tbConfPassword

            }


           // console.log(regDetails)
            $http.post("SPADemo/register", regDetails,
            { useDefaultXhrHeader: false }

            ).success(function (data) {
                console.log(data);
            }).error(function (data) {
                console.log(data);
            })
        }
    

    //if ($scope.showLogin = false) {
    //    $scope.showLogin = false;


    //}


        $scope.homeClk = function () {
          
            console.log("home clicked");
            $http.get("home")
            .success(function (data) {
                console.log("home view");
                window.location = "Home";
            })
            .error(function (err) {
                console.log(err);
            });
        }


});

