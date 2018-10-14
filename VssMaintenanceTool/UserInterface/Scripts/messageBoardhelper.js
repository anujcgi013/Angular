var messageBoardhelper = null;

$(function () {

    messageBoardhelper = function () {
        var model = null;
        var _saveMB;
        var _getMB;
        var _displayMB;
        var _updateMB;

        function getMessageBoardColumns() {
            var columns =
                [{
                    field: "Id",
                    title: "Id",
                    width: "50px"
                }, {
                    field: "ValidFrom",
                    title: "Valid From",
                    template: "#= kendo.toString(kendo.parseDate(ValidFrom, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
                    width: "150px"
                }, {
                    field: "ValidTo",
                    title: "Valid To",
                    template: "#= kendo.toString(kendo.parseDate(ValidTo, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
                    width: "150px"
                }, {
                    field: "Header",
                    title: "Header",
                    filterable: false,
                    width: "150px"
                }, {
                    field: "Message",
                    filterable: false
                }, {
                    field: "CreatedBy",
                    title: "Created By",
                    width: "100px"
                }, {
                    field: "Created",
                    title: "Created",
                    template: "#= kendo.toString(kendo.parseDate(Created, 'yyyy-MM-dd hh:mm:ss'), 'MM/dd/yyyy hh:mm:ss tt') #",
                    width: "150px"
                }
                ];
            return columns;
        }

        function createMessageModel() {
            var startDate = $("#ValidFrom").val();
            var endDate = $("#ValidTo").val();
            if ($.trim(startDate) != '') {
                var sDate = $("#ValidFrom").data("kendoDateTimePicker").value();
                var start = kendo.toString(sDate, "yyyy/MM/dd h:mm:ss tt");
            }
            if ($.trim(endDate) != '') {
                var eDate = $("#ValidTo").data("kendoDateTimePicker").value();
                var end = kendo.toString(eDate, "yyyy/MM/dd h:mm:ss tt");
            }
            var msgH = $("#Header").val();
            var msg = $("#Message").val();
            var createdBy = $("#CreatedBy").val();
            var model = { Header: msgH, Message: msg, ValidFrom: start, ValidTo: end, CreatedBy: createdBy, Created: null }
            return model;
        }

        function createUpdateMessageModel() {
            var id = $("#Id").val();
            var sDate = $("#ValidFrom").data("kendoDateTimePicker").value();
            var start = kendo.toString(sDate, "yyyy/MM/dd h:mm:ss tt");

            var eDate = $("#ValidTo").data("kendoDateTimePicker").value();
            var end = kendo.toString(eDate, "yyyy/MM/dd h:mm:ss tt");

            var msgH = $("#Header").val();

            var msg = $("#Message").val();
            var createdBy = $("#CreatedBy").val();
            var created = $("#Created").val();
            var model = { Id: id, Header: msgH, Message: msg, ValidFrom: start, ValidTo: end, CreatedBy: createdBy, Created: created }

            return model;
        }

        var offsetMiliseconds = new Date().getTimezoneOffset() * 60000;

        function onRequestEnd(e) {
            if (e.response.Data && e.response.Data.length) {
                var rows = e.response.Data;
                if (this.group().length) {
                    for (var i = 0; i < rows.length; i++) {
                        var gr = rows[i];
                        if (gr.Member == "ValidFrom") {
                            gr.Key = gr.Key.replace(/\d+/,
                                function (n) { return parseInt(n) + offsetMiliseconds }
                            );
                        }
                        if (gr.Member == "ValidTo") {
                            gr.Key = gr.Key.replace(/\d+/,
                                function (n) { return parseInt(n) + offsetMiliseconds }
                            );
                        }
                        if (gr.Member == "Created") {
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
                rows[i].ValidFrom = rows[i].ValidFrom.replace(/\d+/,
                    function (n) { return parseInt(n) + offsetMiliseconds }
                );
                rows[i].ValidTo = rows[i].ValidTo.replace(/\d+/,
                    function (n) { return parseInt(n) + offsetMiliseconds }
                );
                rows[i].Created = rows[i].Created.replace(/\d+/,
                    function (n) { return parseInt(n) + offsetMiliseconds }
                );
            }
        }

        $(":input:not([type=button])").focus(function () {
            $(':input:not([type=button])').css("border", "none");
            $("#messageError").html("");
            $("#messageSuccess").html("");
        });

        $("#grid").delegate("tbody>tr", "dblclick", function () {
            var grid = $("#grid").data("kendoGrid");
            var selected = grid.dataItem(grid.select());
            var maintenanceInformationId = selected.Id;
            if (maintenanceInformationId != 0) {
                DisplayMaintenanceInformation(maintenanceInformationId);
            }
        });

        function DisplayMaintenanceInformation(maintenanceInformationId) {
            var tempmodel = createMessageModel();
            var urlGetMaintenanceDetail = _displayMB;
            $.ajax({
                url: urlGetMaintenanceDetail,
                dataType: "html",
                data: { 'MaintenanceInformationId': maintenanceInformationId },
                type: "GET",
                contentType: "application/html; charset=utf-8",
                cache: false,
                success: function (result) {
                    $("#output").html(result);
                    $('#myModal').modal('toggle');
                },
                error: function (xhr) {
                    alert("Something went wrong!...");
                }
            });
        }

        $('form').submit(function () {
            var allValid = true; //assume fields are valid until we find that they are not
            $(this).find('input[type=text],select,textarea').each(function () {
                if ($(this).val().trim() == "") {
                    allValid = false;
                    $(this).css("border", "1px solid red");
                }
                else {
                    $(this).css("border", "1px solid #ccc"); //reset it if it's gone back to being valid
                }
            });
            return allValid;
        });

        return {
            init: function (getMB, saveMB, displayMB, updateMB) {
                _saveMB = saveMB;
                _getMB = getMB;
                _displayMB = displayMB;
                _updateMB = updateMB;
            },

            SaveMessageBoard: function () {
                var tempmodel = createMessageModel();
                var url = _saveMB;
                function ValidationInputs() {
                    var num = 0;
                    var fn = document.getElementById('ValidFrom').value.trim();
                    if (fn == "") {
                        document.getElementById('ValidFrom').style.border = "1px red solid";
                        num = num + 1;
                    }
                    else {
                        document.getElementById('ValidFrom').style.border = "1px solid #ccc";
                    }
                    fn = document.getElementById('ValidTo').value.trim();
                    if (fn == "") {
                        document.getElementById('ValidTo').style.border = "1px red solid";
                        num = num + 1;
                    }
                    else {
                        document.getElementById('ValidTo').style.border = "1px solid #ccc";
                    }
                    fn = document.getElementById('Header').value.trim();
                    if (fn == "") {
                        document.getElementById('Header').style.border = "1px red solid";
                        num = num + 1;
                    }
                    else {
                        document.getElementById('Header').style.border = "1px solid #ccc";
                    }

                    fn = document.getElementById('Message').value.trim();
                    if (fn == "") {
                        document.getElementById('Message').style.border = "1px red solid";
                        num = num + 1;
                    }
                    else {
                        document.getElementById('Message').style.border = "1px solid #ccc";
                    }
                    fn = document.getElementById('CreatedBy').value.trim();
                    if (fn == "") {
                        document.getElementById('CreatedBy').style.border = "1px red solid";
                        num = num + 1;
                    }
                    else {
                        document.getElementById('CreatedBy').style.border = "1px solid #ccc";
                    }
                    if (num > 0) {
                        $("#messageSuccess").html("");
                        $("#messageError").html("Highlighted input in red are mandatory.");
                        return false;

                    }
                    $("#messageError").html("");
                    return true;

                }
                if (ValidationInputs()) {
                    $.ajax({
                        type: 'POST',
                        url: url,
                        data: tempmodel,
                        success: function () {
                            $("#test").removeClass('hidden');
                            $("#container").addClass('hidden');
                            $(':input:not([type=button])').val('');
                            $("#ValidFrom").data("kendoDateTimePicker").value('');
                            $("#ValidTo").data("kendoDateTimePicker").value('');
                            $("#messageSuccess").html("Maintenance information saved successfully.");
                            $("#grid").data("kendoGrid").destroy();
                            messageBoardhelper.SearchMessages();
                        }
                    });
                }
            },
            UpdateMessageBoard: function (maintenanceInformation) {
                $("#messageError").html("");
                var tempmodel = createUpdateMessageModel();
                var urlUpdateMaintenanceDetail = _updateMB;
                $.ajax({
                    type: 'POST',
                    url: urlUpdateMaintenanceDetail,
                    data: $("#frmMessage").serialize(),
                    success: function () {
                        $("#messageSuccess").html("Maintenance information updated successfully.");
                        alert("Maintenance information updated successfully.");
                    }
                });
            },
            SearchMessages: function () {
                if ($(grid).data("kendoGrid")) {
                    $("#grid").data("kendoGrid").destroy();
                }

                var tempmodel = createMessageModel();
                var url = _getMB;
                $("#grid").kendoGrid({
                    dataSource: {
                        change: function (e) {
                            var ds = $("#grid").data('kendoGrid').dataSource;

                            if (e.action == "itemchange") {
                                var dataItem = ds.getByUid(e.items[0].uid);
                                ds.transport.update(dataItem);
                            }
                        },
                        transport: {
                            read: {
                                url: url,
                                contentType: "application/json",
                                type: "POST",
                                data: tempmodel
                            },
                            parameterMap: function (options) {
                                return kendo.stringify(options);
                            }
                        },
                        requestEnd: onRequestEnd,
                        schema: {
                            data: "Data",
                            total: "Total",
                            //model: {
                            //    id: "Id",
                            //    fields:
                            //    {
                            //        ValidFrom: { editable: false },
                            //        ValidTo: { editable: false },
                            //        Header: { editable: true },
                            //        Message: { editable: true },
                            //        CreatedBy: { editable: false },
                            //        Created: { editable: false },
                            //    }
                            //}
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
                    selectable: "row",
                    height: 335,
                    sortable: false,
                    pageable: true,
                    serverPaging: true,
                    columns: getMessageBoardColumns()
                });
            }
        };
    }();

});