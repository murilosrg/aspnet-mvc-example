(function () {
    angular.module("app").service("Pessoas", [
        "ApiRequest",
        PessoasService
    ]);

    function PessoasService(ApiRequest) {
        var url;
        var pessoa;

        this.cadastradas = function () {
            url = "/Pessoas/Consultar";
            pessoa = {};
            return this;
        }

        this.listar = function (paginacao) {
            pessoa.aPartirDo = paginacao.aPartirDo;
            return ApiRequest.json(url, pessoa);
        }

        this.ondeNomeContem = function (nome) {
            pessoa.nome = nome;
            return this;
        }

        this.remover = function (pessoa) {
            return ApiRequest.json("/Pessoas/Remover", { idPessoa: pessoa.idPessoa })
        }

        this.salvar = function (pessoa) {
            url = pessoa.idPessoa ? "/Pessoas/Atualizar" : "/Pessoas/Cadastrar";

            return ApiRequest.json(url, pessoa);
        }
    }
})();