$(document).ready(function () {

    //dropdown list for ServSafe records
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

    var s = $("<select/>");

    for (var val in stores) {
        $("<option />", { value: val, text: stores[val] }).appendTo(s);
    }

    s.appendTo("#list");

    //search records function
    $("#ss_search").click(function (searchtext) {
        var searchval = $(s).find(":selected").val();
        var searchtext = $(s).find(":selected").text();
        $.ajax({
            data: { "searchtext": searchtext, "searchval": searchval },
            url: '/ServSafe/Search',
            success: function (result) {
                $("#ss_results").html(result);
            }
        })
    })


})