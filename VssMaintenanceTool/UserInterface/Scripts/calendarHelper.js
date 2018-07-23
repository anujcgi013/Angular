var calendarHelper = null;

$(function () {

    calendarHelper = function () {
        var _UploadCalendarlink;
        
        


        return {
            init: function (UploadCalendarlink) {
                _UploadCalendarlink = UploadCalendarlink;
                
            },

            uploadCalendar: function() {
                var url = _UploadCalendarlink;
                var selectedMId = $("#markets").data("kendoDropDownList").value();

                $.ajax({
                    type: 'POST',
                    url: url,
                    data: function () {
                        var data = new FormData();
                        data.append("selectedMId", $("#markets").data("kendoDropDownList").value());
                        data.append("file", $("#files").get(0).files[0]);
                        return data;
                    }(),
                    contentType: false,
                    processData: false,
                    success: function (response) {
                    if (response.success) {
                        alert(response.responseText);                    
                        $("#files").val('');    
                    } else {
                        alert(response.responseText);                 
                    }
                    },

                error: function (response) {
                    alert("Unknown error has occured!");  // 
                }
                    
                });
            }

        };

    }();

});