//Delete the entity request
function crearEventosDeTabla() {
    document.querySelectorAll('#btnDelete').forEach(x => x.addEventListener('click', (e) => {
        e.preventDefault();

        Swal.fire({
            title: "Eliminar Habitacion?",
            showDenyButton: true,
            confirmButtonText: "Si",
            denyButtonText: `No`
        }).then((result) => {
            if (result.isConfirmed) {

                const url = x.href;

                x.disabled = true;

                fetch(url, { method: 'POST' })
                    .then(response => response.json())
                    .then(json => this.manageResponse(json));

            }
        });
    }));
}

//Entity delete response
function manageResponse(json) {
    if (json.success) {
        refrescarTabla();
        toastr["success"](json.message, "Eliminar Habitacion")

    } else {
        toastr["error"](json.message, "Eliminar Habitacion")
    }
}

//Refreshing data table
function refrescarTabla() {
    $("#tableData").load('/Habitacion/GetTable', () => {
        crearEventosDeTabla();
    });
}

crearEventosDeTabla();