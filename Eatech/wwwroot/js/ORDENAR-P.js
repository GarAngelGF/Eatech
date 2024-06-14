document.addEventListener('DOMContentLoaded', function() {
    const checkboxToggle = document.getElementById('checkbox_toggle');
    const ordenarContenedor = document.getElementById('ordenar-contenedor');
    const menuContenedor = document.getElementById('menu-contenedor');

    // Mostrar el contenedor de "Menú disponible" al cargar la página
    menuContenedor.classList.add('active');

    // Alternar entre los contenedores al hacer clic en el checkbox
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
