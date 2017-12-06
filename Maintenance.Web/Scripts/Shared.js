$(document).ready(function () {

    //row highlighting in table
    $("tr").hover(function () {
        $(this).css("background-color", "#ffff00")
    },
    function () {
        //if ((this == "tr:even")) {
        $(this).css("background-color", "#ffffff")
        //else 
        //        $(this).css("background-color", "#ffffff")
    });

})