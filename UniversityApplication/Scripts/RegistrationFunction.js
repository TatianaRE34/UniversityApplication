var username = $("#name").val();
var email = $("#email").val();
var password = $("#password").val();

$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });



    $("#register").click(function () {
      
        var userRegObj = { Username: username, Email: email, Password: password };
        $.ajax({
            type: "POST",
            url: "/Registration/Registration",
            data: userRegObj,
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


