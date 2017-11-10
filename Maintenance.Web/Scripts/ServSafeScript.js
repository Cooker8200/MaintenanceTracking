$(document).ready(function () {

    //dropdown list for ServSafe records
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

    var s = $("<select/>");

    for (var val in stores) {
        $("<option />", { value: val, text: stores[val] }).appendTo(s);
    }

    s.appendTo("#list");

    //search records function
    $("#ss_search").click(function (searchtext) {
        var searchtext = $(s).find(":selected").text();
        $.ajax({
            data: { "searchtext": searchtext },
            url: '/ServSafe/Search',
            success: function (result) {
                $("#ss_results").html(result);
            }
        })
    })


})