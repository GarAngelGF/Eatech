document.addEventListener('DOMContentLoaded', function () {
    var containers = document.querySelectorAll('.content-container');
    containers.forEach(container => {
        container.style.display = 'none';
    });
    document.getElementById('container2').style.display = 'block';
});

function toggleContainer(containerId) {
    var containers = document.querySelectorAll('.content-container');
    containers.forEach(container => {
        container.style.display = 'none';
    });
    document.getElementById(containerId).style.display = 'block';
}