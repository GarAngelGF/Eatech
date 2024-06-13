
function showLabel(labelText) {
    var labelContainer = document.getElementById('labelContainer');
    labelContainer.textContent = labelText;
    labelContainer.style.display = 'block';
}

function hideLabel() {
    var labelContainer = document.getElementById('labelContainer');
    labelContainer.textContent = '';
    labelContainer.style.display = 'none';
}