"use strict";

var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;

function onRequestEnd(e) {
    if (e.response.Data && e.response.Data.length) {
        var rows = e.response.Data;
        if (this.group().length) {
            for (var i = 0; i < rows.length; i++) {
                var gr = rows[i];
                if (gr.Member == "Timestamp") {
                    gr.Key = gr.Key.replace(/\d+/,
                        function (n) { return parseInt(n) + offsetMiliseconds }
                    );
                }               
                addOffset(gr.Items);
            }
        }
        else {
            addOffset(rows);
        }
    }
}
function addOffset(rows) {
    for (var i = 0; i < rows.length; i++) {
        rows[i].Timestamp = rows[i].Timestamp.replace(/\d+/,
            function (n) { return parseInt(n) + offsetMiliseconds }
        );
    }
}

var constructEventLogModel = function () {
    var id = $("#Id").val();
    var severity = $("#Severity").val();
    var requestId = $("#RequestId").val();
    var businessId = $("#BusinessId").val();
    var businessIdType = $("#BusinessIdType").val();
    var message = $("#Message").val();
    var machineName = $("#MachineName").val();
    var userId = $("#UserId").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();
    if ($.trim(startDate) != '') {
        startDate = kendo.toString($("#StartDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }
    if ($.trim(endDate) !== '') {
        endDate = kendo.toString($("#EndDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }
    var integrationMessageId = $("#IntegrationMessageId").val();
    var logModel = {
        Id: id,
        Severity: severity,
        RequestId: requestId,
        BusinessId: businessId,
        BusinessIdType: businessIdType,
        Message: message,
        MachineName: machineName,
        UserId: userId,
        StartDate: startDate,
        EndDate: endDate,
        IntegrationMessageId: integrationMessageId
    };
    return logModel;
}

function getEventLogColumns() {
    var columns =
        [{
            field: "EventLogId",
            title: "Id",
            filterable: false,
            template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showEventLog('#=data#')\" >#=EventLogId#</a>"
            
        }, {
            field: "Severity",
            title: "Severity",
            filterable: false
        }, {
            field: "RequestId",
            title: "Request Id",
            filterable: false,
            width:235
        }, {
            field: "BusinessId",
            title: "BusinessId",
            filterable: false
        },{
            field: "BusinessIdType",
            title: "Business Id Type",
            filterable: false
        }, {
            field: "MachineName",
            title: "Machine Name",
            filterable: false
        }, {
            field: "UserId",
            title: "User Id",
            filterable: false
        }, {
            field: "Timestamp",
            title: "Timestamp",
            template: "#= kendo.toString(kendo.parseDate(Timestamp, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            //type: "date",
            //format: "{0:MM/dd/yyyy hh:mm:ss tt}",
            //parseFormats: ["yyyy-MM-dd'T'HH:mm:ss.zz"],
            filterable: false,
            width: 135
        }, {
            field: "IntegrationMessageId",
            title: "IntegrationMessageId",
            filterable: false,
            //template:  "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showIntegrationMessage('#=data#')\" >#=IntegrationMessageId#</a>"
            template: "# if (IntegrationMessageId == null) { #" +
            "<span data-content=' '></span>" +
            "# } else { #" +
            "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showIntegrationMessage('#=data#')\" >#=IntegrationMessageId#</a>"
            +
            "# } #"
            }
        ];
    return columns;
}

var urlGetEventLogs = $('#UrlGetEventLogs').data('url');
var urlGetEventLogDetail = $('#UrlGetEventLogDetail').data('url');
var urlGetIntegrationMessageDetail = $('#UrlGetIntegrationMessageDetail').data('url');

function GetEventLogs() {
    $("#grid").kendoGrid({
        timezone: "Etc/UTC",
        dataSource: {
            transport: {
                read: {
                    url: urlGetEventLogs,
                    contentType: "application/json",
                    type: "POST",
                    data: constructEventLogModel
                },
                parameterMap: function (options) {
                    return kendo.stringify(options);
                }
            },
            schema: {
                data: "Data",
                total: "Total",
            },
            requestEnd: onRequestEnd,
            pageSize: 15,
            serverPaging: true,
            serverFiltering: false,
            serverSorting: false
        },
        currentTimeMarker: {
            useLocalTimezone: false
        },
        noRecords: {
            template: "No data available for current request."
        },
        requestEnd: onRequestEnd,
        height: 350,
        filterable: false,
        sortable: false,
        //pageable: true,
        pageable: {
            //pageSizes: [15, 25, 50, 100],
            change: function (e) {
                //alert('pager change event');
            }
        },
        columns: getEventLogColumns()
    });
}

$(document).on('click', '#btnSearchLogEvent', function () {
    $("#grid").data("kendoGrid").destroy();
    GetEventLogs();
});


function showEventLog() {
    var grid = $("#grid").data("kendoGrid");
    var model = grid.dataItem($(event.target).closest("tr"));
    var eventLogId = model.EventLogId;
    $('#output').removeData('bs.modal');
    $('#output').find('.modal-content').html('');
    $.ajax({
        url: urlGetEventLogDetail,
        dataType: "html",
        data: { 'EventLogId': eventLogId },
        type: "GET",
        contentType: "application/html; charset=utf-8",
        cache: false,
        onstart: "",
        success: function (result) {
            $("#output").html(result);
        },
        error: function (xhr) {
            alert("Something went wrong!...");
        }
    });
};

function showIntegrationMessage() {
    var grid = $("#grid").data("kendoGrid");
    var model = grid.dataItem($(event.target).closest("tr"));
    var integrationMessageId = model.IntegrationMessageId;
    $('#output').removeData('bs.modal');
    $('#output').find('.modal-content').html('');
    $.ajax({
        url: urlGetIntegrationMessageDetail,
        dataType: "html",
        data: { 'IntegrationMessageId': integrationMessageId },
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