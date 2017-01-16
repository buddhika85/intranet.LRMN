(function () {

    "use strict";

    $(document).ready(function () {
        loadContactsGrid();
        loadContactTypesSelect();
    });

    function loadContactsGrid()
    {
        $.ajax({
            url: '/API/ManageContactsAPI',
            method: 'GET',
            data: null,
            cache: false,
            async: false,
            success: function (result) {
                drawContactsTable(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                bootbox.alert({
                    title: "<span class='text-danger'><strong>Error</strong></span>",
                    message: "Unabled to retrieve contacts" + " - Please contact IT support"
                });
            }
        });
    }

    // load contact types select list
    function loadContactTypesSelect() {
        $.ajax({
            url: '/API/ContactTypeAPI',
            method: 'GET',
            data: null,
            cache: false,
            async: false,
            success: function (result) {                
                var listitems = '<option value=-1 selected="selected">--- select ---</option>';
                $.each(result, function (index, item) {
                    listitems += '<option value=' + item.Id + '>' + item.TypeName + '</option>';
                });
                $("#contactTypeId option").remove();
                $("#contactTypeId").append(listitems);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                bootbox.alert({
                    title: "<span class='text-danger'><strong>Error</strong></span>",
                    message: "Unabled to retrieve contact types" + " - Please contact IT support"
                });
            }
        });
    }


    // search
    $('#searchContact').click(function () {
        var contactsSearchDto = getSearchFormInputs();
        $.ajax({
            url: '/API/ManageContactsAPI',
            method: 'POST',
            data: contactsSearchDto,
            cache: false,
            async: false,
            success: function (result) {
                drawContactsTable(result);
            },
            error: function (XMLHttpRequest, textStatus, errorThrown) {
                bootbox.alert({
                    title: "<span class='text-danger'><strong>Error</strong></span>",
                    message: "Unabled to search contacts" + " - Please contact IT support"
                });
            }
        });
    });

    // search inputs as a json object
    function getSearchFormInputs()
    {
        return {
            'FirstName': $('#firstName').val(),
            'LastName': $('#lastName').val(),
            'Email': $('#email').val(),
            'IsApproved': $('#isApproved').val(),
            'IsLocked': $('#isLocked').val(),
            'IsActivated': $('#isActivated').val(),
            'ContactTypeId': $('#contactTypeId').val(),
            'VolunteerInerests': $('#volunteerInerests').val()
        }
    }

    // draw data table
    function drawContactsTable(contacts) {
        $("#contactsTbl").dataTable(
            {
                "data": contacts,
                "aoColumns": [
                        { "mData": "UserIdGenerated", "sTitle": "ID", "bVisible": false },
                        { "mData": "UserId", "sTitle": "UserId", "bVisible": false },
                        { "mData": "Email", "sTitle": "Username", "bVisible": true },
                        { "mData": "FirstName", "sTitle": "First Name", "bVisible": true },
                        { "mData": "LastName", "sTitle": "Last Name", "bVisible": true },
                        { "mData": "PhoneNumber", "sTitle": "Phone", "bVisible": true },
                        { "mData": "JoinDate", "sTitle": "Joined", "bVisible": false },
                        { "mData": "ContractEndDate", "sTitle": "Contract Ends", "bVisible": false },
                        {
                            "mData": "IsAdminApproved", "sTitle": "Reg Status?", "bVisible": true, "sClass": "right", "mRender": function (data, type, row) {
                                if (data == false) {
                                    return "<button class='approveContact' class='btn btn-danger' data-contact-id=" + row.UserId + "> Approve </button>";
                                }
                                else {
                                    return '<div style="text-align:center;background-color: #D2B48C;">Approved</div> ';
                                }
                            },
                            "aTargets": [0]
                        },
                        {
                            "mData": "UserActive", "sTitle": "Activated?", "bVisible": true, "sClass": "right", "mRender": function (data, type, row) {
                                if (data == true) {
                                    return '<div style="background-color:lightgreen; text-align:center">active</div> ';
                                }
                                else {
                                    return '<div style="background-color:darkorange; text-align:center">INACTIVE</div> ';
                                }
                            },
                            "aTargets": [0]
                        },
                        {
                            "mData": "UserLocked", "sTitle": "Locked", "bVisible": true, "sClass": "right", "mRender": function (data, type, row) {
                                if (data == false) {
                                    return "<button class='lockContact' class='btn-sm btn-danger' style='width:85%;background-color: #ff4d4d;' data-contact-id=' + row.UserId + ' data-contact-name=" + row.FullName + "> Lock </button>";
                                }
                                else {
                                    return "<button class='unlockContact' class='btn-sm btn-info' style='width:85%;background-color: #668cff;' data-contact-id=' + row.UserId + ' data-contact-name=" + row.FullName + ">Unlock</button>";
                                }
                            },
                            "aTargets": [0]
                        },
                        { "mData": "RoleName", "sTitle": "Role", "bVisible": true },
                        { "mData": "ContactType", "sTitle": "Contact Type", "bVisible": true },
                        { "mData": "AccessFailedCount", "sTitle": "Access Failed Count", "bVisible": false },
                        {
                            "sTitle": "Edit", "mRender": function (data, type, row) {
                                return "<button class='editContact' data-contact-id=" + row.UserId + "><span class='glyphicon glyphicon-edit'></span></button>";
                            },
                            "aTargets": [0]
                        },
                ],
                "bDestroy": true,
                "aLengthMenu": [[15, 50, 100, 200, 500, 700, 1000, -1], [15, 50, 100, 200, 500, 700, 1000, "All"]],
                "iDisplayLength": -1
            }
        );
    }

    // edit contact
    $("#contactsTbl").on("click", ".editContact", function () {
        var button = $(this);
        alert(button.attr('data-contact-id'));
    });

    // lock contact
    $("#contactsTbl").on("click", ".lockContact", function () {
        var button = $(this);
        //alert(button.attr('data-contact-id'));
        bootbox.confirm({
            title: "Lock User",
            message: "Do you want to lock user <i> " + button.attr('data-contact-name') + "</i> ?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-danger'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-success'
                }
            },
            callback: function (result) {
                console.log('This was logged in the callback: ' + result);
            }
        });
    });

    // unlock contact
    $("#contactsTbl").on("click", ".unlockContact", function () {
        var button = $(this);
        //alert(button.attr('data-contact-id'));
        bootbox.confirm({
            title: "Unlock User",
            message: "Do you want to unlock user <i> " + button.attr('data-contact-name') + "</i> ?",
            buttons: {
                confirm: {
                    label: 'Yes',
                    className: 'btn-success'
                },
                cancel: {
                    label: 'No',
                    className: 'btn-danger'
                }
            },
            callback: function (result) {
                console.log('This was logged in the callback: ' + result);
            }
        });
    });

    // approve contact
    $("#contactsTbl").on("click", ".approveContact", function () {
        var button = $(this);
        alert(button.attr('data-contact-id'));
    });
}())
