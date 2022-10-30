$(function () {
    let form = document.querySelector('form');

    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
    $("#email").change(function () {
        var email = $("#email").val();
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (email === '') {
            document.getElementById("error-email").innerHTML = "Please enter Email";
        } else {
            document.getElementById("error-email").innerHTML = "";
        }
        if (email.match(mailformat)) {
            document.getElementById("error-email").innerHTML = "";
        } else {
            document.getElementById("error-email").innerHTML = "Incorrect format";
        }
    })
    $("#password").change(function () {
        var password = $("#password").val();
        var minlength = 8;
        if (password === '') {
            document.getElementById("error-password").innerHTML = "Please enter Password";
        } else {
            document.getElementById("error-password").innerHTML = "";
        }
        if (password.length <= minlength) {
            document.getElementById("error-password").innerHTML = "Password length should be greater than 8 characters";
        } else {
            document.getElementById("error-password").innerHTML = "";
        }
    })

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
                    document.getElementById("error-message").innerHTML = "Successful Login";
                    window.location = response.url;
                }
                else {
                    document.getElementById("error-message").innerHTML = 'Unable to Login user';
                    return false;
                }
            },

        });
    });

})