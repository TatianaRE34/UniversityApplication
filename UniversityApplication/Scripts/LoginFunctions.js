$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    $("#login").click(function () {
        var email = $("#email").val();
        var password = $("#password").val();
        var userLoginObj = {Email: email, Password: password };
        $.ajax({
            type: "POST",
            url: "/Login/Login",
            data: userLoginObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {
                    toastr.success("Successful Login");
                    window.location = response.url;
                }
                else {
                    toastr.error('Unable to Login user');
                    return false;
                }
            },

        });
    });

})