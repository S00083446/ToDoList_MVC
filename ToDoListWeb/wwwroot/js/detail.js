var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Detail/GetAll"
        },
        "columns": [
            { "data": "description", "width": "7%" },
            { "data": "startDate", "width": "7%" },
            { "data": "endDate", "width": "7%" },
            { "data": "daysUntilEvent", "width": "7%" },
            { "data": "startTime", "width": "7%" },
            { "data": "endTime", "width": "7%" },
            { "data": "location", "width": "7%" },
            { "data": "roomName", "width": "7%" },
            { "data": "notes", "width": "7%" },
            { "data": "cost", "width": "7%" },
            { "data": "percentageOfTotalMarks", "width": "7%" },
            { "data": "numberOfParticpants", "width": "7%" },
            { "data": "imageUrl", "width": "7%" },
            { "data": "subjects.name", "width": "7%" },

            {
                "data": "id",
                "render": function (data) {
                    return `
                     <div class="w-75 btn-group" role="group">
                        <a href="/Admin/Detail/Upsert?id=${data}"
                        class="btn btn-primary mx-2"> <i class="bi bi-pencil-square"></i>Edit</a>
                        <a class="btn btn-danger mx-2"> <i class="bi bi-trash-fill"></i>Delete</a>
                    </div>
                        `
                },
                "width": "15%"
            }

        ]
    });
}