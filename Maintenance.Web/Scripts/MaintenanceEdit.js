$(document).ready(function () {

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
        "Store12": "Ellisville",
        "Store13": "Office"
    }

    var s = $("<select/>");

    for (var val in stores){
        $("<option />", {value: val, text: stores[val]}).appendTo(s);
    }

    s.appendTo("#search_method");

    $("select").prop('id', 'storename');

    $("#edit_search").click(function (searchtext1) {
        var searchtext1 = $(s).find(":selected").text();
        //alert(searchtext);
        $.ajax({
            data: { "searchtext": searchtext1 },
            url: '/Maintenance/EditStepTwo',
            success: function (result) {
                $("#edit_step2").html(result);
            }
        })
    });
})