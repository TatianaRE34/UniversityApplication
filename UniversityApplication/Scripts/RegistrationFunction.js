$(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });
    $("#name").change(function () {
        var username = $("#name").val();
        if (username === '') {
            document.getElementById("error-name").innerHTML = "Please enter name";
        } else {
            document.getElementById("error-name").innerHTML = "";
        }
    })
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
    $("#password").change(function (){
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
    $("#confirm-password").change(function () {
        var password = $("#password").val();
        var confirmPassword = $("#confirm-password").val();
        if (password !== confirm) {
            document.getElementById("error-confirm-password").innerHTML = "Passwords do not match";
        } else {
            document.getElementById("error-confirm-password").innerHTML = "";
        }
    })
    $("#register").click(function () {
        var username = $("#name").val();
        var email = $("#email").val();
        var password = $("#password").val();
        var confirmPassword = $("#confirm-password").val();
        var userRegistrationObj = { Username: username, Email: email, Password: password, ConfirmPassword: confirmPassword };
        console.log(userRegistrationObj);
        if (password !== confirmPassword) {
            document.getElementById("error-message").innerHTML = "Passwords are not correct";
        } else {
            $.ajax({
            type: "POST",
            url: "/Registration/Registration",
            data: userRegistrationObj,
            dataType: "json",
            success: function (response) {
                if (response.result) {
                    document.getElementById("error-message").innerHTML =  "Registration Successful";
                    window.location = response.url;
                }
                else {
                    document.getElementById("error-message").innerHTML = 'Unable to Register user';
                    return false;
                }
            },
        }); }
        
    });
});
