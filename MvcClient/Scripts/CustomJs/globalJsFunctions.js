function RemoveValidationErrors() {
    $('.field-validation-error').each(function () {
        $(this).empty();
    });
}