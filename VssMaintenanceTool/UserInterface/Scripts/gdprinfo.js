"use strict";

function constructGDPRInfoModel() {
    var searchString = $("#SearchString").val();

    var model = {
        SearchString: searchString
    };
    return model;
}

var UrlGetGDPRInfo = $('#UrlGetGDPRInfo').data('url');

function GetGDPRInfo() {

    $('#result').removeData('bs.modal');
    $('#result').find('.modal-content').html('');
    $.ajax({
        url: UrlGetGDPRInfo,
        dataType: "html",
        data: constructGDPRInfoModel(),
        type: "GET",
        contentType: "application/html; charset=utf-8",
        //cache: false,
        success: function (result) {
            $("#result").html(result);
        },
        error: function (xhr) {
            alert("Something went wrong!...");
        }
    });
};

$('#btnSearchGDPRInfo').click(function () {
    GetGDPRInfo();
});

$('#SearchString').keypress(function (event) {
    if (event.keyCode == 13) {
        $('#btnSearchGDPRInfo').click();
    }
});






