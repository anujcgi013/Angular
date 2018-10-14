"use strict"

var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;

function onRequestEnd(e) {
    if (e.response.Data && e.response.Data.length) {
        var rows = e.response.Data;
        if (this.group().length) {
            for (var i = 0; i < rows.length; i++) {
                var gr = rows[i];
                if (gr.Member == "CreatedAt") {
                    gr.Key = gr.Key.replace(/\d+/,
                        function (n) { return parseInt(n) + offsetMiliseconds }
                    );
                }
                if (gr.Member == "UpdatedAt") {
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
        rows[i].CreatedAt = rows[i].CreatedAt.replace(/\d+/,
            function (n) { return parseInt(n) + offsetMiliseconds }
        );
        rows[i].UpdatedAt = rows[i].UpdatedAt.replace(/\d+/,
            function (n) { return parseInt(n) + offsetMiliseconds }
        );
    }   
}

var constructProcessInstanceModel = function () {
    var processId = $("#ProcessId").val();
    var interfaceName = $("#InterfaceName").val();
    var state = $("#State").val();
    var status = $("#Status").val();
    var fIFOTag = $("#FIFOTag").val();
    var fIFOTag2 = $("#FIFOTag2").val();
    var startDate = $("#StartDate").val();
    var endDate = $("#EndDate").val();
     if ($.trim(startDate) != '') {
        startDate = kendo.toString($("#StartDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }
    if ($.trim(endDate) != '') {
        endDate = kendo.toString($("#EndDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }
    var model = {
        ProcessId: processId,
        State: state,
        Status: status,
        InterfaceName: interfaceName,
        FIFOTag: fIFOTag,
        StartDate: startDate,
        EndDate: endDate,
        FIFOTag2: fIFOTag2,
    };

    return model;
}


function getProcessInstanceColumn() {
    var columns =
        [{
            field: "ProcessId",
            title: "Id",
            filterable: false,
            width: "238px"
        }, {
            field: "State",
            title: "State",
            filterable: false
        }, {
            field: "Status",
            title: "Status",
            filterable: false
        }, {
            field: "InterfaceName",
            title: "Interface Name",
            filterable: false
        }, {
            field: "FIFOTag",
            title: "FIFO Tag",
            filterable: false
        }, {
            field: "FIFOTag2",
            title: "FIFO Tag2",
            filterable: false
        }, {
            field: "CreatedAt",
            title: "Created At",
            template: "#= kendo.toString(kendo.parseDate(CreatedAt, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            //type: "date",
            //format: "{0:MM/dd/yyyy hh:mm:ss tt}",
            //parseFormats: ["yyyy-MM-dd'T'HH:mm:ss.zz"],
            filterable: false
        }, {
            field: "UpdatedAt",
            title: "Updated At",
            template: "#= kendo.toString(kendo.parseDate(UpdatedAt, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            //type: "date",
            //format: "{0:MM/dd/yyyy hh:mm:ss tt}",
            //parseFormats: ["yyyy-MM-dd'T'HH:mm:ss.zz"],
            filterable: false
        }
        ];
    return columns;
}

var urlGetProcessInstances = $('#UrlGetProcessInstances').data('url');
var urlGetEventLog = $('#urlGetEventLog').data('url');

function GetProcessInstances() {
     $('#btnConditional').addClass('disabled').prop('disabled', true);
     $('#hdnProcessId').val('');
     $("#grid").kendoGrid({
         timezone: "Etc/UTC",
         currentTimeMarker: {
             useLocalTimezone: false
         },
        dataSource: {
            transport: {
                read: {
                    url: urlGetProcessInstances,
                    contentType: "application/json",
                    type: "POST",
                    data: constructProcessInstanceModel
                },
                parameterMap: function (options) {
                    return kendo.stringify(options);
                }
            },

            requestEnd: onRequestEnd,
            schema: {
                data: "Data",
                total: "Total",
            },
            pageSize: 15,
            serverPaging: true,
            serverFiltering: false,
            serverSorting: false
        },
        noRecords: {
            template: "No data available for current request."
        },
        selectable: "row",
        change: onChange,
        height: 325,
        filterable: false,
        sortable: false,
        //pageable: true,
        //serverPaging: true,
        columns: getProcessInstanceColumn(),
        pageable: {
            //pageSizes: [15, 25, 50, 100],
            change: function (e) {                
               
            }
        }
    });
}

$(document).on('click', '#btnSearchProcess', function () {
    $("#grid").data("kendoGrid").destroy();
    GetProcessInstances();
});

function SearchEventLogByProcessId(processId) {
    processId = $.trim(processId.replace(/(\r\n|\n|\r)/gm, ""));
    var url = $('#UrlLogIndex').data('url');
    $.ajax({
        type: "POST",
        url: url,
        data: '{id: "' + processId + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        beforeSend: function () {
        },
        success: function (data, textStatus, XMLHttpRequest) {
            window.location.href = urlGetEventLog;
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        },
        complete: function (response) {
            $('.ajax-loader').hide();
        }
    });
}

$("#grid").delegate("tbody>tr", "dblclick", function () {
    var grid = $("#grid").data("kendoGrid");
    var selected = grid.dataItem(grid.select());
    var processId = selected.ProcessId;
    SearchEventLogByProcessId(processId);
});

function onChange(arg) {
    var grid = $("#grid").data("kendoGrid");
    var selected = grid.dataItem(grid.select());
    var processId = selected.Id;
    if (selected.Status === "Error") {
        $('#btnReProcess').removeClass('disabled').prop('disabled', false);
        $('#txtReProcess').removeClass('disabled').prop('disabled', false);
        $('#hdnProcessId').val(processId);
    }
    else{
        $('#btnReProcess').addClass('disabled').prop('disabled', true);
        $('#txtReProcess').addClass('disabled').prop('disabled', true);
        $('#hdnProcessId').val('');
    }
}

$('#btnReProcess').click(function () {
    if ($.trim($('#txtReProcess').val()) != '') {
        reProcess();
    } else {
        alert("Please enter reprocessing reason.");
        return false;
    }
});

function reProcess() {
    var processId = $('#hdnProcessId').val();
    var reprocessReason = $('#txtReProcess').val();
    processId = $.trim(processId.replace(/(\r\n|\n|\r)/gm, ""));
    var url = $('#UrlReProcess').data('url');
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        data: { 'ProcessId': processId, 'ReprocessReason': reprocessReason },
        type: 'GET',
        cache: false,
        success: function (data, textStatus, XMLHttpRequest) {
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}
