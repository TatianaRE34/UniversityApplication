$(document).ready(function () {
    var maximumField = 3;
    var nextSubject = $('.subject-select');
    var addField = $('#add-dropdown-btn');
    var removeField = $('#remove-dropdown-btn');
    var newSelect = '<select id="SubjectDropDown" name="subjects[]" > <option>1</option></select><button id="remove-dropdown-btn"></button>';
    var selectCount = 1;
    $(addField).click(function () {
        if (selectCount < maximumField) {
            selectCount++;
            $('.next-subject').append(newSelect);
        }
    })
    $(nextSubject).on('click', '.remove-dropdown-btn', function () {
        $(this).parent('div').remove();
        selectCount--;
    })
});