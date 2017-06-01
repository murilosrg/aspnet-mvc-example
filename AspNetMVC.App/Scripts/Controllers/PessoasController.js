(function () {
    angular.module("app").controller("PessoasController", [
        "Pessoas",
        "Global",
        PessoasController
    ]);

    function PessoasController(Pessoas, Global) {

        var _self = this;

        _self.filtro = {};

        _self.modal = {
            limparMensagens: function () {
                _self.modal.info = {};
                _self.modal.erros = {};
            },
            remover: function () {
                _self.modal.removendo = true;
                _self.modal.erros = {};
                _self.limparMensagens();

                Pessoas
                    .remover(_self.pessoa)
                    .success(function (mensagem) {
                        _self.info = mensagem;
                        _self.modal.confirmarRemocao.visivel = false;
                        _self.consultar(true);
                    })
                    .error(function (erros) {
                        _self.modal.erros.aoSalvar = erros;
                    })
                    ["finally"](function () {
                        _self.modal.removendo = false;
                    });
            },
            salvar: function () {
                _self.modal.salvando = true;
                delete _self.modal.erros;
                _self.limparMensagens();

                Pessoas
                    .salvar(_self.pessoa)
                    .success(function (mensagem) {
                        _self.info = mensagem;
                        _self.modal.dados.visivel = false;
                        _self.consultar(true);
                    })
                    .error(function (erros) {
                        _self.modal.erros.aoSalvar = erros;
                    })
                    ["finally"](function () {
                        _self.modal.salvando = false;
                    });
            }
        }

        _self.consultar = function (pagina1) {
            _self.pesquisando = true;
            _self.erros = [];

            if (pagina1) {
                _self.filtro.paginacao.aPartirDo = 0;
            }

            Pessoas
                .cadastradas()
                .ondeNomeContem(_self.filtro.nome)
                .listar(_self.filtro.paginacao)
                .then(function (response) {
                    if (_self.filtro.paginacao.aPartirDo === 0)
                        _self.cadastradas = [];

                    _self.cadastradas = _self.cadastradas.concat(response.data.pessoas);
                    _self.filtro.paginacao.totalRegistros = response.data.totalRegistros;
                    _self.textoTotalRegistros = Global.textoTotalRegistros(_self.cadastradas.length, response.data.totalRegistros);
                })
                .catch(function (erros) {
                    _self.erros = erros;
                })
                ["finally"](function () {
                    _self.pesquisando = false;
                });
        }

        _self.limparMensagens = function () {
            delete _self.erros;
            delete _self.info;
        }

        _self.limparFiltro = function () {
            delete _self.filtro.nome;
        }

        _self.nova = function () {
            _self.pessoa = {};
            delete _self.info;
            delete _self.modal.info;
            delete _self.modal.erros;
        }

        _self.selecionar = function (pessoa) {
            _self.pessoa = angular.copy(pessoa);
        }
    }
})();