﻿$(function () {
    $("#logout").click(function () {
        $.ajax({
            type: "Post",
            url: "/Admin/Logout",
            datatype: "json",
            success: function (url) {
                toastr.success("logged out") 
                  },
            error: function (error) {
                reject(error)
            },
        });
    })
});
$(function () {


})