$(document).ready(function () {

    //row highlighting for tables
    $("tr").hover(function () {
        $(this).css("background-color", "#ffff00")
    },
        function () {
            //if ((this == "tr:even")) {
            $(this).css("background-color", "#ffffff")
            //else 
            //        $(this).css("background-color", "#ffffff")
        });


    //maintenance search AJAX calls
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
            data: { "storetext": storetext },
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
            data: { "repairtext": repairtext },
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
            data: { "vendortext": vendortext},
            success: function (result) {
                $("#search_results").html(result);
            }
        });
    })
    //date
    $("#date_search").click(function (startdate, enddate) {
        var startdate = $("#startdate").val();
        var enddate = $("#enddate").val();
        $.ajax({
            url: "/Maintenance/DateRecords",
            data: { "startdate": startdate, "enddate": enddate },
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


