"use strict"

function constructUserProfileModel() {
    var userProfileId = $("#UserProfileId").val();
    var profileId = $("#ProfileId").val();
    var profile = $("#Profile").val();
    var userId = $("#UserId").val();
    var baldoUserId = $("#BaldoUserId").val();
    var firstName = $("#FirstName").val();
    var surName = $("#SurName").val();

    var model = {
        UserProfileId: userProfileId,
        ProfileId: profileId,
        Profile: profile,
        UserId: userId,
        BaldoUserId: baldoUserId,
        FirstName: firstName,
        SurName: surName
    };
    return model;
}

function getUserProfileColumns() {
    var columns =
        [{
            field: "UserProfileId",
            title: "User Profile Id",
            filterable: true,
            width: "238px"
        },{
                field: "ProfileId",
                title: "Profile Id",
                filterable: true,
                width: "50px"
            },{
                field: "Profile",
                title: "Profile",
                filterable: true,
                width: "100px"
            },{
            field: "UserId",
            title: "User Id",
            filterable: true,
            width: "238px"
        },{
            field: "BaldoUserId",
            title: "Baldo Id",
            filterable: false,
            //template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal'>#=IntegrationMessageId#</a>"
            template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showUserInfo('#=data#')\" >#=BaldoUserId#</a>",
            width: "75px"
        }, {
            field: "FirstName",
            title: "First Name",
            filterable: true,
            width: "100px"
        }, {
            field: "SurName",
            title: "Sur Name",
            filterable: true,
            width: "100px"
        }];
    return columns;
}

var urlGetUserProfileInfo = $('#UrlGetUserProfileInfo').data('url');

function GetUserProfileInfo() {
    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: urlGetUserProfileInfo,
                    contentType: "application/json",
                    type: "POST",
                    data: constructUserProfileModel()
                },
                parameterMap: function (options) {
                    return kendo.stringify(options);
                }
            },
            schema: {
                data: "Data",
                total: "Total",
            },
            pageSize: 15,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        noRecords: {
            template: "No data available for current request."
        },
        filterable: false,
        height: 335,
        sortable: false,
        pageable: true,
        serverPaging: true,
        columns: getUserProfileColumns()
    });
}

$('#btnSearchUserProfileInfo').click(function () {
    $("#grid").data("kendoGrid").destroy();
    GetUserProfileInfo();
});

function showUserInfo() {
    var grid = $("#grid").data("kendoGrid");
    var model = grid.dataItem($(event.target).closest("tr"));
    var baldoUserId = model.BaldoUserId;
    var urlGetUserDetail = $('#UrlGetUserDetail').data('url');
    $('#output').removeData('bs.modal');
    $('#output').find('.modal-content').html('');
    $.ajax({
        url: urlGetUserDetail,
        dataType: "html",
        data: { 'BaldoUserId': baldoUserId },
        type: "GET",
        contentType: "application/html; charset=utf-8",
        cache: false,
        success: function (result) {
            $("#output").html(result);
        },
        error: function (xhr) {
            alert("Something went wrong!...");
        }
    });
};

