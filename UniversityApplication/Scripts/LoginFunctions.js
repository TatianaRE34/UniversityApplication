$(function () {
    let form = document.querySelector('form');
    flag = false
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
    $("#email").change(function () {
        var email = $("#email").val();
        var mailformat = /^\w+([\.-]?\w+)*@\w+([\.-]?\w+)*(\.\w{2,3})+$/;
        if (email === '') {
            document.getElementById("error-email").innerHTML = "Please enter Email";
            flag = true
        } else {
            document.getElementById("error-email").innerHTML = "";
            flag = false
        }
        if (email.match(mailformat)) {
            document.getElementById("error-email").innerHTML = "";
            flag = false
        } else {
            document.getElementById("error-email").innerHTML = "Incorrect format";
            flag = true
        }
    })
    $("#password").change(function () {
        var password = $("#password").val();
        var minlength = 8;
        if (password === '') {
            document.getElementById("error-password").innerHTML = "Please enter Password";
            flag = true
        } else {
            document.getElementById("error-password").innerHTML = "";
            flag = false
        }
        if (password.length <= minlength) {
            document.getElementById("error-password").innerHTML = "Password length should be greater than 8 characters";
            flag = true
        } else {
            document.getElementById("error-password").innerHTML = "";
            flag = false
        }
    })
    $("#login").click(function () {
        var email = $("#email").val();
        var password = $("#password").val();
        var userLoginObj = { Email: email, Password: password };
        if (flag === false) {
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
                        document.getElementById("error-message").innerHTML = "Account credentials Incorrect";
                        return false;
                    }
                },

            });
        } else {
            document.getElementById("error-message").innerHTML = "Login incorrectly filled";
        }
        
    });

})