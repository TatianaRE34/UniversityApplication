$(function () {
    count = 0
    maxSubject = 3;

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
