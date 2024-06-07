const toggleCheckbox = document.getElementById('checkbox_toggle');
toggleCheckbox.addEventListener('change', function () {
    const padresForm = document.getElementById('padres_form');
    const institucionalForm = document.getElementById('institucional_form');
     
    if (this.checked) {
        institucionalForm.style.display = 'block';
        padresForm.style.display = 'none';
    } else {
        institucionalForm.style.display = 'none';
        padresForm.style.display = 'block';
    }
});