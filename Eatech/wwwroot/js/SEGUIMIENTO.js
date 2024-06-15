document.addEventListener('DOMContentLoaded', function() {
    const checkboxToggleStudents = document.getElementById('checkbox_toggle_students');
    const estudiantesContenedor = document.getElementById('estudiantes-contenedor');
    const agregarEstudianteContenedor = document.getElementById('agregar-estudiante-contenedor');

    estudiantesContenedor.classList.add('active');

    checkboxToggleStudents.addEventListener('change', function() {
        if (checkboxToggleStudents.checked) {
            agregarEstudianteContenedor.classList.add('active');
            estudiantesContenedor.classList.remove('active');
        } else {
            estudiantesContenedor.classList.add('active');
            agregarEstudianteContenedor.classList.remove('active');
        }
    });

    const checkboxToggleStudents2 = document.getElementById('checkbox_toggle_students2');
    const busquedaContenedor = document.getElementById('busqueda');
    const todosContenedor = document.getElementById('todos');

    busquedaContenedor.classList.add('active');

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
