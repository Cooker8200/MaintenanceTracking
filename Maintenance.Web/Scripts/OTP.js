    $(document).ready(function () {
    var storeName;
    //get storeName from menu and assign to hidden item for form collection
    $("#SendTo").change(function () {
        storeName = $("#SendTo").find(":selected").text();
        $("#StoreName").val(storeName);
    })

});