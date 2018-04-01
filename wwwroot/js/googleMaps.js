$(document).ready(function () {
    var locations = [
        ['Vlaardingen', 51.912, 4.349],
        ['Rotterdam', 51.904, 4.509],
        ['Overschie', 51.938, 4.431],
        ['Hillegersberg', 51.952, 4.489],
        ['Feijenoord', 51.89418906, 4.52285569],
    ];

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 11.8,
        center: new google.maps.LatLng(51.924, 4.477),

    });
    // Create an array of alphabetical characters used to label the markers.
    var labels = '1234567891011';

    // Add some markers to the map.
    // Note: The code uses the JavaScript Array.prototype.map() method to
    // create an array of markers based on a given "locations" array.
    // The map() method here has nothing to do with the Google Maps API.
    var markers = locations.map(function (location, i) {
        return new google.maps.Marker({
            position: location,
            label: labels[i % labels.length]
        });
    });

    var infowindow = new google.maps.InfoWindow();

    var marker, i;

    for (i = 0; i < locations.length; i++) {
        marker = new google.maps.Marker({
            position: new google.maps.LatLng(locations[i][1], locations[i][2]),
            map: map
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(locations[i][0]);
                infowindow.open(map, marker);
            }
        })(marker, i));
    }
});