(function () {
    angular.module('app').directive('appSearchbox', [
        'Places',
        SearchBoxDirective
    ]);

    function SearchBoxDirective(Places) {
        return {
            restrict: 'A',
            scope: {
                map: "=appSearchbox",
                local: "=appSearchboxLocal",
                radius: "=appSearchboxRadius",
                clearMarkers: "=appSearchBoxClearMarkers",
                consultar: "&appSearchBoxConsultar"
            },
            link: function ($scope, $element, attrs) {
                $scope.$watch('map', function (mapa) {
                    if (mapa) {
                        var map = mapa.mapa;
                        var searchBox = new google.maps.places.SearchBox($element[0]);
                        google.maps.event.addListener(searchBox, 'places_changed', function () {
                            var places = searchBox.getPlaces();
                            $scope.local = {};

                            if (places.length == 0) {
                                return;
                            }

                            if (places.length > 1) {
                                $scope.local.locais = [];
                            }

                            if ($scope.clearMarkers)
                                mapa.clearMarkers();

                            places.forEach(function (place) {
                                if (place.address_components) {
                                    $scope.$apply(function () {
                                        $scope.local = Places.getPlace(place);
                                    });
                                }
                                else {
                                    $scope.$apply(function () {
                                        $scope.local.locais.push(Places.getPlace(place));
                                    });
                                }

                                $scope.$apply(function () {
                                    var options = {
                                        center: true,
                                        position: place.geometry.location,
                                        title: place.name,
                                        radius: $scope.radius,
                                        consultar: $scope.consultar
                                    }

                                    $scope.local.marker = mapa.addMarker(options);
                                });
                            });
                        });
                    }
                });
            }
        }
    }
})();