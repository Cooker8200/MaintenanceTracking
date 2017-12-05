$(document).ready(function () {

    //dropdown list for HepA shot search        //todo pull from database
    var stores = {
        "1": "University City", 
        "2": "Ballwin",
        "3": "Dorsett",
        "4": "Ashby",
        "5": "Lindell",
        "6": "Olivette",
        "7": "Clarkson",
        "8": "141",
        "9": "Overland Plaza",
        "10": "Howdershell",
        "11": "Earth City",
        "12": "Creve Coeur",
        "13": "St Johns",
        "14": "Ellisville"
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

    $("#hep_search").click(function (searchtext, searchval) {
        var searchval = $(s).find(":selected").val();
        var searchtext = $(s).find(":selected").text();
        $.ajax({
            data: { "searchval" : searchval, "searchtext": searchtext },
            url: '/HepA/Search',
            success: function (result) {
                $("#hepa_results").html(result);
            }
        })
    })


})


