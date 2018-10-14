"use strict"

var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;

function onRequestEnd(e) {
    if (e.response.Data && e.response.Data.length) {
        var rows = e.response.Data;
        if (this.group().length) {
            for (var i = 0; i < rows.length; i++) {
                var gr = rows[i];
                if (gr.Member == "TimeStamp") {
                    gr.Key = gr.Key.replace(/\d+/,
                        function (n) { return parseInt(n) + offsetMiliseconds }
                    );
                }
                addOffset(gr.Items);
            }
        } else {
            addOffset(rows);
        }
    }
}

function addOffset(rows) {
    for (var i = 0; i < rows.length; i++) {
        rows[i].TimeStamp = rows[i].TimeStamp.replace(/\d+/,
            function (n) { return parseInt(n) + offsetMiliseconds }
        );
    }
}


function constructIntModel() {
    var id = $("#Id").val();
    var messageType = $("#MessageType").val();
    var system = $("#System").val();
    var status = $("#Status").val();
    var message = $("#Message").val();
    var startTimeStamp = $("#StartTimeStamp").val();
    var endTimeStamp = $("#EndTimeStamp").val();
    if ($.trim(startTimeStamp) != '') {
        startTimeStamp = kendo.toString($("#StartTimeStamp").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }
    if ($.trim(endTimeStamp) != '') {
        endTimeStamp = kendo.toString($("#EndTimeStamp").data("kendoDateTimePicker").value(), "yyyy/MM/dd h:mm:ss tt");
    }

    var model = {
        Id: id,
        MessageType: messageType,
        System: system,
        Status: status,
        Message: message,
        StartTimeStamp: startTimeStamp,
        EndTimeStamp: endTimeStamp
    };
    return model;
}

function getIntColumns() {
    var columns =
        [{
            field: "IntegrationMessageId",
            title: "Id",
            filterable: false,
            //template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal'>#=IntegrationMessageId#</a>"
            template: "<a href='\\\#myModal' data-toggle='modal' data-target='\\\#myModal' onclick=\"showIntegrationMessage('#=data#')\" >#=IntegrationMessageId#</a>",
            width: "75px"
        }, {
            field: "MessageType",
            title: "Message Type",
            filterable: true,
            width: "150px"
        }, {
            field: "System",
            title: "System",
            filterable: true,
            width: "75px"
        }, {
            field: "Status",
            title: "Status",
            filterable: true,
            width: "100px"
        }, {
            field: "Message",
            title: "Message",
            filterable: true
        }, {
            field: "TimeStamp",
            title: "TimeStamp",
            template: "#= kendo.toString(kendo.parseDate(TimeStamp, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
            //type: "date",
            //format: "{0:MM/dd/yyyy hh:mm:ss tt}",
            //parseFormats: ["yyyy-MM-dd'T'HH:mm:ss.zz"],
            filterable: true,
            width: "150px"
        }];
    return columns;
}
var url = $('#UrlGetIntegrationMessage').data('url');
var urlGetIntegrationMessageDetail = $('#UrlGetIntegrationMessageDetail').data('url');

function GetIntegrationMessage() {
    var tempmodel = constructIntModel();
    $("#grid").kendoGrid({
        //timezone: "Etc/UTC",
        //currentTimeMarker: {
        //    useLocalTimezone: false
        //},
        dataSource: {
            transport: {
                read: {
                    url: url,
                    headers: {
                        'Cache-Control': 'no-cache, no-store, must-revalidate',
                        'Pragma': 'no-cache',
                        'Expires': '0'
                    },
                    contentType: "application/json",
                    type: "POST",
                    data: tempmodel,
                    cache: false
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
            pageSize: 10,
            serverPaging: true,
            serverFiltering: false,
            serverSorting: false
        },
        noRecords: {
            template: "No data available for current request."
        },
        filterable: false,
        height: 305,
        sortable: false,
        pageable: {
            change: function (e) {
            }
        },
        columns: getIntColumns()
    });
}

$('#btnSearchIntegrationMessage').bind('click', function () {

    var startTimeStamp = $("#StartTimeStamp").val();
    var endTimeStamp = $("#EndTimeStamp").val();
    var msg = $("#Message").val();
    if (msg != null && msg != '') {
        if ((startTimeStamp != null && startTimeStamp != '') && (endTimeStamp != null && endTimeStamp != '')) {

        }
        else {
            alert("Please enter start and end time stamp. The duration should not be greater than 10 minutes.")
            return false;
        }
    }
    $("#grid").data("kendoGrid").destroy();
    GetIntegrationMessage();
});

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
            alert("error");
        }
    });
}
//$(document).on('click', '#btnSearchIntegrationMessage', function () {
//    GetIntegrationMessage();
//});
//$("#btnSearchIntegrationMessage").click(function (event) {
//    event.stopPropagation();
//    GetIntegrationMessage();
//});

//$('#btnSearchIntegrationMessage').click(function () {
//   debugger;
//    GetIntegrationMessage();
//});


////function GetIntegrationMessage() {

////    $("#grid").kendoGrid({
////        dataSource: griddatasource,
////        groupable: true,
////        //sortable: {
////        //    mode: "multiple",
////        //    allowUnsort: true
////        //},
////        model: constructIntModel(),
////        sortable: true,
////        selectable: true,
////        filterable: true,
////        reorderable: true,
////        resizable: true,
////        columnMenu: true,
////        pageable: {
////            refresh: true,
////            pageSizes: true,
////            buttonCount: 5
////        },
////        columns: getColumns(),
////        schema: { data: "data", total: "total" },
////    });
////}


//function GetIntegrationMessage() {
//    var url = $('#UrlGetIntegrationMessage').data('url');
//    var columns = getColumns();
//    $.ajax({
//        type: 'GET',
//        url: url,
//        data: constructIntModel(),
//        success: function (data) {
//            $('#grid').kendoGrid({
//                scrollable: true,
//                sortable: true,
//                selectable: "row",
//                filterable: true,
//                dataSource: { data: data, PageSize: 10 }, 
//                serverPaging: true,
//                serverSorting: true,
//                pageable: {
//                    pageSize: 2,
//                    change: function (e) {
//                        console.log("grid pager clicked!");
//                    }
//                },
//                PageSize: 5,
//                schema: { data: "data", total: "total" },
//                columns: columns
//            });
//        },
//        complete: function () {
//            $('.ajax-loader').css("visibility", "hidden");
//        }
//    });
//    var grid = $("#grid").data("kendoGrid");
//}

//$("#myModal1").click(function () {
//    $.ajax({
//        url: '/TechnicalDashBoard/GetIntegrationMessageDetail',
//        dataType: "html",
//        type: "GET",
//        contentType: "application/html; charset=utf-8",
//        success: function (result) {
//            //alert("success");
//            $("#output").html(result);
//        },
//        error: function (xhr) {
//            alert("error");
//        }
//    });
//});

//$('a').on('click', function (e) {
//    e.preventDefault();
//    debugger;
//    $.ajax({
//        url: '/TechnicalDashBoard/GetIntegrationMessageDetail',
//        dataType: "html",
//        type: "GET",
//        contentType: "application/html; charset=utf-8",
//        success: function (result) {
//            //alert("success");
//            $("#output").html(result);
//        },
//        error: function (xhr) {
//            alert("error");
//        }
//    });
//});

