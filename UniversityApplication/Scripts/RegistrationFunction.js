$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    $("#register").click(function () {
        var username = $("#name").val();
        var email = $("#email").val();
        var password = $("#password").val();
        var userObject = { Username: username, Email: email, Password: password };
        $.ajax({
            type: "POST",
            url: "/Registration/Registration",
            data: authObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {
                    toastr.success("Registration Successful");
                    window.location = response.url;
                }
                else {
                    toastr.error('Unable to Register user');
                    return false;
                }
            },

        });
    });
});