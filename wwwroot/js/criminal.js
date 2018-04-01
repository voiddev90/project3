$(document).ready(function () {
    getCrimesData("GetStreetCrimeData");
});

var ctx = $("#chart");
var months = ["Januari", "Februari", "Maart", "April", "Mei", "Juni", "Juli", "Augustus", "September", "Oktober", "November", "December"]
var chartColors = ["#3366cc", "#ff0000", "#99ff66", "#6600ff", "#ccccff", "#ff9900", "#00ffff", "#666699"]

var chart = new Chart(ctx, {
    type: 'bar',
    data: {
        labels: months,
        datasets: []
    },
    options: {
        scales: {
            yAxes: [{
                ticks: {
                    beginAtZero: true
                }
            }]
        }
    }
});

function getNewData() {
    var year = $("#selectYear :selected").val();
    var type = $("#selectType :selected").val();
    clearChartData();
    getCrimesData(type, year);
}

function getCrimesData(type, year = "") {
    $.getJSON("/criminal/" + type + "/" + year, function (crimeData) {
        addChartData(crimeData)
    });
}

function addChartData(data) {
    var datasets = [];
    var colorPick = 0;
    $.each(data, function (k, v) {
        var dataset = {
            label: k,
            data: v,
            backgroundColor: chartColors[colorPick]
        }
        colorPick++;
        chart.data.datasets.push(dataset);
    });
    chart.update();
}

function clearChartData() {
    chartData = [];
    chart.data.datasets = [];
    chart.update();
}