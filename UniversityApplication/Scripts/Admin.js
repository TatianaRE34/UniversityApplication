$(document).ready(function () {
    $.ajax({
        type: "GET",
        url: "/Admin/GetAllStudents",
        datatype: "json",
        success: function (response) {
            $.each(response, function (index, student) {
                $('#dynamic-table').append("<tr>\
									<td>"+ student.StudentId + "</td>\
									<td>"+ student.Name + "</td>\
									<td>"+ student.Surname + "</td>\
                                        <td>"+ student.Email + "</td>\
                                    <td>"+ student.TotalGradePoint + "</td>\
                                    <td>"+ student.Status + "</td>\
									</tr>");
            })

        },
        error: function (error) {
            reject(error)
        },
    });

    $("#save-csv").click(function () {
        var titles = [];
        var data = [];

        $('#student-table').each(function () {
            data.push($(this));
        });

        csv_data = []

        data.forEach(function (item, index) {
            td = item[0].children
            for (i = 0; i < td.length; i++) {

                //csv_data.push(td[i].innerText + ',')
                console.log(td[i].innerText)
                var details = (td[i].innerText).split('\t');
                var studentDetail=''
                for (let index = 0; index < details.length; index++){
                    studentDetail += details[index] + ',';
                }
                csv_data.push(studentDetail)
            }
           
            csv_data.push($(this))
        })

        var downloadLink = document.createElement("a");
        var blob = new Blob(["\ufeff", csv_data]);
        var url = URL.createObjectURL(blob);
        downloadLink.href = url;
        downloadLink.download = "Student_list.csv";
        document.body.appendChild(downloadLink);
        downloadLink.click();
        document.body.removeChild(downloadLink);
    });
    $("#logout").click(function () {
        $.ajax({
            type: "GET",
            url: "/Admin/Logout",
            dataType: "json",
            success: function (response) {
                if (response.url) {

                    window.location = response.url;
                }
                else {

                    return false;
                }
            },


        });

    });
});