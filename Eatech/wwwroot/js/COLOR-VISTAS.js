document.addEventListener('DOMContentLoaded', function() {
    const savedColor = localStorage.getItem('backgroundColor');
    if (savedColor) {
        document.body.style.backgroundImage = 'none';
        document.body.style.backgroundColor = savedColor;
    }
});

window.addEventListener('backgroundColorChanged', function(e) {
    const newColor = e.detail;
    document.body.style.backgroundImage = 'none';
    document.body.style.backgroundColor = newColor;
});
