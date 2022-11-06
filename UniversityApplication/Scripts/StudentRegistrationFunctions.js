$(document).ready(function () {
    let form = document.querySelector('form');
    form.addEventListener('submit', (e) => {
        e.preventDefault();
        return false;
    });

    maxsubject = 3;
    $("#register").click(function () {
        var firstName = $("#first-name").val();
        var surname = $("#surname").val();
        var dateOfBirth = $("#date-of-birth").val();
        var nic = $("#nic").val();
        var mobile = $("#mobile-number").val();
        var email = $("#email").val();
        var address = $("#address").val();
        var guardianName = $("#guardian-name").val(); 
        var results = [];
        var subjects = [];
        for (let index = 0; index < maxsubject; index++) {
            if (($("#subject" + index).val() != null) && ($("#grade" + index).val() != null)) {
                if ($.inArray($("#subject" + index).val(), subjects)>=0 && subjects.length!==0) {
                    document.getElementById("error-results-msg").innerHTML = "Subject already inserted.";
                } else {
                    subjects.push($("#subject" + index).val());
                    subjectname=$("#subject" + index).val();
                    grade = $("#grade" + index).val();
                    results.push({ SubjectName: subjectname, Grade: grade})
                }
            } else if(index < 1){
                document.getElementById("error-results-msg").innerHTML = "Please add Results";
            }  
        }
        var studentObj = {
            Name: firstName,
            Surname: surname,
            Address: address,
            PhoneNumber: mobile,
            DateOfBirth: dateOfBirth,
            Email: email,
            NationalIdentificationCard: nic,
            GuardianName: guardianName,
            Results: results,
        }
        console.log(studentObj)
            $.ajax({
                type: "POST",
                url: "/StudentRegistration/RegisterStudent",
                data: studentObj,
                dataType: "json",
                success: function (response) {
                    if (response.result) {
                        document.getElementById("error-message").innerHTML = "Registration Successful";
                        window.location = response.url;
                    }
                    else {
                        document.getElementById("error-message").innerHTML = 'Unable to Register Student';
                        return false;
                    }
                },
            });
        

    })
});