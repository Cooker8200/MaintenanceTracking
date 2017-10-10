$(document).ready(function () {

    //dropdown list for HepA shot search
    var stores = {
        "Store": "University City",
        "Store1": "Ballwin",
        "Store2": "Dorsett",
        "Store3": "Ashby",
        "Store4": "Lindell",
        "Store5": "Olivette",
        "Store6": "Clarkson",
        "Store7": "141",
        "Store8": "Overland Plaza",
        "Store9": "Howdershell",
        "Store10": "Earth City",
        "Store11": "Creve Coeur",
        "Store11": "St Johns",
        "Store12": "Ellisville"
    }
    
    var data = {
        "Data": "All Records",
        "Data2": "Need Both Shots",
        "Data3": "Need Second Shot"
    }

    var s = $("<select/>");

    for (var val in stores){
        $("<option />", {value: val, text: stores[val]}).appendTo(s);
    }

    //var s1 = $("<select/>");

    //for (var val in data) {
    //    $("<option />", { value: val, text: data[val]}).appendTo(s1);
    //}

    s.appendTo("#list");

    //var searchtext = $(s).selected;

    $("#hep_search").click(function (searchtext) {
        var searchtext = $(s).find(":selected").text();
        //alert(searchtext);
        $.ajax({
            data: { "searchtext": searchtext },
            url: '/HepA/Search',
            success: function (result) {
                $("#hepa_results").html(result);
            }
        })
    })


})


