$(document).ready(function () {
    var storeName;
    //get storeName from menu and assign to hidden item for form collection
    $("#SendTo").change(function () {
        storeName = $("#SendTo").find(":selected").text();
        $("#StoreName").val(storeName);
    })

    //$("ContactMessage").click(function (Store, storeName, Name, Location, Problem, Equipment) {
    //    $.ajax({
    //        url: '/OTP/SendOtp',
    //        success: alert('Your Request Has Been Submitted'), url: '/OTP/OtpRequest'
            
    //    })
    //})

});