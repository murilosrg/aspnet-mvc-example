(function () {
    angular.module("app").directive("appCalendario", [
        "$filter",
        "$parse",
        CalendarioDirective
    ]);

    function CalendarioDirective($filter, $parse) {
        return {
            restrict: "A",
            require: "ngModel",
            link: function ($scope, $element, attrs, ngModel) {
                var $dateFilter = $filter("date");

                $element.mask("99/99/9999");

                ngModel.$formatters.push(function (modelValue) {
                    return $dateFilter(modelValue, "dd/MM/yyyy");
                });

                ngModel.$parsers.push(function (viewValue) {
                    return $element.datepicker("getDate");
                });

                $element.datepicker({
                    dateFormat: "dd/mm/yy",
                    dayNames: ["Domingo", "Segunda", "Terça", "Quarta", "Quinta", "Sexta", "Sábado"],
                    dayNamesMin: ["D", "S", "T", "Q", "Q", "S", "S", "D"],
                    dayNamesShort: ["Dom", "Seg", "Ter", "Qua", "Qui", "Sex", "Sáb", "Dom"],
                    monthNames: ["Janeiro", "Fevereiro", "Março", "Abril", "Maio", "Junho", "Julho", "Agosto", "Setembro", "Outubro", "Novembro", "Dezembro"],
                    monthNamesShort: ["Jan", "Fev", "Mar", "Abr", "Mai", "Jun", "Jul", "Ago", "Set", "Out", "Nov", "Dez"],
                    nextText: "Próximo",
                    prevText: "Anterior",
                    changeYear: true,
                    yearRange: "-100:+0",
                    onSelect: function (data) {
                        $scope.$apply(function () {
                            ngModel.$setViewValue(data);
                            ngModel.$render();
                        });
                    }
                });
            }
        };
    }
})();
