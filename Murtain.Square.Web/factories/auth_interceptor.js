
"use strict";

define(['app.module'], function (app) {

    app.factory('auth_interceptor', ["$q", function () {
        return {
            request: function (config) {
                console.log(config || $q.when(config))

                return config || $q.when(config);
            },
            response: function (response) {
                console.log(response || $q.when(response))

                return response || $q.when(response);
            }
        };
    }]);

});
