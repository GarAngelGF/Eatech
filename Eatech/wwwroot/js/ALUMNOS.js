document.addEventListener('DOMContentLoaded', function() {
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
});
