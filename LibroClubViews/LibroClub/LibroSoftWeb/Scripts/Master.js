document.addEventListener('DOMContentLoaded', function () {
    var dropdownToggle = document.querySelector('#dropdownMenuButton1');
    var dropdownMenu = dropdownToggle.nextElementSibling;
    var navItems = document.querySelectorAll('.mynav .nav-item a');
    const currentPath =  window.location.pathname;

    navItems.forEach(function (item) {
        if (item.pathname == currentPath) {
            item.classList.add('color-selected');
        }
        else {
            item.classList.remove('color-selected');
        }
    });
    dropdownToggle.addEventListener('click', function (event) {
        event.preventDefault(); // Evitar comportamiento por defecto de Bootstrap

        if (dropdownMenu.classList.contains('show')) {
            // Ocultar el menú
            dropdownMenu.classList.remove('show');
            setTimeout(function () {
                dropdownMenu.style.visibility = 'hidden';
            }, 500); // Espera a que termine la transición antes de ocultar
        } else {
            // Mostrar el menú
            dropdownMenu.style.visibility = 'visible';
            dropdownMenu.classList.add('show');
        }
    });

    // Cerrar el dropdown si se hace clic fuera de él
    document.addEventListener('click', function (event) {
        if (!dropdownToggle.contains(event.target) && !dropdownMenu.contains(event.target)) {
            dropdownMenu.classList.remove('show');
            setTimeout(function () {
                dropdownMenu.style.visibility = 'hidden';
            }, 500); // Espera a que termine la transición antes de ocultar
        }
    });
});


