document.getElementById('colorForm').addEventListener('submit', function(e) {
    e.preventDefault();
    const color = document.getElementById('colorPicker').value;
    document.body.style.backgroundImage = 'none';
    document.body.style.backgroundColor = color;
    localStorage.setItem('backgroundColor', color);
    window.dispatchEvent(new CustomEvent('backgroundColorChanged', { detail: color }));
});
