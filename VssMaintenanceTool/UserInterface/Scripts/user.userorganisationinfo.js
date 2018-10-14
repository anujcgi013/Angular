"use strict"

function constructUserOrgModel() {
    var baldoUserId = $("#BaldoUserId").val();
    var firstName = $("#FirstName").val();
    var surName = $("#SurName").val();
    var userId = $("#UserId").val();
    var organisationId = $("#OrganisationId").val();
    var ruSettingsId = $("#RUSettingsId").val();
    var cdbPartyId = $("#CDBPartyId").val();
    var legalName = $("#LegalName").val();
    var commonName = $("#CommonName").val();

    var model = {
        BaldoUserId: baldoUserId,
        FirstName: firstName,
        SurName: surName,
        UserId: userId,
        OrganisationId: organisationId,
        RUSettingsId: ruSettingsId,
        CDBPartyId: cdbPartyId,
        LegalName: legalName,
        CommonName: commonName
    };
    return model;
}

function getUserOrgColumns() {
    var columns =
        [{
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
            width: "75px"
        }, {
            field: "UserId",
            title: "User Id",
            filterable: true,
            width: "238px"
        }, {
            field: "OrganisationId",
            title: "Organisation Id",
            filterable: true,
            width: "238px",
            template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showOrganisationInfo('#=data#')\" >#=OrganisationId#</a>"
        }, {
            field: "RUSettingsId",
            title: "RUSettings Id",
            filterable: true,
            width: "238px",
            template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showRUSettingsInfo('#=data#')\" >#=RUSettingsId#</a>"
        }, {
            field: "CDBPartyId",
            title: "CDB Party Id",
            filterable: true,
            width: "125px"
        }, {
            field: "LegalName",
            title: "Legal Name",
            filterable: true,
            width: "238px"
        },
        {
            field: "CommonName",
            title: "Common Name",
            filterable: true,
            width: "238px"
        }];
    return columns;
}

var urlGetUserOrganisationInfo = $('#UrlGetUserOrganisationInfo').data('url');

function GetUserOrganisationInfo() {
    $("#grid").kendoGrid({
        dataSource: {
            transport: {
                read: {
                    url: urlGetUserOrganisationInfo,
                    contentType: "application/json",
                    type: "POST",
                    data: constructUserOrgModel()
                },
                parameterMap: function (options) {
                    return kendo.stringify(options);
                }
            },
            schema: {
                data: "Data",
                total: "Total",
            },
            pageSize: 10,
            serverPaging: true,
            serverFiltering: true,
            serverSorting: true
        },
        noRecords: {
            template: "No data available for current request."
        },
        filterable: false,
        height: 305,
        sortable: false,
        pageable: true,
        serverPaging: true,
        columns: getUserOrgColumns()
    });
}

$('#btnSearchUserOrganisationInfo').click(function () {
    $("#grid").data("kendoGrid").destroy();
    GetUserOrganisationInfo();
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

function showOrganisationInfo() {
    var grid = $("#grid").data("kendoGrid");
    var model = grid.dataItem($(event.target).closest("tr"));
    var organisationId = model.OrganisationId;
    var urlGetOrganisationDetail = $('#UrlGetOrganisationDetail').data('url');
    $('#output').removeData('bs.modal');
    $('#output').find('.modal-content').html('');
    $.ajax({
        url: urlGetOrganisationDetail,
        dataType: "html",
        data: { 'OrganisationId': organisationId },
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

function showRUSettingsInfo() {
    var grid = $("#grid").data("kendoGrid");
    var model = grid.dataItem($(event.target).closest("tr"));
    var ruSettingsId = model.RUSettingsId;
    var UrlGetRUSettingsDetail = $('#UrlGetRUSettingsDetail').data('url');
    $('#output').removeData('bs.modal');
    $('#output').find('.modal-content').html('');
    $.ajax({
        url: UrlGetRUSettingsDetail,
        dataType: "html",
        data: { 'RUSettingsId': ruSettingsId },
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