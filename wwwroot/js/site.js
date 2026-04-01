var studentList = document.querySelector(".student-list");
var studentDetails = document.querySelector(".student-details");
var defaultForm = document.querySelector(".default-form");
var createForm = document.querySelector(".create-form");
var editForm = document.querySelector(".edit-form");
var deleteForm = document.querySelector(".delete-form");


function showForm(formToShow) {
    const forms = [defaultForm, createForm, editForm, deleteForm];

    forms.forEach(form => {
        if (form) {
            form.style.display = "none";
        }
    });

    if (formToShow) {
        formToShow.style.display = "block";
    }
};

document.addEventListener("DOMContentLoaded", function () {
    document.querySelector(".add_btn").addEventListener("click", function () {
        showForm(createForm)
    });

    document.querySelectorAll(".details_btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const studentId = this.dataset.id;
            window.location.href = `/Nav/Student?id=${studentId}`;
        });
    });
    //document.querySelectorAll(".edit_btn").forEach(btn => {
    //    btn.addEventListener("click", function () {
    //        const studentId = this.dataset.id;
    //        window.location.href = `/Nav/Student?id=${studentId}`;
    //    });
    //});
    document.querySelectorAll(".edit_btn").forEach(btn => {
        btn.addEventListener("click", function () {
            showForm(editForm);
        });
    });
    //document.querySelectorAll(".delete_btn").forEach(btn => {
    //    btn.addEventListener("click", function () {
    //    const studentId = this.dataset.id;
    //    window.location.href = `/Nav/Student?id=${studentId}`;
    //    });
    //});
    document.querySelectorAll(".delete_btn").forEach(btn => {
        btn.addEventListener("click", function () {
            showForm(deleteForm);
        });
    });

    document.querySelectorAll(".cancel_btn").forEach(btn => {
        btn.addEventListener("click", function () {
            showForm(defaultForm);
        });
    });
});



