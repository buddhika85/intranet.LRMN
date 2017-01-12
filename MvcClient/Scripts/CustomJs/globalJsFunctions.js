function RemoveValidationErrors() {
    $('.field-validation-error').each(function () {
        $(this).empty();
    });
}

// display bootbox error alert box
function displayBootboxError(errorMessage)
{
    alert("error bbox");
    bootbox.alert({
        title: "<span class='text-danger'><strong>Error</strong></span>",
        message: "Error : " + errorMessage + " - Please contact IT support"
    });
}