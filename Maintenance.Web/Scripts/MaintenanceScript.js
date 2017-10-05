$(document).ready(function () {

    $("#goto_maint").click(function () {        //todo revist, what is this doing?  anything?
        $.ajax({
            url: '../Maintenance/MaintenanceHome',
            success: function (result) {
                $("#content").html(result)
            }
        })
    });

    //records color coding                                      //todo fix color highlighting
    //$("tr:even").css("background-color", "#e6e6e6");    

    //$("tr:odd").css("background-color", "#ffffff");

    $("tr").hover(function () {
        $(this).css("background-color", "#ffff00")
    },
        function () {
            //if ((this == "tr:even")) {
            $(this).css("background-color", "#ffffff")
            //else 
            //        $(this).css("background-color", "#ffffff")
        });

    //search store
    $("#search_store").click(function () {
        $.ajax({
            url: "/Maintenance/SearchStore",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //search date
    $("#search_date").click(function () {
        $.ajax({
            url: "/Maintenance/SearchDates",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //search vendor
    $("#search_vendor").click(function () {
        $.ajax({
            url: "/Maintenance/SearchVendor",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //search repair type
    $("#search_type").click(function () {
        $.ajax({
            url: "/Maintenance/SearchRepairType",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })

});


