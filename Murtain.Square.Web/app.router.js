'use strict';

define(['angular-AMD', 'app.module'], function (angularAMD, app) {

    app.run(function ($rootScope, $state, $stateParams) {
        $rootScope.$state = $state;
        $rootScope.$stateParams = $stateParams;
    });

    app.config(["$stateProvider", "$urlRouterProvider", "$locationProvider", "$uiViewScrollProvider", function ($stateProvider, $urlRouterProvider, $locationProvider, $uiViewScrollProvider) {

        $uiViewScrollProvider.useAnchorScroll();

        //$urlRouterProvider.otherwise('/');


        $stateProvider
            .state('square', angularAMD.route({
                url: '/square',
                controllerUrl: '/wwwroot/controllers/square.js',
                templateUrl: '/square/index',
                controllerAs: 'model',
            }))
            .state('profile', angularAMD.route({
                url: '/profile',
                controllerUrl: '/wwwroot/controllers/profile.js',
                templateUrl: '/square/profile',
                controllerAs: 'model',
            }))
            ;
    }]);
})