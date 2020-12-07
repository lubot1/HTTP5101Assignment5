$(document).ready(function () {
    //If delete button is clicked, provide user with an option to confirm or go back
    $("#DeleteBtn").click(function () {
        $("#DeleteBtn").hide();
        $("#ConfirmMessage").show();
        $("#GoBack").show();
        $("#FinalDelete").show();
    });
    //If the go back button is clicked, then hide the confirmation message and text
    $("#GoBack").click(function () {
        $("#DeleteBtn").show();
        $("#ConfirmMessage").hide();
        $("#GoBack").hide();
        $("#FinalDelete").hide();
    });
});