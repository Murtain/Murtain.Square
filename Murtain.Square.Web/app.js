"use strict";


define(['app.module', 'angular-AMD', 'angular-AMD-ngload', 'app.router', 'app.constants','factories/auth_interceptor'], function (app, angularAMD) {


    app.config(function ($httpProvider) {
        $httpProvider.interceptors.push('auth_interceptor');
    });

    app.controller('index', IndexController);

    IndexController.$inject = ['$scope', '$timeout', 'constants'];

    function IndexController($scope, $timeout, constants) {

        console.log("IndexController running ...");

        var that = {
            
        };

        that = angular.extend(this, that);

        active();

        function active() {
        }

    }

    return angularAMD.bootstrap(app);
});