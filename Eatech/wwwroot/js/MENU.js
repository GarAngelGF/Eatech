document.addEventListener('DOMContentLoaded', function() {
    // Toggle para contenedor "AGREGADOS"
    const toggleAgregados = document.getElementById('checkbox_toggle_agregados');
    const contenedorAgregados = document.getElementById('contenedor-agregados');

    // Toggle para contenedor "AGREGAR"
    const toggleAgregar = document.getElementById('checkbox_toggle_agregar');
    const contenedorAgregar = document.getElementById('contenedor-agregar');

    // Mostrar el contenedor de "AGREGADOS" por defecto
    contenedorAgregados.classList.add('active');

    // Función para manejar el cambio de los toggles
    toggleAgregados.addEventListener('change', function() {
        if (toggleAgregados.checked) {
            contenedorAgregados.classList.add('active');
        } else {
            contenedorAgregados.classList.remove('active');
        }
    });

    toggleAgregar.addEventListener('change', function() {
        if (toggleAgregar.checked) {
            contenedorAgregar.classList.add('active');
        } else {
            contenedorAgregar.classList.remove('active');
        }
    });
});
