var dataTable;

$(document).ready(function () {
    loadDataTable();
});

function loadDataTable() {
    dataTable = $('#invoiceDataTable').DataTable({
        "ajax": {
            "url":"/Invoice/GetAll"
        },
        "columns": [
            { "data": "invoiceNumber", "width": "19%" },
            { "data": "invoiceContractor", "width": "19%" },
            { "data": "invoiceSum", "width": "19%" },
            { "data": "invoiceDate", "width": "19%" },
            { "data": "invoiceDescription", "width": "19%" },
            {
                "data": "id",
                "render": function (data) {
                    return `
                        <div class="w-30 btn-group" role="group">
                            <a href="/Invoice/DetailsPage?id=${data}" class="btn btn-info mx-2">
                                <img src="/lib/bootstrap/icons/arrow-right-square.svg" alt="Bootstrap" width="20" height="20">
                            </a>
                        </div>
                    `
                },
                "width": "5%"
            }
        ]
    });
}