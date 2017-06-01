(function () {
    var app = angular.module("app", []);

    app.factory("AppHttpInterceptor", [
       "$q",
       "$window",
       AppHttpInterceptor
    ]);

    app.config([
        "$locationProvider",
        "$httpProvider",
        AppConfiguration
    ]);

    function AppConfiguration($locationProvider, $httpProvider) {
        $httpProvider.interceptors.push("AppHttpInterceptor");
    }

    function AppHttpInterceptor($q, $window) {

        return {
            "request": function (config) {
                return config || $q.when(config);
            },
            "requestError": function (rejection) {
                return $q.reject(rejection);
            },
            "response": function (response) {
                return response || $q.when(response);
            },
            "responseError": function (rejection) {
                if (rejection.status === 500)
                    $window.location.href = "/RequisicaoNaoCompletada";

                return $q.reject(rejection);
            }
        };
    }
})();