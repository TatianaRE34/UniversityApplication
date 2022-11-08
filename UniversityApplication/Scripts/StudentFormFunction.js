const { error } = require("jquery");

$(function () {
    count = 0
    maxSubject = 3;
    maxLengthNIC = 14;
    maxLengthphoneNumeber = 8;
    $("#first-name").change(function () {
        var name = $("#first-name").val();
        if (name === '') {
            document.getElementById("error-name").innerHTML = "Please enter name";
        } else {
            document.getElementById("error-name").innerHTML = "";
        }
    })
    $("#surname").change(function () {
        var surname = $("#surname").val();
        if (surname === '') {
            document.getElementById("error-surname").innerHTML = "Please enter surname";
        } else {
            document.getElementById("error-surname").innerHTML = "";
        }
    })
    $("#date-of-birth").change(function () {
        var dateOfBirth = $("#date-of-birth").val();
        if (dateOfBirth=== '') {
            document.getElementById("error-dob").innerHTML = "Please enter Date Of Birth";
        } else {
            document.getElementById("error-dob").innerHTML = "";
        }
    })
    $("#nic").change(function () {
        var nic = $("#nic").val();
        if (nic=== '') {
            document.getElementById("error-nic").innerHTML = "Please enter Identity card number";
        } else {
            document.getElementById("error-nic").innerHTML = "";
        }
        if (nic.length < maxLengthNIC) {
            document.getElementById("error-nic").innerHTML = "NIC is incorrect";
        } else {
            document.getElementById("error-nic").innerHTML = "";
        }
    })
    $("#guardian-name").change(function () {
        var guardianName = $("#guardian-name").val();
        if (guardianName === '') {
            document.getElementById("error-guardianName").innerHTML = "Please enter Guardian name";
        } else {
            document.getElementById("error-guardianName").innerHTML = "";
        }
    })
    $("#mobile-number").change(function () {
        var phone = $("#mobile-number").val();
        if (phone === '') {
            document.getElementById("error-mobile-number").innerHTML = "Please enter Phone Number";
        } else {
            document.getElementById("error-mobile-number").innerHTML = "";
        }
        if (phone.length < maxLengthphoneNumeber) {
            document.getElementById("error-mobile-number").innerHTML = "NIC is incorrect";
        } else {
            document.getElementById("error-mobile-number").innerHTML = "";
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
    $("#address").change(function () {
        var nic = $("#address").val();
        if (nic === '') {
            document.getElementById("error-address").innerHTML = "Please enter Address";
        } else {
            document.getElementById("error-address").innerHTML = "";
        }
    })
    $("#add-dropdown-btn").click(function () {
        var grades = ["A", "B", "C", "D", "E", "F"]
        document.getElementById("error-results-msg").innerHTML = "";
        if (count < maxSubject) {
            $.ajax({
                type: "GET",
                url: "/StudentRegistration/GetAllSubjects",
                datatype: "json",
                success: function (data) {
                    $(".dynamic-subject").append(
                        $(document.createElement('div'))
                            .prop({ id: 'new-subject' + count, name: 'new-subejct' })
                            .append(
                                $(document.createElement('label')).prop({ for: 'subjects' })
                                    .html('Select Subject')
                                    .append(
                                        $(document.createElement('select'))
                                            .prop({ id: 'subject' + count, name: 'subject' })
                                    ).append(
                            $(document.createElement('label')).prop({ for: 'grades' })
                                        .html('Select Grade')
                                        .append(
                                            $(document.createElement('select'))
                                                .prop({ id: 'grade' + count, name: 'grade' })
                                        )
                         )))
                        for (let index = 0; index < data.length; index++) {
                                $('#subject' + count).append($(document.createElement('option')).prop({
                                    value: data[index].SubjectName,
                                    text: data[index].SubjectName,
                                }))
                    }
                    for (const item of grades) {
                        $('#grade' + count).append($(document.createElement('option')).prop({
                            value: item,
                            text: item,
                            }))
                        }
                    count++;
                },
                error: function (error) {
                   
                }

            }
            )
        }
        
    })
    $("#remove-dropdown-btn").click(function () {
        $('#new-subject' + (count - 1)).remove();
        count--;
    });
    
});
