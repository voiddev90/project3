$(document).ready(function () {
    var locations = [
        ['Rotterdam-Zuidoost, Ridderkerk',51.872312, 4.532820, "9"],
        ['Vlaardingen, Maassluis, Hoek van Holland', 51.912, 4.349, "1"],
        ['Schiedamse weg', 51.913056, 4.432016, "3"],
        ['Hillegersberg, Provenierswijk, Ouden Noorden(HPO), Bergschenkhoek, Berkel en Rodenrijs, Bleiwswijk(B-driehoek)', 51.943636, 4.473540, "5"],
        ['Charlois, Hoogvliet, Rozenbburg, Barendrecht/ Albrandswaard', 51.860764, 4.354568, "10"],
        ['Eendrachtsplein', 51.916778, 4.472920, "4"],
        ['Kralingen/Crooswijk/Alexander, Capelle/Krimpen', 51.924895, 4.507620, "6"],
        ['Putten, Voorne, Dirksland, Goedereede, Middelharnis, Flakkee Oosr', 51.876507, 4.473627, "11"],
    ];
  
   

    var map = new google.maps.Map(document.getElementById('map'), {
        zoom: 11.4,
        center: new google.maps.LatLng(51.924, 4.477),
        disableDefaultUI: true

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
            map: map,
            label: locations[i][3]
        });

        google.maps.event.addListener(marker, 'click', (function (marker, i) {
            return function () {
                infowindow.setContent(locations[i][0]);
                infowindow.open(map, marker);
            }
        })(marker, i));
    }
});