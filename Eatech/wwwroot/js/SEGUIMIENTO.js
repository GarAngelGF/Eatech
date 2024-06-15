document.addEventListener('DOMContentLoaded', function() {
    // Toggle para Estudiantes y Agregar Estudiante
    const checkboxToggleStudents = document.getElementById('checkbox_toggle_students');
    const estudiantesContenedor = document.getElementById('estudiantes-contenedor');
    const agregarEstudianteContenedor = document.getElementById('agregar-estudiante-contenedor');

    // Mostrar el contenedor de "Estudiantes" al cargar la página
    estudiantesContenedor.classList.add('active');

    // Alternar entre los contenedores al hacer clic en el checkbox
    checkboxToggleStudents.addEventListener('change', function() {
        if (checkboxToggleStudents.checked) {
            agregarEstudianteContenedor.classList.add('active');
            estudiantesContenedor.classList.remove('active');
        } else {
            estudiantesContenedor.classList.add('active');
            agregarEstudianteContenedor.classList.remove('active');
        }
    });

    // Toggle para Buscar y Todos
    const checkboxToggleStudents2 = document.getElementById('checkbox_toggle_students2');
    const busquedaContenedor = document.getElementById('busqueda');
    const todosContenedor = document.getElementById('todos');

    // Mostrar el contenedor de "Buscar" al cargar la página
    busquedaContenedor.classList.add('active');

    // Alternar entre los contenedores al hacer clic en el checkbox
    checkboxToggleStudents2.addEventListener('change', function() {
        if (checkboxToggleStudents2.checked) {
            todosContenedor.classList.add('active');
            busquedaContenedor.classList.remove('active');
        } else {
            busquedaContenedor.classList.add('active');
            todosContenedor.classList.remove('active');
        }
    });
});
