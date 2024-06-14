function hideAlertMessage() {
    setTimeout(function () {
        var alertMessage = document.getElementById("AlertaMensajeNuevoUsuario");
        if (alertMessage) {
            alertMessage.style.display = 'none';
        }
    }, 8000);
}

function showModalForm() {
    var modalForm = new bootstrap.Modal(document.getElementById("modalForm"));
    modalForm.toggle();
}  

function showModalFormError() {
    var modalForm = new bootstrap.Modal(document.getElementById("modalFormError"));
    modalForm.toggle();
}

