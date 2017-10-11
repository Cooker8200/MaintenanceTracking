$(document).ready(function () {

    var stores = {
        "Store": "Technology",
        "Store1": "Kitchen Equipment",
        "Store2": "Refridgeration",
        "Store3": "HVAC",
    }

    var p = $("<select/>");

    for (var val in stores) {
        $("<option />", { value: val, text: stores[val] }).appendTo(p);
    }

    p.appendTo("#repair_search");
    
    $("#repair_searchbutton").click(function (searchtext1, searchtext2) {
        var searchtext1 = $("#storename").find(":selected").text();
        var searchtext2 = $(p).find(":selected").text();
        alert(searchtext1, searchtext2);
        $.ajax({
            data: { "searchtext1": searchtext1, "searchtext2": searchtext2 },
            url: '/Maintenance/EditReturnRecords',
            success: function (result) {
                $("#search_results").html(result);
            }
        })
    });
})