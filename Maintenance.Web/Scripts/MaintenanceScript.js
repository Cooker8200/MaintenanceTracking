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

    //bring in search store
    $("#search_store").click(function () {
        $.ajax({
            url: "/Maintenance/SearchStore",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //bring in search date
    $("#search_date").click(function () {
        $.ajax({
            url: "/Maintenance/SearchDates",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //bring in search vendor
    $("#search_vendor").click(function () {
        $.ajax({
            url: "/Maintenance/SearchVendor",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //bring in search repair type
    $("#search_type").click(function () {
        $.ajax({
            url: "/Maintenance/SearchRepairType",
            success: function (result) {
                $("#search_field").html(result);
            }
        })
    })
    //search calls
    //store
    $("#store_search").click(function (storetext) {
        var storetext = $("#storetext").val();
        $.ajax({
            url: "/Maintenance/StoreRecords",
            data: storetext,
            success: function (result) {
                $("#search_results").html(result);
            }
        });
    })
    //repair type
    $("#repair_search").click(function (repairtext) {
        var repairtext = $("#repairtext").val();
        $.ajax({
            url: "/Maintenance/RepairTypeRecords",
            data: repairtext,
            success: function (result) {
                $("#search_results").html(result);
            }
        });
    })
    //vendor
    $("#vendor_search").click(function (vendortext) {
        var vendortext = $("#vendortext").val();
        $.ajax({
            url: "/Maintenance/VendorRecords",
            data: vendortext,
            success: function (result) {
                $("#search_results").html(result);
            }
        });
    })
    //date
    $("#date_search").click(function (dateone, datetwo) {
        var dateone = $("#startedate").val();
        var datetwo = $("#enddate").val();
        $.ajax({
            url: "/Maintenance/DateRecords",
            data: dateone, datetwo,
            success: function (result) {
                $("#search_results").html(result);
            }
        });
    })

    //create store -- get store name
    $("#Store").change(function () {
        var storeName = $("#Store").find(":selected").text();
        $("#StoreName").val(storeName);
    })

});


