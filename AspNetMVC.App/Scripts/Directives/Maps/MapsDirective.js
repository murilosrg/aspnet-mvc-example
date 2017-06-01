(function () {
    angular.module('app').directive('appMaps', [
        'Places',
        'GoogleTeste',
        MapsDirective
    ]);

    function MapsDirective(Places, GoogleTeste) {
        return {
            restrict: 'A',
            scope: {
                googleMaps: "=appMaps",
                methodInitialize: "&appMapsInitializeOnload",
                zoom: "=appMapsZoom",
                scrollwheel: "=appMapsScrollwheel",
                panControl: "=appMapsPanControl",
                zoomControl: "=appMapsZoomControl",
                mapTypeControl: "=appMapsTypeControl",
                scaleControl: "=appMapsScaleControl",
                streetViewControl: "=appMapsStreetViewControl",
                overviewMapControl: "=appMapsOverviewControl",
                centerLat: "=appMapsCenterLatitude",
                centerLong: "=appMapsCenterLongitude",
                rightClick: "&appMapsOnRightClick",
                waitingBounds: "&appMapsWaitingBounds",
                click: "&appMapsOnClick"
            },
            link: function ($scope, $element, attrs) {
                function initialize() {
                    var options = {
                        zoom: $scope.zoom,
                        scrollwheel: $scope.scrollwheel,
                        panControl: $scope.panControl,
                        zoomControl: $scope.zoomControl,
                        mapTypeControl: $scope.mapTypeControl,
                        scaleControl: $scope.scaleControl,
                        streetViewControl: $scope.streetViewControl,
                        overviewMapControl: $scope.overviewMapControl,
                        center: { lat: $scope.centerLat, lng: $scope.centerLong },
                        disableDefaultUI: true,
                        draggableCursor: 'auto'
                    }

                    $scope.googleMaps = GoogleTeste.mapa({ element: $element[0], options: options });

                    google.maps.event.addDomListener(window, 'load', function (e) {
                        $scope.methodInitialize();
                    });

                    if (typeof ($scope.waitingBounds()) == "function") {
                        google.maps.event.addListener($scope.googleMaps, "idle", function () {
                            $scope.waitingBounds()();
                        });
                    }
                }

                if (attrs.hasOwnProperty("appMapsModalResize")) {
                    $(".modal").on("shown.bs.modal", function () {
                        google.maps.event.trigger($scope.googleMaps, "resize");
                    });
                }

                if (attrs.hasOwnProperty("appMapsInitializeOnload")) {
                    initialize();
                }
            }
        }
    };
})();