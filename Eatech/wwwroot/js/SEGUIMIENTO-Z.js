document.addEventListener('DOMContentLoaded', function() {
    const checkboxToggle = document.getElementById('checkbox_toggle_otro_nombre');
    const ordenarContenedor = document.getElementById('contenedor-todos');
    const menuContenedor = document.getElementById('contenedor-busqueda');

    menuContenedor.classList.add('active');

    checkboxToggle.addEventListener('change', function() {
        if (checkboxToggle.checked) {
            ordenarContenedor.classList.add('active');
            menuContenedor.classList.remove('active');
        } else {
            menuContenedor.classList.add('active');
            ordenarContenedor.classList.remove('active');
        }
    });
});


