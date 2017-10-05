$(document).ready(function () {

    //St Johns HepA
    $("#StJohns").click(function () {
        $.ajax({
            url: "HepA/StJohns",
            success: function (result) {
                $("#HepA_Results").html(result);
            }
        })
    });

})