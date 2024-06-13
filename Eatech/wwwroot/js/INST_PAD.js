const toggleCheckbox = document.getElementById('checkbox_toggle');
toggleCheckbox.addEventListener('change', function() {
    const institucionalForm = document.getElementById('institucional_form');
    const padresForm = document.getElementById('padres_form');
    
    if (this.checked) {
        institucionalForm.style.display = 'block';
        padresForm.style.display = 'none';
    } else {
        institucionalForm.style.display = 'none';
        padresForm.style.display = 'block';
    }
});