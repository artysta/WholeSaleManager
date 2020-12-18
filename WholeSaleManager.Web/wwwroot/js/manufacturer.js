$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Manufacturer/GetAll"
        },
        "columns": [
            {
                "data": "name",
                "wdith": "60%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Manufacturer/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    Edit
                                </a>
                                <a onclick=Delete("/Admin/Manufacturer/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
                                    Delete
                                </a>
                            </div>
                            `;
                },
                "width": "40%"
            }
        ]
    });
}

function Delete(url) {
    swal({
        title: "Do you really want to delete this manufacturer?",
        icon: "warning",
        buttons: true,
        dangerMode: true
    }).then((d) => {
        if (d) {
            $.ajax({
                type: "DELETE",
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        dataTable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}