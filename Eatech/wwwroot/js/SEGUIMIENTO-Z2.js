document.addEventListener('DOMContentLoaded', function() {
    const checkboxToggle = document.getElementById('checkbox_toggle_students22');
    const ordenarContenedor = document.getElementById('busqueda');
    const menuContenedor = document.getElementById('todos');

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
