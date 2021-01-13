$(document).ready(function () {
    loadDataTable();
})

function loadDataTable() {
    dataTable = $('#tblData').DataTable({
        "ajax": {
            "url": "/Admin/Company/GetAll"
        },
        "columns": [
            {
                "data": "name",
                "width": "15%"
            },
            {
                "data": "streetAddress",
                "width": "15%"
            },
            {
                "data": "city",
                "width": "10%"
            },
            {
                "data": "state",
                "width": "10%"
            },
            {
                "data": "phoneNumber",
                "width": "15%"
            },
            {
                "data": "isAuthorizedCompany",
                "render": function (data) {
                    if (data) {
                        return `<input type="checkbox" disabled checked />`
                    } else {
                        return `<input type="checkbox" disabled />`
                    }
                },
                "wdith": "10%"
            },
            {
                "data": "id",
                "render": function (data) {
                    return `
                            <div class="text-center">
                                <a href="/Admin/Company/Upsert/${data}" class="btn btn-success text-white" style="cursor:pointer">
                                    Edit
                                </a>
                                <a onclick=Delete("/Admin/Company/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer">
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
        title: "Do you really want to delete this category?",
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