

function constructModel() {
    var processId = $("#ProcessId").val();
    var interfaceName = $("#InterfaceName").val();
    var state = $("#State").val();
    var status = $("#Status").val();
    var fIFOTag = $("#FIFOTag").val();
    var fIFOTag2 = $("#FIFOTag2").val();
    var startDate = kendo.toString($("#StartDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    var endDate = kendo.toString($("#EndDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");

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

function getColumns() {
    var columns =
        [{
            field: "ProcessId",
            title: "Process Id",
            filterable: false
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
            filterable: false
        }, {
            field: "UpdatedAt",
            title: "Updated At",
            template: "#= kendo.toString(kendo.parseDate(CreatedAt, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            filterable: false
        }
        ];
    return columns;
}


function GetProcessList() {
    var url = $('#UrlGetProcessList').data('url');
    var columns = getColumns();
    $.ajax({
        type: 'GET',
        url: url,
        beforeSend: function () {
            $('.ajax-loader').css("visibility", "visible");
        },
        success: function (data) {
            $('#grid').kendoGrid({
                change: onChange,
                scrollable: false,
                sortable: true,
                selectable: "row",
                filterable: true,
                dataSource: { data: data, pageSize: 10 }, //binding JSON data with grid,
                serverPaging: true,
                serverSorting: true,
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                schema: { data: "data", total: "total" },
                columns: columns
            });
        },
        complete: function () {
            $('.ajax-loader').css("visibility", "hidden");
        }
    });
    var grid = $("#grid").data("kendoGrid");
}

function SearchProcessDeatils() {
   // debugger;
    var url = $('#UrlSearchProcessDeatils').data('url');
    var model = constructModel();
    var columns = getColumns();
    $.ajax({
        type: 'GET',
        beforeSend: function () {
            $('.ajax-loader').css("visibility", "visible");
        },
        url: url,
        data: model,
        success: function (data) {
            $('#btnConditional').addClass('disabled').prop('disabled', true);
            $("#grid").data("kendoGrid").destroy();
            $('#grid').kendoGrid({
                change: onChange,
                scrollable: false,
                sortable: true,
                selectable: "row",
                filterable: true,
                cache: false,
                dataSource: { data: data, pageSize: 10 },
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                columns: columns
            });
        },
        complete: function () {
            $('.ajax-loader').css("visibility", "hidden");
        }
    });
    var grid = $("#grid").data("kendoGrid");
}

$('#btnSearchProcess').click(function () {
    SearchProcessDeatils();
});

$("#grid").delegate("tbody>tr", "dblclick", function () {
    //debugger;
    var ProcessId = function onChange(arg) {
        var selected = this.dataItem(this.select());
        return selected.ProcessId;
    };
    SearchEventLogByProcessId(processId);
});

//$('.k-selectable .k-alt .k-state-selected').click(function () {
  
//});


function onChange(arg) {
    //debugger;
    var selected = this.dataItem(this.select());
    processId = selected.ProcessId;
    if (selected.Status === 5) {
        $('#btnConditional').removeClass('disabled').prop('disabled', false);
        $('#hdnProcessId').val(processId);
    }
}

function SearchEventLogByProcessId(processId) {
    processId = $.trim(processId.replace(/(\r\n|\n|\r)/gm, ""));
    var url = $('#UrlLogIndex').data('url');
    $.ajax({
        type: "POST",
        url: url,
        data: '{id: "' + processId + '" }',
        contentType: "application/json; charset=utf-8",
        dataType: "html",
        success: function (data, textStatus, XMLHttpRequest) {
            //SetData(data);
            window.location.href = '/TechnicalDashBoard/LogIndex';
        },
        failure: function (response) {
            alert(response.responseText);
        },
        error: function (response) {
            alert(response.responseText);
        }
    });
}


$('#btnConditional').click(function () {
    //debugger;
    staus5ClickMethod();
});

function staus5ClickMethod() {
    var processId = $('#hdnProcessId').val();
    processId = $.trim(processId.replace(/(\r\n|\n|\r)/gm, ""));
    var url = $('#UrlStaus5Click').data('url');
    $.ajax({
        url: url,
        contentType: "application/json; charset=utf-8",
        data: { 'processId': processId },
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

//--------------- LogIndex --------------------------------------------------
function constructLogModel() {
    var id = $("#Id").val();
    var severity = $("#Severity").val();
    var requestId = $("#RequestId").val();
    var businessId = $("#BusinessId").val();
    var message = $("#Message").val();
    var machineName = $("#MachineName").val();
    var userId = $("#UserId").val();
    var startDate = kendo.toString($("#StartDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    var endDate = kendo.toString($("#EndDate").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");

    var logModel = {
        Id: id,
        Severity: severity,
        RequestId: requestId,
        BusinessId: businessId,
        Message: message,
        MachineName: machineName,
        UserId: userId,
        StartDate: startDate,
        EndDate: endDate,
    };
    return logModel;
}

function getLogColumns() {
    var columns =
        [{
            field: "Id",
            title: "Id",
            filterable: false
        }, {
            field: "Severity",
            title: "Severity",
            filterable: false
        }, {
                field: "RequestId",
                title: "Request Id",
            filterable: false
        }, {
                field: "BusinessId",
                title: "BusinessId",
            filterable: false
        }, {
                field: "Message",
                title: "Message",
            filterable: false
        }, {
                field: "MachineName",
                title: "Machine Name",
            filterable: false
        }, {
            field: "UserId",
            title: "User Id",
            filterable: false
        }
            , {
                field: "Timestamp",
                title: "Timestamp",
                template: "#= kendo.toString(kendo.parseDate(Timestamp, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            filterable: false
        }, {
                field: "IntegrationMessageId",
                title: "IntegrationMessageId",
            filterable: false
        }
        ];
    return columns;
}

function GetEventLogByProcessId(id) {
    //debugger;
    var url = $('#UrlGetEventLogByProcessId').data('url');
    var model = constructLogModel();
    if (typeof id != 'undefined' && id)
    {
        model = {};
        model.Message = id;
    }    
    var columns = getLogColumns();
    $.ajax({
        type: "POST",
        url: url,
        contentType: "application/json; charset=utf-8",
        data: JSON.stringify(model),
        dataType: "json",
        success: function (data) {
            $('#grid').kendoGrid({
                scrollable: false,
                sortable: true,
                selectable: "row",
                filterable: true,
                cache: false,
                dataSource: { data: data, pageSize: 10 },
                pageable: {
                    refresh: true,
                    pageSizes: true,
                    buttonCount: 5
                },
                columns: columns
            });
        }
    });
    var grid = $("#grid").data("kendoGrid");
}
$('#btnSearchLogEvent').click(function () {
    GetEventLogByProcessId();
});

    //function SearchProcessDeatils() {
    //    debugger;
    //    var url = $('#UrlSearchProcessDeatils').data('url');
    //    var model = constructModel();
    //    var columns = getColumns();
    //    $("#grid").kendoGrid({
    //        pageable: true,
    //        scrollable: false,
    //        dataSource: {
    //            schema: {
    //                data: "data",
    //                total: 100
    //            },
    //            pageSize: 15,
    //            serverPaging: true,
    //            transport: {
    //                read: {
    //                    url: url, 
    //                    dataType: "odata",
    //                    type: "GET",
    //                    data: model
    //                }
    //            }
    //        }
    //    });

        //function SearchProcessDeatils() {
        //    debugger;
        //    var url = $('#UrlSearchProcessDeatils').data('url');
        //    var model = constructModel();
        //    var columns = getColumns();
        //    $("#grid").kendoGrid({
        //        dataSource: {
        //            type: "odata",
        //            transport: {
        //                read: {
        //            url: url,
        //            data: model}

        //            },
        //            pageSize: 20
        //        },
        //        height: 550,
        //        groupable: true,
        //        sortable: true,
        //        pageable: {
        //            refresh: true,
        //            pageSizes: true,
        //            buttonCount: 5
        //        },
        //        columns: columns
        //    });
        //}