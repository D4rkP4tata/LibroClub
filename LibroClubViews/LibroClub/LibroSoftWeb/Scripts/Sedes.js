function showModalForm() {
    var modalForm = new bootstrap.Modal(document.getElementById('modalForm'));
    modalForm.toggle();
}     

function validarFormulario() {
    var direccion = document.getElementById("Body_TxtDireccion").value;
    if (direccion == '') {
        alert("Ingrese todos los campos");
        return false;
    }
    return true;
}