$(document).ready(function () {
    //Give form a shorter name to make it easier to access
    var Form = document.forms.AddTeacherForm;
    //Assign form items to respective variable names
    var TeacherFname = Form.TeacherFname;
    var TeacherLname = Form.TeacherLname;
    var EmployeeNumber = Form.EmployeeNumber;
    var Salary = Form.Salary;

    //Check every input to ensure no empty form data is input by accident
    TeacherFname.addEventListener('input', function () {
        TeacherFname.setCustomValidity('');
        TeacherFname.checkValidity('');
    });
    TeacherFname.addEventListener('invalid', function () {
        if (TeacherFname.value === "") {
            //Tells user what the error is
            TeacherFname.setCustomValidity('Please enter a first name');
        }
    });
    TeacherLname.addEventListener('input', function () {
        TeacherLname.setCustomValidity('');
        TeacherLname.checkValidity('');
    });
    TeacherLname.addEventListener('invalid', function () {
        if (TeacherLname.value === "") {
            //Tells user what the error is
            TeacherLname.setCustomValidity('Please enter a last name');
        }
    });
    EmployeeNumber.addEventListener('input', function () {
        EmployeeNumber.setCustomValidity('');
        EmployeeNumber.checkValidity('');
    });
    EmployeeNumber.addEventListener('invalid', function () {
        if (EmployeeNumber.value === "") {
            //Tells user what the error is
            EmployeeNumber.setCustomValidity('Please enter a employee number');
        }
    });
    Salary.addEventListener('input', function () {
        Salary.setCustomValidity('');
        Salary.checkValidity('');
    });
    Salary.addEventListener('invalid', function () {
        if (Salary.value === "") {
            //Tells user what the error is
            Salary.setCustomValidity('Please enter a salary');
        }
    });
});