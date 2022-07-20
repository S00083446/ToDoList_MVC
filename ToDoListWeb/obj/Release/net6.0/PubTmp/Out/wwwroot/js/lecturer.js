﻿//const { Toast } = require("../lib/bootstrap/dist/js/bootstrap");

var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Lecturer/GetAll"
        },
        "columns": [
            { "data": "name", "width": "7%" },
            { "data": "courseTaught", "width": "7%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Lecturer/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a onClick=Delete('/Admin/Lecturer/Delete/${data}')
                        class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                    </div>
                        `
                },
                "width": "15%"
            }

        ]
    });
}
function Delete(url) {
    Swal.fire({
        title: 'Are you sure?',
        text: "You won't be able to revert this!",
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        cancelButtonColor: '#d33',
        confirmButtonText: 'Yes, delete it!'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                url: url,
                type: "DELETE",
                success: function (data) {
                    if (data.success) {
                        dataTable.ajax.reload();
                        toastr.success(data.message);
                    }
                    else {
                        toastr.error(data.message);
                    }
                }
            })
            
        }
    })
}