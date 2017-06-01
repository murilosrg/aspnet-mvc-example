(function () {
    angular.module("app").controller("AppController", [
        "$window",
        "Global",
        AppController
    ]);

    function AppController($window, Global) {

        var _self = this;

        _self.iniciarSessao = function () {
            _self.iniciandoSessao = true;
            _self.erros = {};

            $window.location.href = "/";

        };

        _self.limparMensagens = function () {
            _self.erros.aoIniciarSessao = null;
        }
    }
})();