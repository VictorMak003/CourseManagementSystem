var defaultForm = document.getElementById("default-form");
var createForm = document.getElementById("create-form");
var editForm = document.getElementById("edit-form");
var deleteForm = document.getElementById("delete-form");
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

    document.querySelectorAll(".edit_btn").forEach(btn => {
        btn.addEventListener("click", function () {
            const studentId = this.dataset.id;
            window.location.href = `/Nav/Student?id=${studentId}`;
        });
    });

    //document.getElementById("delete_btn").addEventListener("click", function () {
    //    showForm(deleteForm)
    //});

});

